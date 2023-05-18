using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PuzzleLightsManager : MonoBehaviour
{
    public GameObject ganaste;
    private int puntosGanados = 0;
    [SerializeField] private GameObject parte1;

    [SerializeField] private GameObject parte2;
    [SerializeField] private GameObject parte3;
    float tiempo;
    bool cicle1 = true;
    bool cicle1win = false;
    public float velocidadParte1;
    bool cambiocorrtinas = false;
    bool cicle2 = true;
    bool cicle2win = false;
    public float velocidadParte2;

    private bool cambiobool = false;

    bool cicle3 = true;
    bool cicle3win = false;
    public float velocidadParte3;
    private bool esverde=false;
    private int numeroactual;
 
    // Start is called before the first frame update
    void Start()
    {
        ganaste.SetActive(false);
      
    }

    private void FixedUpdate()

    {
    }
    // Update is called once per frame
    void Update()
    {

        tiempo += Time.deltaTime;
        if (puntosGanados == 0)
        {
            if (cicle1win == false)
            {
                if (cambiocorrtinas == false)
                {
                    cambiocorrtinas = true;
                    StartCoroutine(parte1cicle());
                }

            }
            else
            {
                if (cambiocorrtinas == false)
                {
                    cambiocorrtinas = true;

                    StartCoroutine(wincicle1());

                    puntosGanados++;
                }
                
            }



        }
        else if (puntosGanados == 1)
        {
            if (cicle2win == false)
            {
                if (cambiocorrtinas == false)
                {
                    cambiocorrtinas = true;
                    StartCoroutine(parte2cicle());
                }

            }
            else
            {
                if (cambiocorrtinas == false)
                {
                    cambiocorrtinas = true;

                    StartCoroutine(wincicle2());

                    puntosGanados++;
                }

            }



        }
        else if (puntosGanados == 2)
        {
            if (cicle3win == false)
            {
                if (cambiocorrtinas == false)
                {
                    cambiocorrtinas = true;
                    StartCoroutine(parte3cicle());
                }

            }
            else
            {
                if (cambiocorrtinas == false)
                {
                    cambiocorrtinas = true;

                    StartCoroutine(wincicle3());

                    puntosGanados++;
                }

            }





        }
       
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (puntosGanados == 0)
            {
                if (esverde==true)
                {
                    cicle1win = true;
                   
                }
            }
            if (puntosGanados == 1)
            {
                if (esverde == true)
                {
                    cicle2win = true;
                  
                }
            }

            if (puntosGanados == 2)
            {
                if (esverde == true)
                {
                    cicle3win = true;

                }
            }

        }
       
    }


   

    private void Ganaste()
    {

        ganaste.SetActive(true);
    }

    public IEnumerator parte1cicle()
    {
       
        yield return new WaitForSeconds(velocidadParte1);
       
      
      
            yield return new WaitForSeconds(velocidadParte1);
            numeroactual = Random.Range(0, parte1.transform.childCount);
            if(parte1.transform.GetChild(numeroactual).tag=="Verde")
            {
            
            esverde = true;
                parte1.transform.GetChild(numeroactual).GetComponent<Renderer>().material.EnableKeyword("_EMISSION");
                parte1.transform.GetChild(numeroactual).GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.green);
            yield return new WaitForSeconds(velocidadParte1);
            StartCoroutine(endcicle1());

            }
            else
            {
            yield return new WaitForSeconds(velocidadParte1);
                parte1.transform.GetChild(numeroactual).GetComponent<Renderer>().material.EnableKeyword("_EMISSION");
                parte1.transform.GetChild(numeroactual).GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.red);
            yield return new WaitForSeconds(velocidadParte1);
            StartCoroutine(endcicle1());
        }


        cambiocorrtinas = false;
     
      
    }

    

   

    public IEnumerator endcicle1()
    {
        
            yield return new WaitForSeconds(velocidadParte1);
            esverde = false;
            parte1.transform.GetChild(numeroactual).GetComponent<Renderer>().material.EnableKeyword("_EMISSION");
            parte1.transform.GetChild(numeroactual).GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.black);
        yield return new WaitForSeconds(velocidadParte1);



    }
    public IEnumerator parte2cicle()
    {

        yield return new WaitForSeconds(velocidadParte2);



        yield return new WaitForSeconds(velocidadParte2);
        numeroactual = Random.Range(0, parte2.transform.childCount);
        if (parte2.transform.GetChild(numeroactual).tag == "Verde")
        {

            esverde = true;
            parte2.transform.GetChild(numeroactual).GetComponent<Renderer>().material.EnableKeyword("_EMISSION");
            parte2.transform.GetChild(numeroactual).GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.green);
            yield return new WaitForSeconds(velocidadParte2);
            StartCoroutine(endcicle2());

        }
        else
        {
            yield return new WaitForSeconds(velocidadParte2);
            parte2.transform.GetChild(numeroactual).GetComponent<Renderer>().material.EnableKeyword("_EMISSION");
            parte2.transform.GetChild(numeroactual).GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.red);
            yield return new WaitForSeconds(velocidadParte2);
            StartCoroutine(endcicle2());
        }


        cambiocorrtinas = false;


    }





    public IEnumerator endcicle2()
    {

        yield return new WaitForSeconds(velocidadParte1);
        esverde = false;
        parte2.transform.GetChild(numeroactual).GetComponent<Renderer>().material.EnableKeyword("_EMISSION");
        parte2.transform.GetChild(numeroactual).GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.black);
        yield return new WaitForSeconds(velocidadParte2);



    }

    public IEnumerator parte3cicle()
    {

        yield return new WaitForSeconds(velocidadParte3);



        yield return new WaitForSeconds(velocidadParte3);
        numeroactual = Random.Range(0, parte3.transform.childCount);
        if (parte3.transform.GetChild(numeroactual).tag == "Verde")
        {

            esverde = true;
            parte3.transform.GetChild(numeroactual).GetComponent<Renderer>().material.EnableKeyword("_EMISSION");
            parte3.transform.GetChild(numeroactual).GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.green);
            yield return new WaitForSeconds(velocidadParte3);
            StartCoroutine(endcicle3());

        }
        else
        {
            yield return new WaitForSeconds(velocidadParte3);
            parte3.transform.GetChild(numeroactual).GetComponent<Renderer>().material.EnableKeyword("_EMISSION");
            parte3.transform.GetChild(numeroactual).GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.red);
            yield return new WaitForSeconds(velocidadParte3);
            StartCoroutine(endcicle3());
        }


        cambiocorrtinas = false;


    }





    public IEnumerator endcicle3()
    {

        yield return new WaitForSeconds(velocidadParte3);
        esverde = false;
        parte3.transform.GetChild(numeroactual).GetComponent<Renderer>().material.EnableKeyword("_EMISSION");
        parte3.transform.GetChild(numeroactual).GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.black);
        yield return new WaitForSeconds(velocidadParte3);



    }

    public IEnumerator wincicle1()
    {
        yield return new WaitForSeconds(0.3f);
        for (int i = 0; i < parte1.transform.childCount; i++)
        {
            StopCoroutine(parte1cicle());
            StopCoroutine(endcicle1());
            yield return new WaitForSeconds(0.1f);
            parte1.transform.GetChild(i).GetComponent<Renderer>().material.EnableKeyword("_EMISSION");
            parte1.transform.GetChild(i).GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.green);
            yield return new WaitForSeconds(0.1f);

        }
        cambiocorrtinas = false;

    }
    public IEnumerator wincicle2()

    {
        yield return new WaitForSeconds(0.3f);


        for (int i = 0; i < parte2.transform.childCount; i++)
        {
            yield return new WaitForSeconds(0.1f);
            parte2.transform.GetChild(i).GetComponent<Renderer>().material.EnableKeyword("_EMISSION");
            parte2.transform.GetChild(i).GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.green);
            yield return new WaitForSeconds(0.1f);

        }

        cambiocorrtinas = false;
    }

    public IEnumerator wincicle3()

    {
        yield return new WaitForSeconds(0.3f);

        for (int i = 0; i < parte3.transform.childCount; i++)
        {
            yield return new WaitForSeconds(0.1f);
            parte3.transform.GetChild(i).GetComponent<Renderer>().material.EnableKeyword("_EMISSION");
            parte3.transform.GetChild(i).GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.green);
            yield return new WaitForSeconds(0.1f);

        }

        cambiocorrtinas = false;
        Ganaste();
    }

   

    public void cambiofalse()
    {
        cambiobool = false;
    }

    public void cambiotrue()
    {
        cambiobool = true;
    }

}
