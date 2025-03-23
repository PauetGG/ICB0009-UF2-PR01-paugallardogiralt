using System;

//Class paciente con su atributo numero que funciona como ID.
class Paciente
{
    public int Numero { get; }
    public Paciente(int numero) => Numero = numero;
}