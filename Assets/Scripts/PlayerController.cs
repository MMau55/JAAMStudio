using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject proyectilePrefab;
    private float speed = 10f;
    private float Rspeed = 50f;
    public float turnSpeed = 10f;
    public float velocidadGiro = 100f;
    public float horizontalInput;
    public float verticalInput;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed * verticalInput);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed * verticalInput);
        }

        if (Input.GetKey(KeyCode.A))
        {

            transform.Translate(Vector3.right * Time.deltaTime * speed * horizontalInput);
        }
        if (Input.GetKey(KeyCode.D))
        {

            transform.Translate(Vector3.right * Time.deltaTime * speed * horizontalInput);
        }


    }
}