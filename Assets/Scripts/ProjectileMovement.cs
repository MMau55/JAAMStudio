using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ProjectileMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;

    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        DestroyBullet();

    }

    private void DestroyBullet() {
        Destroy(gameObject, 3);
    }

    private void OnTriggerEnter(Collider other)
    {
        DestroyBullet();
    }
}
