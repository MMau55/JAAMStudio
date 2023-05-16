using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSwitcher : MonoBehaviour
{
    public List<GameObject> characters;
    public List<GameObject> cameras;
    private int currentIndex = 0;

    void Start()
    {
        if (characters.Count == 0 || cameras.Count == 0)
        {
            Debug.LogError("No hay personajes o c�maras asignados");
        }

        // Activar el primer personaje y su respectiva c�mara
        characters[currentIndex].SetActive(true);
        cameras[currentIndex].SetActive(true);
    }

    void Update()
    {
        // Verificar si se presiona la tecla para cambiar de personaje
        if (Input.GetKeyDown(KeyCode.F))
        {
            /*// Desactivar el personaje y c�mara actual
            characters[currentIndex].SetActive(false);
            cameras[currentIndex].SetActive(false);

            // Incrementar el �ndice del personaje actual, o volver a cero si llegamos al final
            currentIndex++;
            if (currentIndex >= characters.Count)
            {
                currentIndex = 0;
            }

            // Activar el nuevo personaje y su respectiva c�mara
            characters[currentIndex].SetActive(true);
            cameras[currentIndex].SetActive(true);*/

            // Desactivar el controlador de personaje y c�mara actual
            var currentCharacter = characters[currentIndex];
            var currentCamera = cameras[currentIndex];

            var characterController = currentCharacter.GetComponent<CharacterController>();
            if (characterController != null)
            {
                characterController.enabled = false;
            }

            currentCamera.SetActive(false);

            // Incrementar el �ndice del personaje actual, o volver a cero si llegamos al final
            currentIndex++;
            if (currentIndex >= characters.Count)
            {
                currentIndex = 0;
            }

            // Activar el nuevo personaje y su respectiva c�mara
            var newCharacter = characters[currentIndex];
            var newCamera = cameras[currentIndex];

            characterController = newCharacter.GetComponent<CharacterController>();
            if (characterController != null)
            {
                characterController.enabled = true;
            }

            newCamera.SetActive(true);
        }
    }
}