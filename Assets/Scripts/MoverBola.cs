using UnityEngine;

public class MoverBola : MonoBehaviour
{
    public float velocidadMovimiento = 5f;
    public float velocidadRotacion = 200f;

    private Rigidbody2D rb;
    private bool moverDerecha = true;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
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
}