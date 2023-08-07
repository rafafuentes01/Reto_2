using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Transform player;
    public float speed = 3f;
    public float offsetDistance = 2f;

    private void Start()
    {
        // Obtener la referencia al transform del jugador
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        // Calcular la direcci�n hacia la posici�n del jugador
        Vector3 direction = player.position - transform.position;
        direction.Normalize();

        // Calcular la posici�n objetivo con el offset de movimiento
        Vector3 targetPosition = player.position - (direction * offsetDistance);

        // Calcular el desplazamiento hacia la posici�n objetivo
        Vector3 displacement = (targetPosition - transform.position).normalized * speed * Time.deltaTime;

        // Comprobar si el enemigo ha llegado a la posici�n objetivo
        if (displacement.magnitude < (targetPosition - transform.position).magnitude)
        {
            // Mover al enemigo hacia la posici�n objetivo
            transform.position += displacement;
        }
    }
}
