using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DamageTakerRobotArt : MonoBehaviour
{
    public Image healthBar;
    public float health, maxHealth = 3;
    public AudioClip audioColision;
    private void Start()
    {
        health = 3;
    }

    void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.name == "RobotBad")
        {
            //healthBarFiller();
            AudioSource.PlayClipAtPoint(audioColision, transform.position);
            takeDamage();

        }
    }

    private void healthBarFiller()
    {
        // healthBar.fillAmount = healthBar.fillAmount - 0.33331f;
    }

    private void takeDamage()
    {
        if (health > 0)
        {
            health--;
        }
        else
        {
            SceneManager.LoadScene("DEFEAT");
        }
    }
}
