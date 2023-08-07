using UnityEngine;

public class CaerObjeto : MonoBehaviour
{
    public float Tiempo = 5f;
    private Rigidbody2D rb;
    private Vector3 startPosition;
    private bool isFalling = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        startPosition = transform.position;
        Invoke("StartFalling", Tiempo); // Inicia la caída después de 10 segundos
    }

    private void Update()
    {
        if (isFalling)
        {
            // Si el elemento ha caído por debajo de cierta posición, reinicia su posición
            if (transform.position.y < -7f)
            {
                ResetElement();
            }
        }
    }

    private void StartFalling()
    {
        isFalling = true;
        rb.bodyType = RigidbodyType2D.Dynamic; // Permite que el elemento caiga con la gravedad
    }

    private void ResetElement()
    {
        isFalling = false;
        rb.velocity = Vector2.zero;
        transform.position = startPosition; // Reinicia la posición del elemento
        Invoke("StartFalling", Tiempo); // Inicia la caída después de 10 segundos
    }
}
