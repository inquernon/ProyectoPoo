using UnityEngine;

public class Brujo : Enemigo, IInteractuable, IGuardable
{
    public Brujo(string nombre, int vida, int danio) : base(nombre, vida, danio)
    {
    }

    public override void Atacar()
    {
        Debug.Log($"{Nombre} lanza un hechizo.");
    }

    public void Interactuar()
    {
        Debug.Log($"Interactuando con {Nombre}. Es un brujo que parece estar tramando algo.");
    }
    public void Guardar()
    {
        Debug.Log($"Guardando el estado de {Nombre}.");
    }
    public void Cargar()
    {
        Debug.Log($"Cargando el estado de {Nombre}.");
    }
}
