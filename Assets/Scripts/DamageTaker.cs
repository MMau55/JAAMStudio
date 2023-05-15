using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageTaker : MonoBehaviour
{
    public Image healthBar;
    public float health, maxHealth = 3;
    public float lerpSpeed;
    public float lerpDuration;
    private void Start()
    {
        health = 3;
        lerpSpeed = 3f*Time.deltaTime;
        lerpDuration = 2;
    }
    private void Update()
    {
        //
    }

    void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
        if (other.gameObject.name == "ray")
        {
            healthBarFiller();
            //StartCoroutine(healthBarFiller());
            takeDamage();

            if (health <= 0)
            {
                GameObject Robot = transform.parent.gameObject;
                Destroy(Robot);
            }
            
            //Debug.Log("Recibe daño de: "+other.gameObject.name);
        } 
    }

    /*IEnumerator healthBarFiller()
    {
        //healthBar.fillAmount = healthBar.fillAmount - 0.33331f;
        //healthBar.fillAmount -= 0.34f;
        float timeElapsed = 0f;

        while (timeElapsed < lerpDuration)
        {
            healthBar.fillAmount = Mathf.Lerp(healthBar.fillAmount, 0.33331f/lerpDuration, lerpDuration);
            timeElapsed += Time.deltaTime;
            yield return null;  
        }
        //healthBar.fillAmount = healthBarChange;

    }*/

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
    }
}
