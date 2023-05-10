using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotController : MonoBehaviour
{
    // Private variable
    private float speed = 7.0f;
    private float turnSpeed = 7.0f;
    private float horizontalInput;
    private float forwardInput;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // This is where we get player input
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");

        //Move the Robot forward
        transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);
        //  Turn Rotate Robot
        transform.Rotate(Vector3.up, Time.deltaTime * turnSpeed * horizontalInput);
        // Move the Robot Right and Left
        //transform.Translate(Vector3.right * Time.deltaTime * turnSpeed * horizontalInput);
    }
}
