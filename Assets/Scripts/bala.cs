using UnityEngine;
using System.Collections;

public class Proyectil : MonoBehaviour
{
    private bool puntosSumados = false; // Variable para evitar múltiples sumas de puntos
    public AudioSource audioSource; // Referencia al AudioSource
    public AudioClip impactoCañon; // El sonido de impacto de la bala de cañón
    void Start()
    {
        // Asegúrate de que el AudioSource está configurado
        if (audioSource == null)
        {
            audioSource = GetComponent<AudioSource>(); // Si no está asignado, lo obtenemos del objeto
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        // Verifica si el objeto colisionado tiene el tag "Pared"
        if (collision.gameObject.CompareTag("Pared") && !puntosSumados)
        {
            puntosSumados = true; // Evita que se sumen puntos múltiples veces
            FindAnyObjectByType<Marcador>().SumarPuntos();
            // Reproducir el sonido de impacto
            if (impactoCañon != null && audioSource != null)
            {
                audioSource.PlayOneShot(impactoCañon); // Reproducir el sonido
            }
            Destroy(collision.gameObject); // Destruye la pared colisionada
        }

        StartCoroutine(DestruirConRetraso());
    }

    IEnumerator DestruirConRetraso()
    {
        yield return new WaitForSeconds(3f);
        Destroy(gameObject); // Destruye la bala después del retraso
    }
}
