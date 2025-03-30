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
        for (int i = 1; i <= 4; i++)
        {
            int idUnico = random.Next(1, 101);
            PrioridadPaciente prioridad = (PrioridadPaciente)random.Next(1, 4); 
            int tiempoConsulta = random.Next(5, 16);
            int llegada = (i) * 3;
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

        await Task.Delay(61000); 
        Console.WriteLine("Todos los pacientes han sido atendidos.");
    }
}

