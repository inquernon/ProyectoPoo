
using UnityEngine;

public class MenuSeleccion : MonoBehaviour
{
    [SerializeField] private GameObject guerreroPrefab;
    [SerializeField] private GameObject magoPrefab;
    [SerializeField] private GameObject arqueroPrefab;

    public GestorEnemigos gestor;

    public Vector3 spawnPosition = new Vector3(0, 0, 0);

    private GameObject personajeActual;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SeleccionarPersonaje(guerreroPrefab);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SeleccionarPersonaje(magoPrefab);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SeleccionarPersonaje(arqueroPrefab);
        }

        if (Input.GetKeyDown(KeyCode.Space) && personajeActual != null)
        {
            Jugador jugador = personajeActual.GetComponent<Jugador>();
            if (jugador != null)
            {
                jugador.Atacar();
            }
        }

        if(Input.GetKeyDown(KeyCode.E) && gestor != null && personajeActual != null)
        {
            Jugador j = personajeActual.GetComponent<Jugador>(); // Obtiene el componente Jugador del personaje actual
            if(j != null)            {
                j.Atacar();// Llama al método para que el jugador ataque
                gestor.AtacarEnemigo(j.Danio); // Llama al método para atacar al enemigo actual con el daño del jugador
            }
        }
        if(Input.GetKeyDown(KeyCode.Tab) && gestor != null)
        {
            gestor.SiguienteEnemigo(); // Cambia al siguiente enemigo
            int idx = gestor.EnemigoActualIndex; // Obtiene el índice del enemigo actual
            Debug.Log($"Enemigo seleccionado: {gestor.Enemigos[idx].Nombre} Presiona E para atacar al nuevo enemigo.");
        }
    }

    
    void SeleccionarPersonaje(GameObject prefab)
    {
        if (personajeActual != null)
        {
            Destroy(personajeActual);
        }
        personajeActual = Instantiate(prefab, spawnPosition, Quaternion.identity);
        Debug.Log("Personaje seleccionado: " + personajeActual.name+". Presiona espacio para atacar.");
    }

}
