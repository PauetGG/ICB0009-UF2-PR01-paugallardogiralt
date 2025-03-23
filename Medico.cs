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
        
        Console.WriteLine($"Paciente {paciente.Numero} está siendo atendido por el Médico {Id}.");
        //Simula la atención del médico por 10 segundos. 
        await Task.Delay(10000); 
        Console.WriteLine($"Paciente {paciente.Numero} ha salido de la consulta del Médico {Id}.");
        
        lock (lockObj)
        {
            Ocupado = false;
        }
    }
}
