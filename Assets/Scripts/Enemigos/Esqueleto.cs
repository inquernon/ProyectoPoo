using UnityEngine;

public class Esqueleto : Enemigo, IInteractuable
{
    public Esqueleto(string nombre, int vida, int danio) : base(nombre, vida, danio)
    {
    }

    public override void Atacar()
    {
        Debug.Log($"{Nombre} ataca con su espada.");
    }

    public void Interactuar()
    {
        Debug.Log($"Interactuando con {Nombre}. Es un esqueleto que parece estar buscando algo.");
    }
}
