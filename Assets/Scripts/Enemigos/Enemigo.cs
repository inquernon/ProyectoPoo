
using UnityEngine;

public abstract class Enemigo : MonoBehaviour, IDaniable
{
    protected string nombre;
    protected int vida;
    protected int danio;
    private GestorEnemigos gestor;

    public Enemigo(string nombre, int vida, int danio)
    {
        this.Nombre = nombre;
        this.Vida = vida;
        this.Danio = danio;
    }
    void Awake() {
        gestor = FindObjectOfType<GestorEnemigos>();
    }
    public string Nombre { get => nombre; set => nombre = value; }
    public int Vida { get => vida; set => vida = Mathf.Clamp(value, 0, 100); }
    public int Danio { get => danio; set => danio =value>0?value:1; }

    //interfaz IDaniable
    public void RecibirDanio(int cantidad)
    {
        if (cantidad > 0)
        {
            Vida -= cantidad;
            Debug.Log($"{Nombre} ha recibido {cantidad} de daño. Vida restante: {Vida}");
            if (Vida <= 0)
            {
                Morir();
            }
        }        
    }

    //metodo abstracto para Atacar, que cada enemigo implementará a su manera
    public abstract void Atacar();

    //metodo para morir, que puede ser sobreescrito por cada enemigo si se desea
    public virtual void Morir()
    {
        Debug.Log($"{Nombre} ha muerto.");
        gestor?.NotificarMuerte(this);
        Destroy(gameObject);
    }
}
