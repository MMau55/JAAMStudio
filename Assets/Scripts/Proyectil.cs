using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proyectil : MonoBehaviour
{
    public float distanciaMaxima = 10f;
    public float velocidadProyectil = 10f;

    private Transform jugador;

    private void Start()
    {
        jugador = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void FixedUpdate()
    {
        // Mover el proyectil en su dirección
        transform.position += transform.forward * velocidadProyectil * Time.fixedDeltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        // Verificar si el proyectil ha colisionado con el jugador
        if (other.CompareTag("Player"))
        {
            Debug.Log("El proyectil ha golpeado al jugador");
            Destroy(gameObject);
        }
    }
}
