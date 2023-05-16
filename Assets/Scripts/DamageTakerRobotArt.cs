using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DamageTakerRobotArt : MonoBehaviour
{
    public Image healthBar;
    public float health = 1, maxHealth = 1;
    public AudioClip audioColision;
    private void Start()
    {
        //health = health;
    }

    void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.name == "RobotBad")
        {
            //healthBarFiller();
            AudioSource.PlayClipAtPoint(audioColision, transform.position);
            takeDamage();
            healthBarFiller();

        }
    }

    private void healthBarFiller()
    {
        float damage = (1 / maxHealth);
        healthBar.fillAmount = healthBar.fillAmount - damage;
    }

    private void takeDamage()
    {
        if (health > 0)
        {
            health--;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
            SceneManager.LoadScene("DEFEAT");
        }
    }
}
