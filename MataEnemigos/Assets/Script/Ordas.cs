using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
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
        if(enemigosPorMatar <= 0) // si no hay enemigos por matar
        {
            //si estoy en la escena Ronda1 y mato a todos los enemigos, cambio a la escena Ronda2 y ya esta
            if(SceneManager.GetActiveScene().name == "Ronda1")
            {
                SceneManager.LoadScene("Ronda2");
            }
            if(SceneManager.GetActiveScene().name == "Ronda2")
            {
                SceneManager.LoadScene("Victoria");
            }
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
