
using UnityEngine;

public class Jugador : MonoBehaviour
{
    protected string nombre;
    protected int vida = 100;
    protected int danio = 10;

    public SpriteRenderer spriteRenderer;

    public int Vida { get => vida; set => vida = Mathf.Clamp(value, 0, 100); }
    public int Danio { get => danio; set => danio = value > 0 ? value : 5; }

    public virtual void Atacar()
    {
        Debug.Log(nombre + " ataca con un daño de " + danio);
    }

    public void RecibirDanio(int cantidad)
    {
        vida -= cantidad;
        Debug.Log(nombre + " recibe " + cantidad + " puntos de daño. Vida restante: " + vida);
    }
}
