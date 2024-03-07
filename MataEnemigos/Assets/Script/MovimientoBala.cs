using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoBala : MonoBehaviour
{
    public float speed = 10f;
    public LayerMask capasDestruir;
    public delegate void  OnHitEnemy();
    public static event OnHitEnemy onHitEnemy;
    public GameObject particulas;
    public AudioClip sonidoEnemigoMuerto;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float moveDistancia = speed * Time.deltaTime;
        transform.Translate(Vector3.forward * moveDistancia);
        CheckCollision(moveDistancia);
    }

    void CheckCollision(float moveDistancia)
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, moveDistancia, capasDestruir, QueryTriggerInteraction.Collide))
        {
            if (hit.collider.tag == "Enemigo")
            {
                //Aparecen particulas cuando la bala toca al enemigo
                GameObject particulasInstanciadas = Instantiate(particulas, hit.point, Quaternion.LookRotation(hit.normal));
                AudioSource.PlayClipAtPoint(sonidoEnemigoMuerto, transform.position);

                Destroy(hit.collider.gameObject);
                if (onHitEnemy != null)
                {
                    onHitEnemy();
                }
            }
            Destroy(gameObject);
        }
    }
}
