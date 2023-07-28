using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Contador : MonoBehaviour
{
    public float countdownTime = 10f;  // Tiempo inicial del contador
    public TMP_Text countdownText;  // Referencia al objeto Text que mostrará el contador
    public GameObject panel;  // Referencia al panel que se mostrará cuando el contador llegue a cero
    public float panelDisplayTime = 5f;  // Tiempo de visualización del panel


    private float currentTime;

    private void Start()
    {
        currentTime = countdownTime;
        UpdateCountdownText();
    }

    private void Update()
    {
            currentTime -= Time.deltaTime;
            UpdateCountdownText();

            if (currentTime <= 0f)
            {
                ShowPanel();
                Invoke(nameof(RestartLevel), panelDisplayTime);
            }
        
    }

    private void UpdateCountdownText()
    {
        countdownText.text = "Tiempo " + currentTime.ToString("F0");
    }

    private void ShowPanel()
    {
        panel.SetActive(true);
        
    }
    private void RestartLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
}
