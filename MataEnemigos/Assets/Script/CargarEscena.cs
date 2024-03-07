using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CargarEscena : MonoBehaviour
{
    // Start is called before the first frame update
    public void Comenzar()
    {
        //Cargar escena siguiente
        SceneManager.LoadScene("Ronda1");
        
    }

    public void Reiniciar()
    {
        //Cargar escena siguiente
        SceneManager.LoadScene("Ronda1");
    }

    public void Salir()
    {
        SceneManager.LoadScene("Inicio");
    }
}
