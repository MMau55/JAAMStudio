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
    //public GameObject camera; //debido a la forma en la que estamos manejando el movimiento del jugador, debemos tener una camara exclusiva para los menús, esta lógica debería ir en una manager aparte, pero esta es la solución más rapida por ahora.
    private void Start()
    {
        tutorialManager = FindObjectOfType<TutorialManager>();//instanciar?
    }
    void Update()
    {
        //Debug.Log(tutorialManager.isFirstGameplay);
        userPause = Input.GetKeyDown(KeyCode.Escape);
       // if (userPause && !tutorialManager.isFirstGameplay)
       if(userPause && !tutorialManager.isFirstGameplay)
        {
            PauseGame();
        }
    }
    public void StartGame()
    {
        SceneManager.LoadScene("Level 1");
    }

    public void EndGame()
    {
        Cursor.lockState = CursorLockMode.None;
        SceneManager.LoadScene("MainMenu");
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        mainMenu.SetActive(true);
        tutorialManager.camera.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        tutorialManager.camera.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
    }
}
