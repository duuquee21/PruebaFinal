using UnityEngine;
using System.Collections;

public class Proyectil : MonoBehaviour
{
    private bool puntosSumados = false; // Variable para evitar m�ltiples sumas de puntos
    public AudioSource audioSource; // Referencia al AudioSource
    public AudioClip impactoCa�on; // El sonido de impacto de la bala de ca��n
    void Start()
    {
        // Aseg�rate de que el AudioSource est� configurado
        if (audioSource == null)
        {
            audioSource = GetComponent<AudioSource>(); // Si no est� asignado, lo obtenemos del objeto
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        // Verifica si el objeto colisionado tiene el tag "Pared"
        if (collision.gameObject.CompareTag("Pared") && !puntosSumados)
        {
            puntosSumados = true; // Evita que se sumen puntos m�ltiples veces
            FindAnyObjectByType<Marcador>().SumarPuntos();
            // Reproducir el sonido de impacto
            if (impactoCa�on != null && audioSource != null)
            {
                audioSource.PlayOneShot(impactoCa�on); // Reproducir el sonido
            }
            Destroy(collision.gameObject); // Destruye la pared colisionada
        }

        StartCoroutine(DestruirConRetraso());
    }

    IEnumerator DestruirConRetraso()
    {
        yield return new WaitForSeconds(3f);
        Destroy(gameObject); // Destruye la bala despu�s del retraso
    }
}
