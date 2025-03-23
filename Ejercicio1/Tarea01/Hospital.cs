using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

//Class Hospital con sus atributos que usaremos para crear el hospital y poder realizar los métodos correspondientes. 
class Hospital
{
    private SemaphoreSlim semaforoMedicos = new SemaphoreSlim(4); 
    private List<Medico> medicos;
    private Random random = new Random();
    private SalaDeEspera salaDeEspera;
    
    //Constructor de hospital donde añadimos la sala de espera y los 4 médicos. 
    public Hospital(SalaDeEspera sala)
    {
        salaDeEspera = sala;
        medicos = new List<Medico>();
        for (int i = 1; i <= 4; i++)
        {
            medicos.Add(new Medico(i));
        }
    }
    
    //Método para atender los pacientes de la manera solicitada en el apartado. 
    public async Task AtenderPacientes()
    {
        //Se crea la lista para guardar las consultas médicas que están ocurriendo y así esperar que las consultas terminen antes de terminar el método. 
        List<Task> tareasMedicas = new List<Task>();
        //Bucle para obtener los pacientes de la sala de espera. 
        while (true)
        {
            Paciente? paciente = salaDeEspera.ObtenerSiguientePaciente();
            if (paciente == null) break;
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
            //Si está disponible iniciamos un nuevo hilo
            if (medicoAsignado != null)
            {
                tareasMedicas.Add(Task.Run(async () =>
                {
                    await medicoAsignado.AtenderPaciente(paciente);
                    semaforoMedicos.Release();
                }));
            }
            else
            {
                Console.WriteLine($"No hay médicos disponibles para atender al paciente {paciente.Numero} en este momento.");
                semaforoMedicos.Release();
            }
        }
        //Espera a que las tareas finalicen antes de salir del método. 
        await Task.WhenAll(tareasMedicas);
    }
}