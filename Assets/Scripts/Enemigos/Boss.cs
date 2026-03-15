using UnityEngine;

public class Boss : Enemigo, IInteractuable, IDaniable, IGuardable
{
    public Boss(string nombre, int vida, int danio) : base(nombre, vida,danio)
    {
    }
    public override void Atacar()
    {
        Debug.Log($"Boss Ataca con poderoso golpe. {danio}");
        transform.localScale = Vector3.one * 2f;
    }

    public override void Morir()
    {
        Debug.Log("Boss ha sido derrotado.");
        transform.localScale = Vector3.zero;
    }

    public void Interactuar()
    {
        Debug.Log("Boss: ¡No puedes detenerme!");
    }

    public void Guardar()
    {
        Debug.Log("Guardando estado del Boss...");
    }

    public void Cargar()
    {
        Debug.Log("Cargando estado del Boss...");
    }

    public void RecibirDanio(int cantidad)
    {
        Vida -= cantidad;
        Debug.Log($"Boss recibe {cantidad} de daño. Vida restante: {Vida}");
        if (Vida <= 0)
        {
            Morir();
        }
    }
}
