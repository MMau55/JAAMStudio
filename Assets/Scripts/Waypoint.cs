using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    public Transform siguienteWaypoint;

    // Devuelve la posición del waypoint
    public Vector3 ObtenerPosicion()
    {
        return transform.position;
    }

    // Devuelve el siguiente waypoint en la ruta
    public Transform ObtenerSiguienteWaypoint()
    {
        return siguienteWaypoint;
    }
}
