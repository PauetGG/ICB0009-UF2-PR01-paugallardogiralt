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
    public async Task AtenderPaciente(Paciente paciente)
    {
        //Usamos lock para que solo un hilo pueda modificar Ocupado
        lock (lockObj)
        {
            if (Ocupado) return;
            Ocupado = true;
        }

        paciente.Estado = EstadoPaciente.Consulta;
        Console.WriteLine($"Ahora mismo se encuentra en: {paciente.Estado} el paciente Número: {paciente.NumeroLlegada} con el ID: {paciente.Id} y está siendo atendido a manos del médico número: {Id}\n");
        //Simula la atención del médico por el tiempo de consulta en segundos. 
        await Task.Delay(paciente.TiempoConsulta * 1000);

        paciente.Estado = EstadoPaciente.Finalizado;
        Console.WriteLine($"Paciente Número: {paciente.NumeroLlegada} con el ID: {paciente.Id}, ahora mismo el proceso de la consulta ha: {paciente.Estado} y ha salido sano gracias al médico número: {Id}\n");

        lock (lockObj)
        {
            Ocupado = false;
        }
    }
}
