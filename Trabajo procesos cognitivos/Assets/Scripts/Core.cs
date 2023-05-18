using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Core : MonoBehaviour
{
    public GameObject[] objetoColumna = new GameObject[7];
    private Columna[] columnas = new Columna[7];
    public bool turno;
    public int[] casillasJugador1 = new int[21];
    public int[] casillasJugador2 = new int[21];
    public int contadorTurnosJugador1;
    public int contadorTurnosJugador2;
    public int nuevoMovimiento;
    int puedeSerVictoria;
    public bool victoria;

    public GameObject turno1, turno2, victoria1, victoria2, turnos;



    // Start is called before the first frame update
    void Awake()
    {
        victoria1.SetActive(false);
        victoria2.SetActive(false);
        turnos.SetActive(true);
        victoria = false;
        contadorTurnosJugador1= 0;
        contadorTurnosJugador2 = 0;
        columnas[0] = objetoColumna[0].GetComponent<Columna>();
        columnas[1] = objetoColumna[1].GetComponent<Columna>();
        columnas[2] = objetoColumna[2].GetComponent<Columna>();
        columnas[3] = objetoColumna[3].GetComponent<Columna>();
        columnas[4] = objetoColumna[4].GetComponent<Columna>();
        columnas[5] = objetoColumna[5].GetComponent<Columna>();
        columnas[6] = objetoColumna[6].GetComponent<Columna>();
        turno = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (turno)
        {
            turno1.SetActive(true); turno2.SetActive(false);
        }
        else
        {
            turno1.SetActive(false); turno2.SetActive(true);
        }
    }
    
    public void Movimiento()
    {
        if (!victoria)
        {
            ComprobarVictoria(turno, nuevoMovimiento);
            if (turno)
            {
                contadorTurnosJugador1++;
                turno = false;
            }
            else
            {
                contadorTurnosJugador2++;
                turno = true;
            }
        }
    }

    public void ComprobarVictoria(bool turno, int nuevoMovimiento)
    {

        //VICTORIA EN HORIZONTAL

        puedeSerVictoria = 1;
        if (Derecha(turno, nuevoMovimiento))
        {
            puedeSerVictoria++;
            if (Derecha(turno, nuevoMovimiento + 1))
            {
                puedeSerVictoria++;
                if (Derecha(turno, nuevoMovimiento + 2))
                {
                    puedeSerVictoria++;
                }
            }

        }

        if (Izquierda(turno, nuevoMovimiento))
        {
            puedeSerVictoria++;
            if (Izquierda(turno, nuevoMovimiento - 1))
            {
                puedeSerVictoria++;
                if (Izquierda(turno, nuevoMovimiento - 2))
                {
                    puedeSerVictoria++;
                }
            }
        }

        if (puedeSerVictoria >= 4 && turno)
        {
            FinPartida();
            Debug.Log("VICTORIA HORIZONTAL JUGADOR 1");
        }
        else if (puedeSerVictoria >= 4 && !turno)
        {
            FinPartida();
            Debug.Log("VICTORIA HORIZONTAL JUGADOR 2");
        }



        //VICTORIA EN VERTICAL
        puedeSerVictoria= 1;

        if (Abajo(turno, nuevoMovimiento))
        {
            puedeSerVictoria++;
            if (Abajo(turno, nuevoMovimiento - 7))
            {
                puedeSerVictoria++;
                if (Abajo(turno, nuevoMovimiento - 14))
                {
                    puedeSerVictoria++;
                }
            }
        }
        if (puedeSerVictoria >= 4 && turno)
        {
            FinPartida();
            Debug.Log("VICTORIA VERTICAL JUGADOR 1");
        }
        else if (puedeSerVictoria >= 4 && !turno)
        {
            FinPartida();
            Debug.Log("VICTORIA VERTICAL JUGADOR 2");
        }

        //VICTORIA EN DIAGONAL ASCENDENTE

        puedeSerVictoria = 1;


        if (DiagonalArribaDerecha(turno, nuevoMovimiento))
        {
            puedeSerVictoria++;
            if (DiagonalArribaDerecha(turno, nuevoMovimiento + 8))
            {
                puedeSerVictoria++;
                if (DiagonalArribaDerecha(turno, nuevoMovimiento + 16))
                {
                    puedeSerVictoria++;
                }
            }

        }

        if (DiagonalAbajoIzquierda(turno, nuevoMovimiento))
        {
            puedeSerVictoria++;
            if (DiagonalAbajoIzquierda(turno, nuevoMovimiento - 8))
            {
                puedeSerVictoria++;
                if (DiagonalAbajoIzquierda(turno, nuevoMovimiento - 16))
                {
                    puedeSerVictoria++;
                }
            }
        }

        if (puedeSerVictoria >= 4 && turno)
        {
            FinPartida();
            Debug.Log("VICTORIA DIAGONAL JUGADOR 1");
        }
        else if (puedeSerVictoria >= 4 && !turno)
        {
            FinPartida();
            Debug.Log("VICTORIA DIAGONAL JUGADOR 2");
        }


        //VICTORIA EN DIAGONAL DESCENDENTE

        puedeSerVictoria = 1;


        if (DiagonalArribaIzquierda(turno, nuevoMovimiento))
        {
            puedeSerVictoria++;
            if (DiagonalArribaIzquierda(turno, nuevoMovimiento + 6))
            {
                puedeSerVictoria++;
                if (DiagonalArribaIzquierda(turno, nuevoMovimiento + 12))
                {
                    puedeSerVictoria++;
                }
            }

        }

        if (DiagonalAbajoDerecha(turno, nuevoMovimiento))
        {
            puedeSerVictoria++;
            if (DiagonalAbajoDerecha(turno, nuevoMovimiento - 6))
            {
                puedeSerVictoria++;
                if (DiagonalAbajoDerecha(turno, nuevoMovimiento - 12))
                {
                    puedeSerVictoria++;
                }
            }
        }

        if (puedeSerVictoria >= 4 && turno)
        {
            FinPartida();
            Debug.Log("VICTORIA DIAGONAL Descendente JUGADOR 1");
        }
        else if (puedeSerVictoria >= 4 && !turno)
        {
            FinPartida();
            Debug.Log("VICTORIA DIAGONAL Descendente JUGADOR 2");
        }



    }

    public bool DiagonalDerechaArriba(bool turno, int nuevoMovimiento)
    {
        bool comprobacion;
        comprobacion = false;
        return comprobacion;
    }

    public bool Izquierda(bool turno, int nuevoMovimiento)
    {
        if ((((nuevoMovimiento-1) % 7) != 0) && (nuevoMovimiento >=2))
        {
            if (turno)
            {
                for (int i = 0; i < contadorTurnosJugador1; i++)
                {
                    if (casillasJugador1[i] != null)
                    {

                        if (casillasJugador1[i] == nuevoMovimiento - 1)
                        {
                            return true;
                        }
                    }
                }
                return false;
            }
            else
            {
                for (int i = 0; i < contadorTurnosJugador2; i++)
                {
                    if (casillasJugador2[i] != null)
                    {
                        if (casillasJugador2[i] == nuevoMovimiento - 1)
                        {
                            return true;
                        }
                    }
                }
                return false;
            }
        }
        else
        {
            return false;
        }
    }
    
    public bool Derecha(bool turno, int nuevoMovimiento)
    {

        if(((nuevoMovimiento % 7) != 0) && (nuevoMovimiento < 42))
        {
            if (turno)
            {
                for (int i = 0; i < contadorTurnosJugador1; i++)
                {
                    if (casillasJugador1[i] != null)
                    {
                        
                        if (casillasJugador1[i] == nuevoMovimiento + 1)
                        {
                            return true;
                        }
                    }
                }
                return false;
            }
            else 
            {
                for (int i = 0; i < contadorTurnosJugador2; i++)
                {
                    if (casillasJugador2[i] != null)
                    {
                        if (casillasJugador2[i] == nuevoMovimiento + 1)
                        {
                            return true;
                        }
                    }
                }
                return false;
            }
        }
        else
        {
            return false;
        }
    }

    public bool Abajo(bool turno, int nuevoMovimiento)
    {
        if (nuevoMovimiento > 7)
        {
            if (turno)
            {
                for (int i = 0; i < contadorTurnosJugador1; i++)
                {
                    if (casillasJugador1[i] != null)
                    {

                        if (casillasJugador1[i] == (nuevoMovimiento - 7))
                        {
                            return true;
                        }
                    }
                }
                return false;
            }
            else
            {
                for (int i = 0; i < contadorTurnosJugador2; i++)
                {
                    if (casillasJugador2[i] != null)
                    {

                        if (casillasJugador2[i] == (nuevoMovimiento - 7))
                        {
                            return true;
                        }
                    }
                }
                return false;
            }
        }
        else
        {
            return false;
        }
    }

    public bool DiagonalArribaDerecha(bool turno, int nuevoMovimiento)
    {
        if (nuevoMovimiento % 7 != 0 && nuevoMovimiento <= 35)
        {
            if (turno)
            {
                for (int i = 0; i < contadorTurnosJugador1; i++)
                {
                    if (casillasJugador1[i] != null)
                    {

                        if (casillasJugador1[i] == (nuevoMovimiento + 8)) 
                        {
                            return true;
                        }
                    }
                }
                return false;
            }
            else
            {
                for (int i = 0; i < contadorTurnosJugador2; i++)
                {
                    if (casillasJugador2[i] != null)
                    {

                        if (casillasJugador2[i] == (nuevoMovimiento + 8)) 
                        {
                            return true;
                        }
                    }
                }
                return false;
            }
        }
        else
        {
            return false;
        }
    }


    public bool DiagonalAbajoIzquierda(bool turno, int nuevoMovimiento)
    {
        if (nuevoMovimiento > 7 && (nuevoMovimiento-1) % 7 != 0)
        {
            if (turno)
            {
                for (int i = 0; i < contadorTurnosJugador1; i++)
                {
                    if (casillasJugador1[i] != null)
                    {

                        if (casillasJugador1[i] == (nuevoMovimiento - 8)) 
                        {
                            return true;
                        }
                    }
                }
                return false;
            }
            else
            {
                for (int i = 0; i < contadorTurnosJugador2; i++)
                {
                    if (casillasJugador2[i] != null)
                    {

                        if (casillasJugador2[i] == (nuevoMovimiento - 8)) 
                        {
                            return true;
                        }
                    }
                }
                return false;
            }
        }
        else
        {
            return false;
        }
    }

    public bool DiagonalArribaIzquierda(bool turno, int nuevoMovimiento)
    {
        if (nuevoMovimiento % 7 != 0 && nuevoMovimiento <= 35)
        {
            if (turno)
            {
                for (int i = 0; i < contadorTurnosJugador1; i++)
                {
                    if (casillasJugador1[i] != null)
                    {

                        if (casillasJugador1[i] == (nuevoMovimiento + 6))
                        {
                            return true;
                        }
                    }
                }
                return false;
            }
            else
            {
                for (int i = 0; i < contadorTurnosJugador2; i++)
                {
                    if (casillasJugador2[i] != null)
                    {

                        if (casillasJugador2[i] == (nuevoMovimiento + 6))
                        {
                            return true;
                        }
                    }
                }
                return false;
            }
        }
        else
        {
            return false;
        }
    }

    public bool DiagonalAbajoDerecha(bool turno, int nuevoMovimiento)
    {
        if (nuevoMovimiento % 7 != 0 && nuevoMovimiento <= 35)
        {
            if (turno)
            {
                for (int i = 0; i < contadorTurnosJugador1; i++)
                {
                    if (casillasJugador1[i] != null)
                    {

                        if (casillasJugador1[i] == (nuevoMovimiento - 6))
                        {
                            return true;
                        }
                    }
                }
                return false;
            }
            else
            {
                for (int i = 0; i < contadorTurnosJugador2; i++)
                {
                    if (casillasJugador2[i] != null)
                    {

                        if (casillasJugador2[i] == (nuevoMovimiento - 6))
                        {
                            return true;
                        }
                    }
                }
                return false;
            }
        }
        else
        {
            return false;
        }
    }

    public void FinPartida()
    {
        turnos.SetActive(false);
        victoria = true;
        if(turno)
        {
            victoria1.SetActive(true);
        }
        else
        {
            victoria2.SetActive(true);
        }

        for (int i = 0; i < 7; i++)
        {
            columnas[i].Colores();
        }
    }
}



