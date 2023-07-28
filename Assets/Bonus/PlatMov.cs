using UnityEngine;

public class PlatMove : MonoBehaviour
{
    private bool characterOnPlatform;
    private float fallTimer;
    private bool platformFalling;
    private float respawnTimer;
    private Vector3 initialPosition;

    private void Start()
    {
        characterOnPlatform = false;
        fallTimer = 0f;
        platformFalling = false;
        respawnTimer = 0f;
        initialPosition = transform.position;
    }

    private void Update()
    {
        if (characterOnPlatform && !platformFalling)
        {
            fallTimer += Time.deltaTime;
            if (fallTimer >= 2f)
            {
                platformFalling = true;
                fallTimer = 0f;
            }
        }

        if (platformFalling)
        {
            // Aquí puedes implementar la lógica para hacer que la plataforma caiga
            // por ejemplo, cambiando la posición o aplicando fuerzas al objeto.

            fallTimer += Time.deltaTime;
            if (fallTimer >= 2f)
            {
                platformFalling = false;
                fallTimer = 0f;
                respawnTimer = 0f;
            }
        }

        if (!platformFalling)
        {
            respawnTimer += Time.deltaTime;
            if (respawnTimer >= 10f)
            {
                // Aquí puedes implementar la lógica para hacer que la plataforma vuelva a aparecer
                // por ejemplo, restaurando la posición inicial o reactivando el objeto.
                transform.position = initialPosition;
                respawnTimer = 0f;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            characterOnPlatform = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            characterOnPlatform = false;
        }
    }
}
