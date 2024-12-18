using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance; // Instància única del GameManager
    public TMP_Text scoreText;           // Text que mostra la puntuació
    public TMP_Text bestScoreText;       // Text que mostra la millor puntuació
    public GameObject pipeSpawnerPrefab; // Referència al prefab del generador de tubs
    public GameObject birdPrefab;        // Referència al prefab de l'ocella
    private int score = 0;               // Puntuació actual
    private int bestScore = 0;           // Millor puntuació guardada

    void Awake()
    {
        // Implementació del patró de disseny Singleton
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject); // Manté el GameManager entre escenes
    }

    void Start()
    {
        LoadBestScore(); // Carrega la millor puntuació al principi
        UpdateScore(0);  // Actualitza la puntuació inicial
    }

    // Mètode per actualitzar la puntuació
    public void UpdateScore(int points)
    {
        score += points;
        scoreText.text = "Score: " + score;  // Mostra la puntuació actual

        // Compara i actualitza la millor puntuació si és necessari
        if (score > bestScore)
        {
            bestScore = score;
            bestScoreText.text = "Best Score: " + bestScore; // Mostra la millor puntuació
            SaveBestScore(); // Guarda la millor puntuació
        }
    }

    // Mètode per guardar la millor puntuació
    private void SaveBestScore()
    {
        PlayerPrefs.SetInt("BestScore", bestScore);
    }

    // Mètode per carregar la millor puntuació
    public void LoadBestScore()
    {
        bestScore = PlayerPrefs.GetInt("BestScore", 0); // Carrega la millor puntuació
        bestScoreText.text = "Best Score: " + bestScore; // Mostra la millor puntuació
    }

    // Mètode per reiniciar el nivell
    public void RestartGame()
    {
        score = 0;
        UpdateScore(0); // Reinicia la puntuació

        // Reseteja els components del joc
        ResetBird();
        ResetPipeSpawner();

        // Carrega l'escena actual per reiniciar el nivell
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // Mètode per resetear l'ocella
    private void ResetBird()
    {
        BirdController bird = FindObjectOfType<BirdController>();
        if (bird != null)
        {
            bird.ResetBird(); // Resetegem l'estat de l'ocella
        }
    }

    // Mètode per resetear el generador de tubs
    private void ResetPipeSpawner()
    {
        PipeSpawner pipeSpawner = FindObjectOfType<PipeSpawner>();
        if (pipeSpawner != null)
        {
            pipeSpawner.ResetSpawner(); // Resetegem el generador de tubs
        }
    }

    // Mètode per mostrar la pantalla de Game Over
    public void ShowGameOver()
    {
        Time.timeScale = 0f; // Pausa el temps del joc
        GameObject.FindObjectOfType<GameOverManager>().ShowGameOver(); // Mostra el Game Over
    }
}
