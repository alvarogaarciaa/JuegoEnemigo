using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ordas : MonoBehaviour
{
    public ValoresEnemigos[] valoresEnemigos;
    private ValoresEnemigos enemigoActual;
    float tiempoEspera = 0;
    int numOrdaActual = 0;
    int enemigosPorCrear = 0;
    int enemigosPorMatar = 0;
    // Start is called before the first frame update
    void Start()
    {
        NextOrda();
        MovimientoBala.onHitEnemy += EnemigoMuerto;
    }


    void NextOrda()
    {
        numOrdaActual++;
        enemigoActual = valoresEnemigos[numOrdaActual - 1];
        enemigosPorCrear = enemigoActual.numeroEnemigos;
        enemigosPorMatar = enemigoActual.numeroEnemigos;
    }

    void EnemigoMuerto()
    {
        enemigosPorMatar--;
        if(enemigosPorMatar <= 0)
        {
            NextOrda();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(enemigosPorCrear > 0 && tiempoEspera <= 0)
        {
            Instantiate(enemigoActual.tipoEnemigo, Vector3.zero, Quaternion.identity);
            enemigosPorCrear--;
            tiempoEspera = enemigoActual.tiempoEntreEnemigos;
        }
        else 
        {
            tiempoEspera -= Time.deltaTime;
        }
    }
}
