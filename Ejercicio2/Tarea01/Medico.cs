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
    public async Task AtenderPaciente(Paciente paciente, SemaphoreSlim maquinasDiagnostico)
    {
        //Usamos lock para que solo un hilo pueda modificar Ocupado
        lock (lockObj)
        {
            if (Ocupado) return;
            Ocupado = true;
        }

        paciente.IdMedicoAsignado = Id;
        paciente.CambiarEstado(EstadoPaciente.Consulta);
        //Simula la atención del médico por el tiempo de consulta en segundos. 
        await Task.Delay(paciente.TiempoConsulta * 1000);
        //If para comprobar que el paciente requiere un diagnóstico
        if (paciente.RequiereDiagnostico)
        {
            //Esperamos que estén disponibles las máquinas si no lo están y esperamos el tiempo del diagnóstico.
            await maquinasDiagnostico.WaitAsync();
            paciente.CambiarEstado(EstadoPaciente.EsperaDiagnostico);
            await Task.Delay(15000);
            paciente.TiempoConsulta += 15;
            maquinasDiagnostico.Release();
        }

        paciente.CambiarEstado(EstadoPaciente.Finalizado);

        lock (lockObj)
        {
            Ocupado = false;
        }
    }
}
