using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*public class Enemy : MonoBehaviour
{

    public float rango = 100f;
    public LayerMask layerjugador;
    public Transform jugador;
    public float velocidadM;
    public bool alerta;
    public bool enMovimiento;

    private bool hayObstaculo;
    private bool seguirJugador;

    private List<Transform> listaWaypoints = new List<Transform>();
    private int indiceWaypointActual = 0;

    void Start()
    {
        GameObject[] waypoints = GameObject.FindGameObjectsWithTag("Waypoint");
        foreach (GameObject waypoint in waypoints)
        {
            listaWaypoints.Add(waypoint.transform);
        }

        // Inicialmente, el enemigo no está siguiendo al jugador
        seguirJugador = false;

    }

    private void OnDrawGizmosSelected()
    {
        // Dibuja una esfera de color rojo en la posición del enemigo para indicar su posición y rango
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, rango);
    }

    void Update()
    {
        RaycastHit hit;
        Vector3 direccion = jugador.position - transform.position;

        bool hayObstaculo = false;
        if (Physics.Raycast(transform.position, direccion, out hit, rango, layerjugador))
        {
            if (hit.collider.gameObject.CompareTag("Pared"))
            {
                hayObstaculo = true;
            }
        }

        bool alerta = !hayObstaculo && Physics.CheckSphere(transform.position, rango, layerjugador);

        if (alerta)
        {
            bool hayObstaculoEnLinea = Physics.Linecast(transform.position, jugador.position, out RaycastHit obstaculoHit);

            if (hayObstaculoEnLinea && obstaculoHit.collider.gameObject.CompareTag("Pared"))
            {
                hayObstaculo = true;
            }

            Vector3 PosicionJugador = new Vector3(jugador.position.x, transform.position.y, jugador.position.z);

            if (!hayObstaculo && !seguirJugador)
            {
                seguirJugador = true;
                enMovimiento = false;
                transform.LookAt(PosicionJugador);
            }
            else if (hayObstaculo && seguirJugador)
            {
                seguirJugador = false;
            }
        }
        else if (!enMovimiento)
        {
            seguirJugador = false;
            enMovimiento = true;
        }

        if (seguirJugador)
        {
            transform.position = Vector3.MoveTowards(transform.position, jugador.position, velocidadM * Time.deltaTime);
        }
        else if (enMovimiento)
        {
            if (Vector3.Distance(transform.position, listaWaypoints[indiceWaypointActual].position) < 0.1f)
            {
                indiceWaypointActual = (indiceWaypointActual + 1) % listaWaypoints.Count;
            }

            transform.position = Vector3.MoveTowards(transform.position, listaWaypoints[indiceWaypointActual].position, velocidadM * Time.deltaTime);
            transform.LookAt(listaWaypoints[indiceWaypointActual]);
        }
    }
}*/

public class Enemy : MonoBehaviour
{

    public float rango = 100f;
    public LayerMask layerjugador;
    public Transform jugador;
    public float velocidadM;
    public bool alerta;
    public bool enMovimiento;

    /*public GameObject projectilePrefab;
    public float distanciaDisparo = 5f;
    public float velocidadDisparo = 50f;
    private float tiempoUltimoDisparo;
    private Transform puntoDisparo;*/

    private bool hayObstaculo;
    private bool seguirJugador;

    //private List<Transform> listaWaypoints = new List<Transform>();
    public List<Transform> listaWaypoints = new List<Transform>();
    private int indiceWaypointActual = 0;

    void Start()
    {
        /*GameObject[] waypoints = GameObject.FindGameObjectsWithTag("Waypoint");
        foreach (GameObject waypoint in waypoints)
        {
            listaWaypoints.Add(waypoint.transform);
        }*/

        // Inicialmente, el enemigo no está siguiendo al jugador
        seguirJugador = false;

        // Busca el punto de disparo en la jerarquía de objetos del enemigo
        /*puntoDisparo = transform.Find("PuntoDisparo");
        if (puntoDisparo == null)
        {
            Debug.LogError("No se encontró el objeto 'PuntoDisparo'");
        }*/
    }

