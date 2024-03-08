using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ordas : MonoBehaviour
{
    public ValoresEnemigos[] valoresEnemigos;
    private ValoresEnemigos enemigoActual;
    private float tiempoEspera = 0;
    private int numOrdaActual = 0;
    private int enemigosPorCrear = 0;
    private bool todasLasOrdasCompletadas = false;

    void Start()
    {
        IniciarJuego();
    }

    void IniciarJuego()
    {
        numOrdaActual = 0;
        todasLasOrdasCompletadas = false;
        NextOrda();
    }

    void NextOrda()
    {
        if (numOrdaActual < valoresEnemigos.Length)
        {
            enemigoActual = valoresEnemigos[numOrdaActual];
            enemigosPorCrear = enemigoActual.numeroEnemigos;
        }
        else
        {
            todasLasOrdasCompletadas = true;
        }
    }

    void Update()
    {
        if (!todasLasOrdasCompletadas)
        {
            if (enemigosPorCrear > 0 && tiempoEspera <= 0)
            {
                Instantiate(enemigoActual.tipoEnemigo, Vector3.zero, Quaternion.identity);
                enemigosPorCrear--;
                tiempoEspera = enemigoActual.tiempoEntreEnemigos;
            }
            else if (enemigosPorCrear <= 0 && GameObject.FindGameObjectsWithTag("Enemigo").Length == 0)
            {
                if (numOrdaActual < valoresEnemigos.Length - 1)
                {
                    numOrdaActual++;
                    NextOrda();
                }
                else
                {
                    todasLasOrdasCompletadas = true;
                    SceneManager.LoadScene("Victoria");
                }
            }
            else
            {
                tiempoEspera -= Time.deltaTime;
            }
        }
    }
}






