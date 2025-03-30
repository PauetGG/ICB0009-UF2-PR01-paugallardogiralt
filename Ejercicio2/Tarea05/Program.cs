using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

class Program
{
    static async Task Main()
    {
        Random random = new Random();
        SalaDeEspera salaDeEspera = new SalaDeEspera();
        Hospital hospital = new Hospital(salaDeEspera);

        List<Paciente> pacientes = new List<Paciente>();
        
        Console.WriteLine("Bienvenidos a una nueva jornada laboral en el Hospital Japonés: MeKito ToLos Males\n");
        //Bucle para crear a los pacientes con los atributos actualizados y los añadimos al método AtenderPacientes de la class Sala de Espera.
        for (int i = 1; i <= 20; i++)
        {
            int idUnico = random.Next(1, 101);
            PrioridadPaciente prioridad = (PrioridadPaciente)random.Next(1, 4); 
            int tiempoConsulta = random.Next(5, 16);
            int llegada = (i) * 2;
            bool requiereDiagnostico = random.Next(0, 2) == 1;
            Paciente paciente = new Paciente(i, llegada, tiempoConsulta, idUnico, prioridad, requiereDiagnostico);
            pacientes.Add(paciente);
        // Agregar a la lista ordenada del hospital
            lock (hospital.lockOrdenLlegada)
            {
                hospital.pacientesOrdenados.Add(paciente);
            }
        }

        int tiempoActual = 0;

        var tareaAtencion = Task.Run(async () => await hospital.AtenderPacientes());
        var tareaDiagnostico = Task.Run(async () => await hospital.ProcesarDiagnosticos());
        //forEach para poder hacer que cada paciente entre en función del tiempo de llegada al hospital. 
        foreach (var paciente in pacientes)
        {
            int espera = paciente.LlegadaHospital - tiempoActual;
            if (espera > 0)
            {
                await Task.Delay(espera * 1000);
                tiempoActual += espera;
            }
            salaDeEspera.AgregarPaciente(paciente);
        }

        await Task.Delay(91000); 
        Console.WriteLine("Todos los pacientes han sido atendidos.");
        //Recuento del final del día. 
        Console.WriteLine("\n--- FIN DEL DÍA ---");
        Console.WriteLine("Pacientes atendidos:");
        //Variables que usaremos para printear las prioridades. 
        var emergencias = pacientes.Where(p => p.Prioridad == PrioridadPaciente.Emergencia);
        var urgencias = pacientes.Where(p => p.Prioridad == PrioridadPaciente.Urgencia);
        var consultas = pacientes.Where(p => p.Prioridad == PrioridadPaciente.ConsultaGeneral);

        Console.WriteLine($"- Emergencias: {emergencias.Count()}");
        Console.WriteLine($"- Urgencias: {urgencias.Count()}");
        Console.WriteLine($"- Consultas generales: {consultas.Count()}");
        //Cálculo del promedio en tiempo de espera.
        double promEmergencias = emergencias.Any() ? emergencias.Average(p => p.TiempoEsperaConsulta) : 0;
        double promUrgencias = urgencias.Any() ? urgencias.Average(p => p.TiempoEsperaConsulta) : 0;
        double promConsultas = consultas.Any() ? consultas.Average(p => p.TiempoEsperaConsulta) : 0;

        Console.WriteLine("\nTiempo promedio de espera:");
        Console.WriteLine($"- Emergencias: {Math.Round(promEmergencias)}s");
        Console.WriteLine($"- Urgencias: {Math.Round(promUrgencias)}s");
        Console.WriteLine($"- Consultas generales: {Math.Round(promConsultas)}s");
        double tiempoTotalSimulacion = hospital.relojDiagnostico.Elapsed.TotalSeconds;
        double usoPorcentaje = (hospital.tiempoUsoTotalDiagnostico / (2 * tiempoTotalSimulacion)) * 100;
        Console.WriteLine($"\nUso promedio de máquinas de diagnóstico: {Math.Round(usoPorcentaje)}%");
        Console.WriteLine("\nGracias por acompañarnos en el Hospital MeKito ToLos Males. ¡Nos vemos mañana! 😄");
    }
}
