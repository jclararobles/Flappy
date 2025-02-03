using UnityEngine;

public class ScoreTrigger : MonoBehaviour
{
    private bool hasScored = false; // Evita sumar més d'un punt

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !hasScored)
        {
            GameManager.instance.UpdateScore(1); // Suma un punt al GameManager
            hasScored = true;
        }
    }
}
