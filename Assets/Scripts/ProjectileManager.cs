using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject projectile;
    public GameObject player;
    public float projectileSpeed;
    public Vector3 offset = new Vector3(0f, 1.5f, 0f);

    private void Update()
    {
        ShootBeam();
    }
    private void ShootBeam()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject newProjectile = Instantiate(projectile,player.transform.position + offset, player.transform.rotation);
            //OnTriggerEnter(newProjectile other);
        }
        
    }  
}
