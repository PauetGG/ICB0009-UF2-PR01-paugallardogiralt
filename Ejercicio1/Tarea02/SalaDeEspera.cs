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
            Console.WriteLine($"Paciente Número: {paciente.NumeroLlegada} ha llegado al hosipital en: {paciente.LlegadaHospital}s con el ID: {paciente.Id}, ahora mismo se encuentra en: {paciente.Estado}");
            Console.WriteLine($"Con una Prioridad del nivel: {paciente.Prioridad} y aproximamos que tardaremos en atenderlo unos: {paciente.TiempoConsulta}s\n");
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