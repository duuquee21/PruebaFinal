using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Marcador : MonoBehaviour
{
    public TMP_Text puntos;
    private int puntosRecolectados = 0;
    private int puntosact;
    private int totalpuntos = 6;


    public void SumarPuntos()
    {
        puntosRecolectados++;
        Debug.Log("Puntos recolectados: " + puntosRecolectados); // Depuración

        puntos.text = puntosRecolectados.ToString();

        if (puntosRecolectados >= totalpuntos)
        {
            puntos.text = "Juego terminado"; // Cambia el texto
            Debug.Log("Juego terminado"); // Depuración
        }
    }

}
