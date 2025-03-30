using System;
using System.Collections.Generic;
using System.Threading;

//Class sala de espera con los atributos pacientes en espera y capaciad máxima para esperar. 
class SalaDeEspera
{
    private List<Paciente> pacientesEnEspera = new List<Paciente>();
    private const int CapacidadMaxima = 20;

    //Método para agregar pacientes a la sala de espera en función de si hay espacio o no. 
    public bool AgregarPaciente(Paciente paciente)
    {
        if (pacientesEnEspera.Count < CapacidadMaxima)
        {
            pacientesEnEspera.Add(paciente);
            paciente.CambiarEstado(EstadoPaciente.EsperaConsulta);
            return true;
        }
        else
        {
            Console.WriteLine($"Paciente {paciente.NumeroLlegada} no puede ingresar, sala de espera llena.");
            return false;
        }
    }
    //Método para sacar el siguiente paciente que tiene que ser atendido en orden. 
    public Paciente? ObtenerSiguientePaciente()
    {
        if (pacientesEnEspera.Count == 0) return null;

        // Ordenamos la lista por prioridad y llegada
        var pacienteOrdenado = pacientesEnEspera
            .OrderBy(p => p.Prioridad) 
            .ThenBy(p => p.LlegadaHospital)
            .First();
        
        pacientesEnEspera.Remove(pacienteOrdenado);
        return pacienteOrdenado;
    }
}