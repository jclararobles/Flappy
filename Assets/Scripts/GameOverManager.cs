using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOverManager : MonoBehaviour
{
    public TMP_Text gameOverText; // Text de Game Over
    public TMP_Text pressText;    // Text de "Prem qualsevol tecla"
    public GameObject pipePrefab; // Referència al prefab dels tubs
    public GameObject restartButton; // Referència al botó de reiniciar
    private PipeSpawner pipeSpawner; // Referència al PipeSpawner
    private bool isGameOver = false;

    void Start()
    {
        pipeSpawner = FindObjectOfType<PipeSpawner>(); // Troba el PipeSpawner a l'escena
        CreatePipes(); // Crea els tubs inicials al principi

        // Inicialment amaga els texts i el botó de reiniciar
        gameOverText.gameObject.SetActive(false);
        pressText.gameObject.SetActive(false);
        restartButton.gameObject.SetActive(false);

        // Afegeix l'esdeveniment OnClick per al botó de reiniciar
        restartButton.GetComponent<UnityEngine.UI.Button>().onClick.AddListener(RestartGame);
    }

    // Mètode per mostrar els missatges de Game Over
    public void ShowGameOver()
    {
        isGameOver = true; // Marca el joc com a finalitzat
        Time.timeScale = 0f; // Pausa el temps del joc
        gameOverText.gameObject.SetActive(true); // Mostra el missatge de Game Over
        pressText.gameObject.SetActive(true);    // Mostra el missatge de "Prem"
        restartButton.gameObject.SetActive(true); // Mostra el botó de reiniciar
    }

    // Mètode per reiniciar la partida
    public void RestartGame()
    {
        Time.timeScale = 1f; // Restaura el temps del joc

        // Neteja l'estat del joc
        isGameOver = false;
        gameOverText.gameObject.SetActive(false);
        pressText.gameObject.SetActive(false);
        restartButton.gameObject.SetActive(false);

        // Reseteja els components del joc
        ResetGame();

        // Carrega l'escena actual per reiniciar el nivell des de zero
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // Mètode per crear els tubs inicials quan comença el joc
    private void CreatePipes()
    {
        if (pipePrefab != null && pipeSpawner != null)
        {
            pipeSpawner.SpawnPipe(); // Crida a SpawnPipe() aquí
        }
    }

    // Mètode per resetear els estats del joc
    private void ResetGame()
    {
        // Reseteja qualsevol altre estat rellevant
        // Exemple: puntuació, vides, etc.
        // En aquest cas, com no hi ha un GameManager, simplement reinicia els tubs
        pipeSpawner.ResetSpawner();
        BirdController bird = FindObjectOfType<BirdController>();
        if (bird != null)
        {
            bird.ResetBird(); // Reestableix l'estat de l'ocella
        }
    }
}
