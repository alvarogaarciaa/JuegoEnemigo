using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoEnemigo : MonoBehaviour
{
    UnityEngine.AI.NavMeshAgent pathFinder;
    Transform target;
    // Start is called before the first frame update
    void Start()
    {
        pathFinder = GetComponent<UnityEngine.AI.NavMeshAgent>();
        target = GameObject.FindGameObjectWithTag("Jugador").transform;
    }

    // Update is called once per frame
    void Update()
    {
        pathFinder.SetDestination(target.position);
    }
}
