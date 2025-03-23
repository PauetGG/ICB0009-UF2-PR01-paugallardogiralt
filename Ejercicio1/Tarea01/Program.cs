using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

class Program
{
    static async Task Main()
    {
        SalaDeEspera salaDeEspera = new SalaDeEspera();
        Hospital hospital = new Hospital(salaDeEspera);
        List<Task> pacientes = new List<Task>();
        //Bucle para crear a los pacientes y los añadimos al método AtenderPacientes de la class Sala de Espera.
        for (int i = 1; i <= 4; i++) 
        {
            Paciente paciente = new Paciente(i);
            if (salaDeEspera.AgregarPaciente(paciente))
            {
                pacientes.Add(hospital.AtenderPacientes());
            }
            //Delay qye hay entre la llegada de cada paciente. 
            await Task.Delay(2000); 
        }
        //Esperamos a que todos los pacientes sean atendidos para poder finalizar el programa. 
        await Task.WhenAll(pacientes); 
        Console.WriteLine("Todos los pacientes han sido atendidos.");
    }
}
