using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ContarObjetos : MonoBehaviour
{
    public GameObject panel;
    public float delay = 3f;
    public string nextLevel;

    private int totalObjectsToCollect;
    private int collectedObjects = 0;
    private bool levelComplete = false;

    private void Start()
    {
        // Desactivar el panel al inicio
        panel.SetActive(false);

        // Obtener la cantidad total de objetos a recolectar
        totalObjectsToCollect = GameObject.FindGameObjectsWithTag("Elemento").Length;
    }

    private void Update()
    {
        if (levelComplete)
            return;

        // Si se han recolectado todos los objetos, activar el panel y cargar el siguiente nivel después del retraso
        if (collectedObjects >= totalObjectsToCollect)
        {
            levelComplete = true;
            panel.SetActive(true);
            Invoke("LoadNextLevel", delay);
        }
    }

    private void LoadNextLevel()
    {
        SceneManager.LoadScene(nextLevel);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Evento detectado con: " + other.gameObject.name);
        if (other.gameObject.CompareTag("Elemento"))
        {
            other.gameObject.SetActive(false); // Desactivar el objeto recolectado
            collectedObjects++;
        }
    }
}
