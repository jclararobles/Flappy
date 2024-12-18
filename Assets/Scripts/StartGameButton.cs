using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro; // Afegeix aquesta línia per permetre l'ús de TMP_Text

public class StartGameButton : MonoBehaviour
{
    public TMP_Text startButtonText; // Referència al component TMP_Text del botó

    // Això es pot fer a l'editor de Unity
    public void OnStartGameButtonClick()
    {
        startButtonText.text = "Iniciant..."; // Canvia el text del botó
        SceneManager.LoadScene("GameScene"); // Carrega l'escena del joc
    }
}
