using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerControllerTesting : MonoBehaviour
{
    public float speed = 5f;
    public float mouseSensitivity = 100f;
    private CharacterController controller;
    private float verticalRotation = 0f;

    public bool canMove = true;

    public int maxHealth = 3;
    public string enemyTag = "Enemy";

    private int currentHealth;
    private bool invincible = false;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        //Cursor.lockState = CursorLockMode.Locked;

        currentHealth = maxHealth;

    }

    void Update()
    {
            bool upMovementKey = Input.GetKey(KeyCode.Q);
            bool downMovementKey = Input.GetKey(KeyCode.E);

            MoveAround();
            MoveUpAndDown(upMovementKey, downMovementKey);
    }

    void MoveAround()
    {
        
        float horizontal = Input.GetAxis("Horizontal") * speed;
        float vertical = Input.GetAxis("Vertical") * speed;
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        verticalRotation -= mouseY;
        verticalRotation = Mathf.Clamp(verticalRotation, -90f, 90f);

        transform.Rotate(Vector3.up * mouseX);
        Camera.main.transform.localRotation = Quaternion.Euler(verticalRotation, 0f, 0f);

        Vector3 move = transform.forward * vertical + transform.right * horizontal;
        if (controller.enabled) // verificar si el controlador está habilitado
        {
            controller.Move(move * Time.deltaTime);
        }
    }

    void MoveUpAndDown(bool up, bool down)
    {
        if (up && transform.position.y <= 2)
        {
            transform.Translate(Vector3.up * speed * Time.deltaTime);
        }
        if(down && transform.position.y >= 1.3)
        {
            transform.Translate(Vector3.up * -speed * Time.deltaTime);
        }
        
    }

    void OnCollisionEnter(Collision collision)
    {
        if (!invincible && collision.collider.CompareTag(enemyTag))
        {
            if (gameObject.CompareTag("Player1"))
            {
                currentHealth--;
                Debug.Log("Player1 was hit! Health: " + currentHealth);
                if (currentHealth <= 0)
                {
                    Debug.Log("Player1 has been defeated!");
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                }
            }
            else if (gameObject.CompareTag("Player2"))
            {
                currentHealth = 0;
                Debug.Log("Player2 was hit! Health: " + currentHealth);
                Debug.Log("Player2 has been defeated!");
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
            StartCoroutine(InvincibilityFrames());
        }
    }

    IEnumerator InvincibilityFrames()
    {
        invincible = true;
        yield return new WaitForSeconds(1f);
        invincible = false;
    }

}


