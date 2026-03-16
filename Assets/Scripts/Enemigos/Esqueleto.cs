using UnityEngine;

public class Esqueleto : Enemigo, IInteractuable
{
    public Esqueleto(string nombre, int vida, int danio) : base(nombre, vida, danio)
    {
    }
private void Awake()
    {
        nombre     = "Esqueleto Guerrero";
        vida       = 90;
        danio      = 10;
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
