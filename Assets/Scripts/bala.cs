using UnityEngine;
using System.Collections;

public class Proyectil : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
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
