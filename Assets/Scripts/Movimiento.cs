using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    public float speed = 1f;
    public float rotationSpeed = 100f; // Velocidad de giro

    private Rigidbody rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }


    // Start is called before the first frame update
    private void FixedUpdate()
    {
        float movVertical = Input.GetAxis("Vertical");
        float movHorizontal = Input.GetAxis("Horizontal");

        // Mover el tanque hacia adelante o atrás
        Vector3 movimiento = transform.forward * movVertical * speed;
        rb.AddForce(movimiento);

        // Girar el tanque sobre su eje Y
        float rotacion = movHorizontal * rotationSpeed * Time.fixedDeltaTime;
        rb.MoveRotation(rb.rotation * Quaternion.Euler(0, rotacion, 0));
    }
}
