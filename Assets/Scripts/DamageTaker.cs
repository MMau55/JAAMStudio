using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageTaker : MonoBehaviour
{
    public Image healthBar;
    public float health, maxHealth = 3;
    private void Start()
    {
        health = 3;
    }

    void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
        if (other.gameObject.name == "ray")
        {
            healthBarFiller();
            takeDamage();
        } 
    }

    private void healthBarFiller()
    {
        healthBar.fillAmount = healthBar.fillAmount - 0.33331f;
    }

    private void takeDamage()
    {
        if(health > 0)
        {
            health--;
        }
        else
        {
            GameObject Robot = transform.parent.gameObject;
            Destroy(Robot);
        }
    }
}