    private void OnDrawGizmosSelected()
    {
        // Dibuja una esfera de color rojo en la posición del enemigo para indicar su posición y rango
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, rango);
    }

    void Update()
    {
        bool hayObstaculoEnLinea = Physics.Linecast(transform.position, jugador.position, out RaycastHit obstaculoHit);
        bool jugadorDetrasDeObstaculo = false;

        if (hayObstaculoEnLinea && obstaculoHit.collider.gameObject.CompareTag("Pared"))
        {
            hayObstaculo = true;
            Vector3 direccion = jugador.position - transform.position;
            if (Physics.Raycast(transform.position, direccion, out RaycastHit hit, rango, layerjugador))
            {
                jugadorDetrasDeObstaculo = hit.collider.gameObject.CompareTag("Player");
                jugadorDetrasDeObstaculo = hit.collider.gameObject.CompareTag("Player2");
            }
        }
        else
        {
            hayObstaculo = false;
            jugadorDetrasDeObstaculo = false;
        }

        bool alerta = !hayObstaculo && !jugadorDetrasDeObstaculo && Physics.CheckSphere(transform.position, rango, layerjugador);

        if (alerta)
        {
            Vector3 PosicionJugador = new Vector3(jugador.position.x, transform.position.y, jugador.position.z);

            if (!seguirJugador)
            {
                seguirJugador = true;
                enMovimiento = false;
                transform.LookAt(PosicionJugador);
            }
            else if (jugadorDetrasDeObstaculo)
            {
                seguirJugador = false;
            }
        }
        else if (!enMovimiento)
        {
            seguirJugador = false;
            enMovimiento = true;
        }

        if (seguirJugador)
        {
            transform.position = Vector3.MoveTowards(transform.position, jugador.position, velocidadM * Time.deltaTime);
            float distancia = Vector3.Distance(transform.position, jugador.position);
            transform.LookAt(jugador);
            /*if (distancia <= distanciaDisparo && Time.time - tiempoUltimoDisparo > 1 / velocidadDisparo)
            {
                tiempoUltimoDisparo = Time.time;
                Disparar();
            }
            else if (distancia > distanciaDisparo && Time.time - tiempoUltimoDisparo > 1 / velocidadDisparo)
            {
                Vector3 posicionDisparo = transform.position + transform.forward * distanciaDisparo;
                Quaternion rotacionDisparo = Quaternion.LookRotation(jugador.position - posicionDisparo);
                GameObject bullet = Instantiate(projectilePrefab, puntoDisparo.position, rotacionDisparo);
                Rigidbody proyectil = bullet.GetComponent<Rigidbody>();
                proyectil.AddForce(rotacionDisparo * Vector3.forward * velocidadDisparo, ForceMode.Impulse);
                tiempoUltimoDisparo = Time.time;
                transform.LookAt(jugador);
            }*/

        }

        else if (enMovimiento)
        {
            if (Vector3.Distance(transform.position, listaWaypoints[indiceWaypointActual].position) < 0.1f)
            {
                indiceWaypointActual = (indiceWaypointActual + 1) % listaWaypoints.Count;
            }

            transform.position = Vector3.MoveTowards(transform.position, listaWaypoints[indiceWaypointActual].position, velocidadM * Time.deltaTime);
            transform.LookAt(listaWaypoints[indiceWaypointActual]);
        }
    }

    /*void Disparar()
    {
        // Crea un nuevo objeto de laser desde el prefab
        GameObject bullet = Instantiate(projectilePrefab, puntoDisparo.position, puntoDisparo.rotation);

        // Calcula la dirección del vector del laser
        Vector3 direccionLaser = jugador.position - puntoDisparo.position;
        direccionLaser.Normalize();

        // Aplica la fuerza al rigidbody del laser
        Rigidbody proyectil = bullet.GetComponent<Rigidbody>();
        proyectil.AddForce(direccionLaser * velocidadDisparo, ForceMode.VelocityChange);

        Destroy(bullet, 5f);
    }*/
}
