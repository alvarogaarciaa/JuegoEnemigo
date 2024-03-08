using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoBala : MonoBehaviour
{
    public float speed = 10f;
    public LayerMask capasDestruir;
    public delegate void OnHitEnemy();
    public static event OnHitEnemy onHitEnemy;
    public GameObject particulas;
    public AudioClip sonidoEnemigoMuerto;

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
            if (hit.collider.CompareTag("Enemigo")) // Verificar si el collider pertenece al enemigo
            {
                Destroy(hit.collider.gameObject); // Destruir el enemigo
                // Aparecen partículas cuando la bala toca al enemigo
                GameObject particulasInstanciadas = Instantiate(particulas, hit.point, Quaternion.LookRotation(hit.normal));
                AudioSource.PlayClipAtPoint(sonidoEnemigoMuerto, transform.position);

                if (AllEnemiesDestroyed()) // Verifica si todos los enemigos de la oleada han sido destruidos
                {
                    if (onHitEnemy != null)
                    {
                        onHitEnemy();
                    }
                }
            }
            Destroy(gameObject); // Destruir la bala después de colisionar
        }
    }

    bool AllEnemiesDestroyed()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemigo");
        return enemies.Length == 0;
    }
}
