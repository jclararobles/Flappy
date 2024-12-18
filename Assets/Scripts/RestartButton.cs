using UnityEngine;
using UnityEngine.UI;

public class RestartButton : MonoBehaviour
{
    public GameOverManager gameOverManager; // Referència al script GameOverManager

    void Start()
    {
        // Configura el botó per executar el mètode RestartGame() del script GameOverManager
        GetComponent<Button>().onClick.AddListener(gameOverManager.RestartGame);
    }
}
