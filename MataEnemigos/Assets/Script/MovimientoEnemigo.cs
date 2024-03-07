using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoEnemigo : MonoBehaviour
{
    UnityEngine.AI.NavMeshAgent pathFinder;
    Transform target;

    void Start()
    {
        pathFinder = GetComponent<UnityEngine.AI.NavMeshAgent>();
        GameObject jugador = GameObject.FindGameObjectWithTag("Jugador");
        if (jugador != null) {
            target = jugador.transform;
        }
    }

    void Update()
    {
        // Verificar si el objeto target existe antes de acceder a su posición
        if (target != null) {
            pathFinder.SetDestination(target.position);
        }
    }
}
