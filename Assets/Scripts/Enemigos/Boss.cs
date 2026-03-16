using UnityEngine;

public class Boss : Enemigo, IInteractuable, IGuardable
{
    public Boss(string nombre, int vida, int danio) : base(nombre, vida,danio)
    {
    }
    private void Awake()
    {
        nombre     = "Boss Final";
        vida       = 150;
        danio      = 10;
    }
    // Sobrescribimos el método Atacar para darle un comportamiento único al Boss
    public override void Atacar()
    {
        Debug.Log($"Boss Ataca con poderoso golpe. {danio}");
        transform.localScale = Vector3.one * 2f;
    }
// Sobrescribimos el método Morir para darle un comportamiento único al Boss
    public override void Morir()
    {
        Debug.Log("Boss ha sido derrotado.");
        transform.localScale = Vector3.zero;
    }
// Implementación de IInteractuable
    public void Interactuar()
    {
        Debug.Log("Boss: ¡No puedes detenerme!");
    }
// Implementación de IGuardable
    public void Guardar()
    {
        Debug.Log("Guardando estado del Boss...");
    }
// Implementación de IGuardable
    public void Cargar()
    {
        Debug.Log("Cargando estado del Boss...");
    }
}
