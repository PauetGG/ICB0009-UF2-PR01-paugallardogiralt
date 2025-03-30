using System;
using System.Collections.Generic;
using System.Threading;

//Class sala de espera con los atributos pacientes en espera y capaciad máxima para esperar. 
class SalaDeEspera
{
    private Queue<Paciente> pacientesEnEspera = new Queue<Paciente>();
    private const int CapacidadMaxima = 20;

    //Método para agregar pacientes a la sala de espera en función de si hay espacio o no. 
    public bool AgregarPaciente(Paciente paciente)
    {
        if (pacientesEnEspera.Count < CapacidadMaxima)
        {
            pacientesEnEspera.Enqueue(paciente);
            paciente.CambiarEstado(EstadoPaciente.EsperaConsulta);
            return true;
        }
        else
        {
            Console.WriteLine($"Paciente {paciente.NumeroLlegada} no puede ingresar, sala de espera llena.");
            return false;
        }
    }
    //Método para sacar el siguiente paciente que tiene que ser atendido. 
    public Paciente? ObtenerSiguientePaciente()
    {
        return pacientesEnEspera.Count > 0 ? pacientesEnEspera.Dequeue() : null;
    }
}