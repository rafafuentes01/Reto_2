using UnityEngine;

public class MoverBloque : MonoBehaviour
{
    public string tagObjetoMover = "Bloque";
    public float fuerza = 10f;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(tagObjetoMover))
        {
            Vector2 pushDirection = collision.gameObject.transform.position - transform.position;
            Rigidbody2D rigidbody = collision.gameObject.GetComponent<Rigidbody2D>();

            if (rigidbody != null)
            {
                rigidbody.AddForce(pushDirection * fuerza, ForceMode2D.Impulse);
            }
        }
    }
}
