using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Columna : MonoBehaviour
{
    public GameObject[] columna = new GameObject[6];
    int fila;
    public int numColumna;
    Core core;
    public GameObject nucleo;

    SpriteRenderer[] sr = new SpriteRenderer[6];

    int[] circulosp1 = new int[6];
    int[] circulosp2 = new int[6];

    int contadorp1;
    int contadorp2;

    





    void Start()
    {
        fila = 0;
        core = nucleo.GetComponent<Core>();
        for (int i = 0; i < 6; i++)
        {
            sr[i] = columna[i].GetComponentInChildren<SpriteRenderer>();
        }
        contadorp1 = 0;
        contadorp2 = 0;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && (core.victoria || ((core.contadorTurnosJugador1 + core.contadorTurnosJugador2) >= 48)))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public void OnMouseDown()
    {
        if (!core.victoria)
        {
            if (fila < 6)
            {
                columna[fila].SetActive(true);
                fila++;
                core.nuevoMovimiento = numColumna + (7 * (fila - 1));

                if (core.turno)
                {
                    core.casillasJugador1[core.contadorTurnosJugador1] = numColumna + (7 * (fila - 1));
                    circulosp1[contadorp1] = fila - 1;
                    contadorp1++;
                }
                else
                {
                    core.casillasJugador2[core.contadorTurnosJugador2] = numColumna + (7 * (fila - 1));
                    circulosp2[contadorp2] = fila - 1;
                    contadorp2++;
                }


                core.Movimiento();

            }
        }
    }

    public void Colores()
    {
        if (core.victoria)
        {
            for (int i = 0; i < contadorp2; i++)
            {
                sr[circulosp2[i]].color = Color.red;


            }
            for (int i = 0; i < contadorp1; i++)
            {
                sr[circulosp1[i]].color = Color.blue;
            }
        }
    }
}
