using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

//Enum de los estados dentro de la consulta que puede tener un paciente. 
public enum EstadoPaciente
{
    Espera,
    Consulta,
    Finalizado
}

//Enum de las prioridades de urgencia del paciente. 
public enum PrioridadPaciente
{
    Emergencia = 1,
    Urgencia = 2,
    ConsultaGeneral = 3
}

//Class paciente con sus atributos actualizados para la tarea 2. 
class Paciente
{
    public int Id { get; set; }
    public int NumeroLlegada { get; set; }
    public int LlegadaHospital { get; set; }
    public int TiempoConsulta { get; set; }
    public EstadoPaciente Estado { get; set; }
    public PrioridadPaciente Prioridad { get; set; }
    public Stopwatch RelojEstado { get; set; } = new Stopwatch();
    public int? IdMedicoAsignado { get; set; } = null;

    //Constructor de paciente en la cual el atributo estado está en espera ya que cuando se inicie siempre estarán en espera. 
    public Paciente(int numeroLlegada, int llegadaHospital, int tiempoConsulta, int id, PrioridadPaciente prioridad)
    {
        NumeroLlegada = numeroLlegada;
        LlegadaHospital = llegadaHospital;
        TiempoConsulta = tiempoConsulta;
        Id = id;
        Prioridad = prioridad;
        Estado = EstadoPaciente.Espera;
        RelojEstado.Start();
    }

    public void CambiarEstado(EstadoPaciente nuevoEstado)
    {
        int duracion = (int)RelojEstado.Elapsed.TotalSeconds;
        string mensaje = nuevoEstado switch
        {
            EstadoPaciente.Espera => $"Paciente {Id}. Llegado el {NumeroLlegada}. Prioridad: {Prioridad}. Estado: Espera.",
            EstadoPaciente.Consulta => $"Paciente {Id}. Llegado el {NumeroLlegada}. Prioridad: {Prioridad}. Estado: Consulta. Médico: {IdMedicoAsignado}. Duración Espera: {duracion} segundos.",
            EstadoPaciente.Finalizado => $"Paciente {Id}. Llegado el {NumeroLlegada}. Prioridad: {Prioridad}. Estado: Finalizado. Médico: {IdMedicoAsignado}. Duración Consulta: {TiempoConsulta} segundos.",
            _ => ""
        };
        Console.WriteLine(mensaje);
        Estado = nuevoEstado;
        RelojEstado.Restart();
    }
}