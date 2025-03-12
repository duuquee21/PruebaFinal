using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoApuntado : MonoBehaviour
{
    public float canonSpeed = 100f; // Velocidad de rotación del cañón

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Obtener la posición del ratón en el mundo
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            Vector3 objetivo = hit.point; // Punto donde el ratón toca el mundo
            objetivo.y = transform.position.y; // Mantener el cañón en el mismo nivel

            // Calcular la dirección hacia el objetivo
            Vector3 direccion = objetivo - transform.position;
            float step = canonSpeed * Time.deltaTime;

            // Rotar el cañón hacia la dirección calculada
            Vector3 nuevaDireccion = Vector3.RotateTowards(transform.forward, direccion, step, 0.0f);
            transform.rotation = Quaternion.LookRotation(nuevaDireccion);
        }
    }
}
