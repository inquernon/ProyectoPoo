
using UnityEngine;

public class Jugador : MonoBehaviour
{
    protected string nombre;
    protected int vida = 100;
    protected int danio = 10;

    public SpriteRenderer spriteRenderer;

    void Start() {
        Debug.Log(nombre + " ha sido seleccionado");
    }

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
