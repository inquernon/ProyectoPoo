using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GestorEnemigos : MonoBehaviour
{

    [SerializeField] private GameObject esqueletoPrefab;
    [SerializeField] private GameObject brujoPrefab;
    [SerializeField] private GameObject bossPrefab;
    [SerializeField] private int enemigosPorOleada = 5;
    [SerializeField] private float tiempoEntreOleadas = 5f;
    [SerializeField] private float tiempoEntreEnemigos = 3f;
    private List<Enemigo> enemigos = new List<Enemigo>();
    private int enemigoActualIndex = 0;
    private Vector3[] spawnPoints = new Vector3[] {
        new Vector3(-3, 0, 0),
        new Vector3(-2, 0, 0),
        new Vector3(0, 0, 0),
        new Vector3(2, 0, 0),
        new Vector3(4, 0, 0)
    };
    public int EnemigoActualIndex => enemigoActualIndex; // Propiedad para acceder al índice del enemigo actual
    public List<Enemigo> Enemigos => enemigos; // Propiedad para acceder a la lista de enemigos
    private void Start() {
        // Iniciar la primera oleada de enemigos
        StartCoroutine(SpawnOleada());
    }
    private IEnumerator SpawnOleada()
    {
        GameObject[] prefabsNormales = { esqueletoPrefab, brujoPrefab };

        for (int i = 0; i < enemigosPorOleada; i++)
        {
            int aleatorio = Random.Range(0, prefabsNormales.Length);
            Vector3 pos   = spawnPoints[i % spawnPoints.Length];

            SpawnEnemigo(prefabsNormales[aleatorio], pos);

            yield return new WaitForSeconds(tiempoEntreEnemigos);
        }
        // Después de la oleada, esperar un tiempo y luego iniciar  el boss
        Debug.Log("¡Oleada completada! Aparece el BOSS.");
        SpawnEnemigo(bossPrefab, new Vector3(0, 1, 0));
    }
    void SpawnEnemigo(GameObject prefab, Vector3 position) {
        var go = Instantiate(prefab, position, Quaternion.identity);
        var e = go.GetComponent<Enemigo>();
        if (e != null) {
            enemigos.Add(e);
            Debug.Log($"Enemigo {e.Nombre} ha aparecido en la posición {position}. Vida: {e.Vida}, Daño: {e.Danio}");
        }
    }

    private void MostrarEnemigos() {
        foreach (var enemigo in enemigos) {
            Debug.Log($"Enemigo: {enemigo.Nombre}, Vida: {enemigo.Vida}, Daño: {enemigo.Danio}");
        }
    }
    //llamar desde el menuSeleccion para atacar al enemigo seleccionado
    public void AtacarEnemigo(int danio)
    {
        enemigos.RemoveAll(e => e == null); // misma limpieza preventiva
        if(enemigos.Count == 0) return;
        // Ajustar índice por si quedó fuera de rango después de limpiar
        enemigoActualIndex = Mathf.Clamp(enemigoActualIndex, 0, enemigos.Count - 1);
        enemigos[enemigoActualIndex].RecibirDanio(danio); // Llama al método para que el enemigo reciba daño
    }

    public void SiguienteEnemigo()
    {
    // Limpia la lista antes de operar — elimina cualquier referencia a objetos destruidos
    enemigos.RemoveAll(e => e == null);
    
    if (enemigos.Count == 0) return; // no hay enemigos vivos, no hacer nada
        // Quitar highlight del enemigo anterior
        ActualizarHighlight(enemigoActualIndex, false);

        enemigoActualIndex = (enemigoActualIndex + 1) % enemigos.Count;

        // Poner highlight en el nuevo
        ActualizarHighlight(enemigoActualIndex, true);

        Debug.Log($"Enemigo objetivo: {enemigos[enemigoActualIndex].Nombre}");
    }
     private void ActualizarHighlight(int indice, bool seleccionado)
    {
        if (indice < 0 || indice >= enemigos.Count) return;
        var selector = enemigos[indice].GetComponent<SelectorEnemigo>();
        if (selector != null)
            selector.MarcarComoSeleccionado(seleccionado);
    }
    public void NotificarMuerte(Enemigo enemigo)
    {
        enemigos.Remove(enemigo);
        if (enemigos.Count > 0)
            enemigoActualIndex = enemigoActualIndex % enemigos.Count;
    }

}
