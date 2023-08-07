using UnityEngine;

public class BoladeFuego : MonoBehaviour
{
    public float verticalSpeed = 2.0f; // Velocidad vertical de la bola de fuego
    public float movementRange = 2.0f; // Distancia vertical m�xima que recorre la bola de fuego

    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        // Calcula la nueva posici�n vertical utilizando Mathf.PingPong
        float newY = startPosition.y + Mathf.PingPong(Time.time * verticalSpeed, movementRange * 2) - movementRange;

        // Actualiza la posici�n de la bola de fuego
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }
}
