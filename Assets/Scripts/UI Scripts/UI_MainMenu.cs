using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_MainMenu : MonoBehaviour
{
    private bool userPause;
    public TutorialManager tutorialManager; //definir la clase de la que necesito la variable
    public GameObject mainMenu;
    private void Start()
    {
        tutorialManager = FindObjectOfType<TutorialManager>();//instanciar?
    }
    void Update()
    {
        //Debug.Log(tutorialManager.isFirstGameplay);
        userPause = Input.GetKeyDown(KeyCode.Escape);
        if (userPause && !tutorialManager.isFirstGameplay)
        {
            PauseGame();
            mainMenu.SetActive(true);
        }
    }
    public void StartGame()
    {
        SceneManager.LoadScene("UI_Level1");
    }

    public void EndGame()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
    }
}
