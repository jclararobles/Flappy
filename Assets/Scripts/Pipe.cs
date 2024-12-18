using UnityEngine;

public class Pipe : MonoBehaviour
{
    public float moveSpeed = 2f; // Velocitat de moviment dels tubs
    public bool stopMovement = false; // Bandera global per aturar el moviment
    public GameManager gameManager; // Referència al GameManager per sumar punts

    private bool hasScored = false; // Verificar si el punt ja ha estat sumat

    void Update()
    {
        if (stopMovement)
            return; // Si el moviment està aturat, no fem res

        // Mou el tub cap a l'esquerra
        transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);

        // Destrueix el tub si surt de la pantalla
        if (transform.position.x < -10f) // Ajusta segons la mida de la teva pantalla
        {
            Destroy(gameObject);
        }
    }

    // Detecta quan el pàjaro passa per l'àrea entre els tubs (el trigger)
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Si el pàjaro (o un altre objecte) entra en el trigger
        if (other.CompareTag("Player") && !hasScored)
        {
            gameManager.UpdateScore(1); // Suma un punt al GameManager
            hasScored = true; // Evita sumar el punt més d'una vegada
        }
    }

    // Mètode estàtic per aturar el moviment dels tubs
    public void StopPipes()
    {
        stopMovement = true;
    }
}
