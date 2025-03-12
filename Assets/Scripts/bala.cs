using UnityEngine;
using System.Collections;

public class Proyectil : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        // Verifica si el objeto con el que ha colisionado tiene el tag "Pared"
        if (collision.gameObject.CompareTag("Pared"))
        {
            // Destruye la pared
            Destroy(collision.gameObject);
        }
        // Llama a la corutina para destruir el proyectil después de 3 segundos
        StartCoroutine(DestruirConRetraso());
    }

    IEnumerator DestruirConRetraso()
    {
        // Espera 3 segundos antes de destruir el proyectil
        yield return new WaitForSeconds(3f);

        // Destruye el proyectil
        Destroy(gameObject);
    }
}
