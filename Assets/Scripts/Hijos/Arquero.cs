using UnityEngine;

public class Arquero : Jugador
{
    public Sprite spriteArquero;
    void Awake()
    {
        nombre = "Arquero";
        vida = 100;
        danio = 25;
        if(spriteRenderer != null && spriteArquero != null)
        {
            spriteRenderer.sprite = spriteArquero;
        }
        Debug.Log(nombre + " ha sido seleccionado");
    }
    public override void Atacar()
    {
        Debug.Log(nombre + " dispara una flecha, causando " + danio + " puntos de daño.");
        transform.localScale = Vector3.one * 1.1f; // Aumenta el tamaño del arquero al atacar
    }
    
}
