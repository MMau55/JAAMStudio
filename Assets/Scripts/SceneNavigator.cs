using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneNavigator : MonoBehaviour
{
    public void goToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void goToLevel()
    {
        SceneManager.LoadScene("Level 1");
    }

    public void goToDefeatScreen()
    {
        SceneManager.LoadScene("DEFEAT");
    }

    public void goToVictoryScreen()
    {
        SceneManager.LoadScene("VICTORY");
    }
}
