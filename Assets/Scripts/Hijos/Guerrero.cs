
using UnityEngine;

public class Guerrero : Jugador
{
    public Sprite spriteGuerrero;
    void Awake()
    {
        nombre = "Guerrero";
        vida = 150;
        danio = 20;
        if(spriteRenderer != null && spriteGuerrero != null)
        {
            spriteRenderer.sprite = spriteGuerrero;
        }
        Debug.Log(nombre + " ha sido seleccionado");
    }
    public override void Atacar()
    {
        Debug.Log(nombre + " ataca con una espada, causando " + danio + " puntos de daño.");
        transform.localScale = Vector3.one * 1.3f; // Aumenta el tamaño del guerrero al atacar
    }
}
