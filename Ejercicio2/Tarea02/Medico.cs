using System;

//Class médico con atributos ID y Ocupado para saber si están disponibles. 
class Medico
{
    public int Id { get; }
    public bool Ocupado { get; private set; }
    private object lockObj = new object();

    public Medico(int id)
    {
        Id = id;
        Ocupado = false;
    }

    //Método en el cúal el médico atiende al paciente si no está ocupado.
    public async Task AtenderPaciente(Paciente paciente, Action<Paciente> agregarADiagnostico)
{
    lock (lockObj)
    {
        if (Ocupado) return;
        Ocupado = true;
    }

    paciente.IdMedicoAsignado = Id;
    paciente.CambiarEstado(EstadoPaciente.Consulta);
    await Task.Delay(paciente.TiempoConsulta * 1000);

    if (paciente.RequiereDiagnostico)
    {
        // No cambiar estado aún. Solo lo agregamos a la cola ordenada
        agregarADiagnostico(paciente);
    }
    else
    {
        paciente.CambiarEstado(EstadoPaciente.Finalizado);
    }

    lock (lockObj)
    {
        Ocupado = false;
    }
}
}
