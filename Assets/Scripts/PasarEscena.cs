using UnityEngine;
using UnityEngine.SceneManagement;

public class PasarEscena : MonoBehaviour
{
    public string nombreEscenaSiguiente;
    public float tiempo = 5f;

    private void Start()
    {
        // Invocamos el método para cambiar de escena después del tiempo especificado
        Invoke("CambiarEscena", tiempo);
    }

    private void CambiarEscena()
    {
        // Cargamos la siguiente escena por nombre
        SceneManager.LoadScene(nombreEscenaSiguiente);
    }
}
