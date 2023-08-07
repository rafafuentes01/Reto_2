using UnityEngine;

public class PlatCaida : MonoBehaviour
{
    public float fallDelay = 2f;
    public float respawnDelay = 10f;

    private Rigidbody2D rb;
    private Vector2 originalPosition;
    private bool isPlayerOnPlatform;
    private bool isPlatformFalling;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        originalPosition = transform.position;
    }

    private void Update()
    {
        if (isPlayerOnPlatform && !isPlatformFalling)
        {
            Invoke("FallPlatform", fallDelay);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isPlayerOnPlatform = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isPlayerOnPlatform = false;
        }
    }

    private void FallPlatform()
    {
        isPlatformFalling = true;
        rb.bodyType = RigidbodyType2D.Dynamic;
        Invoke("RespawnPlatform", respawnDelay);
    }

    private void RespawnPlatform()
    {
        isPlatformFalling = false;
        rb.bodyType = RigidbodyType2D.Static;
        rb.velocity = Vector2.zero;
        transform.position = originalPosition;
    }
}
