using UnityEngine;

public class MoverBolaReiniciar : MonoBehaviour
{
    public float velocidadMovimiento = 5f;
    public float velocidadRotacion = 200f;
    public float tiempoParaReinicio = 5f;

    private Rigidbody2D rb;
    private bool moverDerecha = true;
    private Vector2 posicionInicial;
    private float tiempoTranscurrido = 0f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        posicionInicial = rb.position;
    }

    private void Update()
    {
        tiempoTranscurrido += Time.deltaTime;

        // Verificar si ha pasado el tiempo de reinicio
        if (tiempoTranscurrido >= tiempoParaReinicio)
        {
            ReiniciarBola();
        }

        // Movimiento horizontal
        float movimientoHorizontal = moverDerecha ? 1f : -1f;
        rb.velocity = new Vector2(movimientoHorizontal * velocidadMovimiento, rb.velocity.y);

        // Rotación
        float rotacion = -movimientoHorizontal * velocidadRotacion * Time.deltaTime;
        transform.Rotate(0f, 0f, rotacion);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Pared"))
        {
            moverDerecha = !moverDerecha;
        }
    }

    private void ReiniciarBola()
    {
        rb.position = posicionInicial;
        rb.velocity = Vector2.zero;
        tiempoTranscurrido = 0f;
    }
}
