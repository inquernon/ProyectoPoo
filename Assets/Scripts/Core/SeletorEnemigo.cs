using UnityEngine;

public class SelectorEnemigo : MonoBehaviour
{
    [SerializeField] private Color colorSeleccionado = Color.yellow;  // Cambiable desde el Inspector
    [SerializeField] private Color colorNormal       = Color.white;
    private SpriteRenderer sr;

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    public void MarcarComoSeleccionado(bool seleccionado)
    {
        if (sr != null && seleccionado)
        {
            sr.color = colorSeleccionado;
        }
        else
        {
            sr.color = colorNormal;
        }
    }
}
