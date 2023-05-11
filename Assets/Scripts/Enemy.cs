using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public float rango;
    public LayerMask layerjugador;
    public Transform jugador;
    public float velocidadM;
    public bool alerta;

    private bool hayObstaculo;

    private List<Transform> listaWaypoints = new List<Transform>();
    private int indiceWaypointActual = 0;

    void Start()
    {
        GameObject[] waypoints = GameObject.FindGameObjectsWithTag("Waypoint");
        foreach (GameObject waypoint in waypoints)
        {
            listaWaypoints.Add(waypoint.transform);
        }
    }

    private void OnDrawGizmosSelected()
    {
        // Dibuja una esfera de color rojo en la posición del enemigo para indicar su posición y rango
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, rango);
    }

    void Update()
    {

        Vector3 PosicionJugador = new Vector3(jugador.position.x, transform.position.y, jugador.position.z);
        RaycastHit hit;
        Vector3 direccion = jugador.position - transform.position;

        alerta = Physics.CheckSphere(transform.position, rango, layerjugador);

        if (Physics.Raycast(transform.position, direccion, out hit, rango, layerjugador))
        {
            if (hit.collider.gameObject.CompareTag("Pared"))
            {
                hayObstaculo = true;
            }
            else
            {
                hayObstaculo = false;
            }
        }
        else
        {
            hayObstaculo = false;
        }

        alerta = !hayObstaculo && Physics.CheckSphere(transform.position, rango, layerjugador);

        if (alerta)
        {
            // Si no hay obstáculo, seguimos al jugador
            if (!hayObstaculo)
            {
                transform.LookAt(PosicionJugador);
                transform.position = Vector3.MoveTowards(transform.position, PosicionJugador, velocidadM * Time.deltaTime);
            }
        }
        else
        {
            if (Vector3.Distance(transform.position, listaWaypoints[indiceWaypointActual].position) < 0.1f)
            {
                // Avanza al siguiente waypoint en la lista de waypoints
                indiceWaypointActual++;
                // Si se llegó al final de la lista de waypoints, vuelve al principio
                if (indiceWaypointActual >= listaWaypoints.Count)
                {
                    indiceWaypointActual = 0;
                }
            }

            // Mueve el enemigo hacia el waypoint actual
            transform.position = Vector3.MoveTowards(transform.position, listaWaypoints[indiceWaypointActual].position, velocidadM * Time.deltaTime);
            // Apunta hacia el waypoint actual
            transform.LookAt(listaWaypoints[indiceWaypointActual]);
        }
    }
}