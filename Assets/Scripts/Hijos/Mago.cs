using UnityEngine;

public class Mago : Jugador
{
    public Sprite spriteMago;
    void Awake()
    {
        nombre = "Mago";
        vida = 80;
        danio = 35;
        if(spriteRenderer != null && spriteMago != null)
        {
            spriteRenderer.sprite = spriteMago;
        }
        Debug.Log(nombre + " ha sido seleccionado");
    }
    public override void Atacar()
    {
        Debug.Log(nombre + " lanza un hechizo, causando " + danio + " puntos de daño.");
        transform.localScale = Vector3.one * 1.2f; // Aumenta el tamaño del mago al atacar
    }
    
}
