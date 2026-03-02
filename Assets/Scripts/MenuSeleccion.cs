using UnityEngine;

public class MenuSeleccion : MonoBehaviour
{
    [SerializeField] private GameObject guerreroPrefab;
    [SerializeField] private GameObject magoPrefab;
    [SerializeField] private GameObject arqueroPrefab;

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
