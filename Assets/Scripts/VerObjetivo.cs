using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerObjetivo : MonoBehaviour
{
    public Camera camera; // Referencia a la cámara que deseas verificar
    public GameObject personajeBueno;
    public float maxDistance = 10f;
    public Transform objetivo; // Transform del objeto a seguir
    public float velocidad = 5f; // 
    public GameObject proyectilPrefab;
    public float velocidadSeguimiento = 5f; // La velocidad de seguimiento del objeto
    public float fuerzaDisparo = 10f; // La fuerza con la que se dispara el proyectil
    private Rigidbody rb; // Referencia al componente Rigidbody del proyectil

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {



        // Verificar si la cámara ve el objeto
        Vector3 objectViewportPosition = camera.WorldToViewportPoint(personajeBueno.transform.position);
        bool isObjectVisible = objectViewportPosition.x >= 0 && objectViewportPosition.x <= 1 &&
                               objectViewportPosition.y >= 0 && objectViewportPosition.y <= 1 &&
                               objectViewportPosition.z > 0;

        if (isObjectVisible)
        {
            // Realizar un raycast desde la cámara hacia el objeto PersonajeBueno
            RaycastHit hit;

            if (Physics.Raycast(camera.transform.position, personajeBueno.transform.position - camera.transform.position, out hit, maxDistance))
            {
                if (hit.collider.gameObject.name != "Cube (2)")
                {
                    message(1);
                }
                else
                {
                    // El objeto PersonajeBueno no está obstruido
                    message(0);
                }

            }
            else
            {
                // El objeto PersonajeBueno no está obstruido
                message(0);
            }
        }

    }

    void message(int isObs)
    {
        if (isObs == 1)
        {
            // El objeto PersonajeBueno está obstruido por otro objeto
            Debug.Log("El objeto PersonajeBueno está obstruido por: ");
        }
        else
        {
            // El objeto PersonajeBueno no está obstruido
            Debug.Log("El objeto PersonajeBueno no está obstruido.");
            perseguir();
        }
    }

    void perseguir()
    {
        Vector3 posicionObjetivo = objetivo.position;
        Vector3 direccion = posicionObjetivo - transform.position;

        // Rotar la cámara hacia la dirección del objeto que se va a seguir
        transform.rotation = Quaternion.LookRotation(direccion);

        // Calcular la velocidad de movimiento
        float velocidadMovimiento = Mathf.Min(velocidad * Time.deltaTime, Vector3.Distance(transform.position, posicionObjetivo));

        // Mover gradualmente el objeto perseguidor hacia la posición objetivo
        transform.position = Vector3.MoveTowards(transform.position, posicionObjetivo, velocidadMovimiento);


    }



}