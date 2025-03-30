using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Diagnostics;

//Class Hospital con sus atributos que usaremos para crear el hospital y poder realizar los métodos correspondientes. 
class Hospital
{
    private SemaphoreSlim semaforoMedicos = new SemaphoreSlim(4);
    private SemaphoreSlim maquinasDiagnostico = new SemaphoreSlim(2);
    private List<Medico> medicos;
    private Random random = new Random();
    private SalaDeEspera salaDeEspera;
    public List<Paciente> pacientesOrdenados = new List<Paciente>();
    public object lockOrdenLlegada = new object();
    private object lockDiagnostico = new object();
    private List<Paciente> colaDiagnostico = new List<Paciente>();
    public Stopwatch relojDiagnostico = new Stopwatch();
    public double tiempoUsoTotalDiagnostico = 0;


    //Constructor de hospital donde añadimos la sala de espera y los 4 médicos. 
    public Hospital(SalaDeEspera sala)
    {
        salaDeEspera = sala;
        medicos = new List<Medico>();
        for (int i = 1; i <= 4; i++)
        {
            medicos.Add(new Medico(i));
        }
         relojDiagnostico.Start();
    }

    //Método para atender los pacientes.
    public async Task AtenderPacientes()
    {
         //Se crea la lista para guardar las consultas médicas que están ocurriendo y así esperar que las consultas terminen antes de terminar el método. 
        List<Task> tareasMedicas = new List<Task>();
         //Bucle para obtener los pacientes de la sala de espera. 
        while (true)
        {
            //Sacamos los pacientes de la sala de espera y si no hay esperamos medio segundo para volver a intentarlo. 
            Paciente? paciente = salaDeEspera.ObtenerSiguientePaciente();
            if (paciente == null)
            {
                await Task.Delay(500); 
                continue;
            }
             //Esperamos a tener un médico disponible
            await semaforoMedicos.WaitAsync();
            //Seleccionamos el médico disponible de manera aleatoria y usamos lock para que cada médico use un solo hilo. 
            Medico? medicoAsignado = null;
            lock (random)
            {
                var medicosDisponibles = medicos.FindAll(m => !m.Ocupado);
                if (medicosDisponibles.Count > 0)
                {
                    medicoAsignado = medicosDisponibles[random.Next(medicosDisponibles.Count)];
                }
            }
            //Si está disponible iniciamos un nuevo hilo y añadimos el paciente a la lista ordenada en función la llegada del hospital. 
            if (medicoAsignado != null)
            {
                tareasMedicas.Add(Task.Run(async () =>
                {
                    await medicoAsignado.AtenderPaciente(paciente, (paciente) =>
                    {
                        lock (lockDiagnostico)
                        {
                            colaDiagnostico.Add(paciente);
                            colaDiagnostico.Sort((a, b) => a.LlegadaHospital.CompareTo(b.LlegadaHospital));
                        }
                    });

                    semaforoMedicos.Release();
                }));
            }
            else
            {
                Console.WriteLine($"No hay médicos disponibles para atender al paciente {paciente.NumeroLlegada} en este momento.");
                semaforoMedicos.Release();
            }
        }
    }
    //Método para procesar los diagnósticos de forma ordenada. 
    public async Task ProcesarDiagnosticos()
{
    while (true)
    {
        Paciente? paciente = null;

        lock (lockDiagnostico)
        {
            if (colaDiagnostico.Count > 0)
            {
                paciente = colaDiagnostico[0];
            }
        }
        //Si encontramos un paciente en espera, buscamos el indice del paciente en la lista de orden de llegada al hospital. 
        if (paciente != null)
        {
            bool puedePasarADiagnostico = false;

            lock (lockOrdenLlegada)
            {
                int index = pacientesOrdenados.FindIndex(p => p.Id == paciente.Id);

                // Puede pasar si todos los anteriores ya están finalizados
                puedePasarADiagnostico = pacientesOrdenados
                .Take(index)
                .All(p => p.Estado == EstadoPaciente.Finalizado || p.Estado == EstadoPaciente.EsperaDiagnostico);
            }
            //Si tiene que pasar diagnóstico lo sacamos de la lista y lo añadimos al proceso si está la máquina disponible. 
            if (puedePasarADiagnostico)
            {
                lock (lockDiagnostico)
                {
                    colaDiagnostico.Remove(paciente);
                }

                await maquinasDiagnostico.WaitAsync();
                double inicio = relojDiagnostico.Elapsed.TotalSeconds;

                _ = Task.Run(async () =>
                {
                    paciente.CambiarEstado(EstadoPaciente.EsperaDiagnostico);
                    await Task.Delay(15000);
                    paciente.TiempoConsulta += 15;
                    paciente.CambiarEstado(EstadoPaciente.Finalizado);
                    double fin = relojDiagnostico.Elapsed.TotalSeconds;
                    lock (this)
                    {
                        tiempoUsoTotalDiagnostico += (fin - inicio);
                    }
                    maquinasDiagnostico.Release();
                });
            }
        }

        await Task.Delay(100);
    }
}
}