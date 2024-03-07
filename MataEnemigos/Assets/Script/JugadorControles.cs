using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(Rigidbody))]
public class JugadorControles : MonoBehaviour
{
    CharacterController characterController;
    Rigidbody rb;
    public float speed = 5.0f;
    UnityEngine.Vector3 moveInput, moveVelocity;
    public Camera mainCamera;
    DisparaBala controladorBalas;
    public GameObject botonReiniciar;
    
    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        rb = GetComponent<Rigidbody>();
        controladorBalas = GetComponent<DisparaBala>();

    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        UnityEngine.Plane groundPlane = new UnityEngine.Plane(UnityEngine.Vector3.up, UnityEngine.Vector3.zero);
        if (groundPlane.Raycast(ray, out float rayDistance))
        {
            UnityEngine.Vector3 point = ray.GetPoint(rayDistance);
            Debug.DrawLine(ray.origin, point, Color.red);
            transform.LookAt(new UnityEngine.Vector3(point.x, transform.position.y, point.z));
        }

        if (Input.GetMouseButton(0))
        {
            controladorBalas.Dispara();
        }
    }

    void FixedUpdate()
    {
        moveInput = new UnityEngine.Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
        moveVelocity = moveInput.normalized * speed;
        characterController.Move(moveVelocity * speed * Time.fixedDeltaTime);
    }

    // cuando el enemigo entre en contacto con el jugador
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemigo"))
        {
            //Aparece el boton de reiniciar
            botonReiniciar.SetActive(true);
            Destroy(gameObject);

        }
    }
}
