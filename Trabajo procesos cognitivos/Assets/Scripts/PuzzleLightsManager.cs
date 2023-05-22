using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PuzzleLightsManager : MonoBehaviour
{
    public GameObject correct;
    public GameObject ganaste;
    private int puntosGanados = 0;
    private int intentosfallidos=0;
    public TMPro.TMP_Text textointentosfallidos;
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
    public GameObject Indicators;

    private bool cambiobool = false;

    bool cicle3 = true;
    bool cicle3win = false;
    public float velocidadParte3;
    private bool esverde=false;
    private int numeroactual;
    public Button mainButton;

    // Start is called before the first frame update
    void Start()
    {
        textointentosfallidos.text = "Intentos Fallidos:  " + intentosfallidos.ToString();
        ganaste.SetActive(false);
        mainButton.gameObject.SetActive(true);
        mainButton.onClick.AddListener(PlayMainMenu);

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

                
                }

            }





        }
       
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (puntosGanados == 0)
            {
                if (esverde==true)
                {
                    StartCoroutine(correctcourtine());
                    cicle1win = true;
                   
                }
                else
                {
                    intentosfallidos++;
                    textointentosfallidos.text = "Intentos Fallidos:  " + intentosfallidos.ToString();
                }
            }
            if (puntosGanados == 1)
            {
                if (esverde == true)
                {
                    StartCoroutine(correctcourtine());
                    cicle2win = true;
                  
                }
                else
                {
                    intentosfallidos++;
                    textointentosfallidos.text = "Intentos Fallidos:  " + intentosfallidos.ToString();
                }
            }

            if (puntosGanados == 2)
            {
                if (esverde == true)
                {
                    StartCoroutine(correctcourtine());
                    cicle3win = true;

                }
                else
                {
                    intentosfallidos++;
                    textointentosfallidos.text = "Intentos Fallidos:  " + intentosfallidos.ToString();
                }
            }

        }
       
    }


   
    public IEnumerator correctcourtine()
    {
        yield return new WaitForSeconds(0.4f);
        correct.GetComponent<AudioSource>().Play();

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
        numeroactual = Random.Range(0, parte1.transform.childCount);
        if (parte1.transform.GetChild(numeroactual).tag == "Verde")
        {

            esverde = true;
            parte1.transform.GetChild(numeroactual).GetComponent<Renderer>().material.EnableKeyword("_EMISSION");
            parte1.transform.GetChild(numeroactual).GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.green);
            yield return new WaitForSeconds(velocidadParte2);
            StartCoroutine(endcicle2());

        }
        else
        {
            yield return new WaitForSeconds(velocidadParte2);
            parte1.transform.GetChild(numeroactual).GetComponent<Renderer>().material.EnableKeyword("_EMISSION");
            parte1.transform.GetChild(numeroactual).GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.red);
            yield return new WaitForSeconds(velocidadParte2);
            StartCoroutine(endcicle2());
        }


        cambiocorrtinas = false;


    }





    public IEnumerator endcicle2()
    {

        yield return new WaitForSeconds(velocidadParte1);
        esverde = false;
        parte1.transform.GetChild(numeroactual).GetComponent<Renderer>().material.EnableKeyword("_EMISSION");
        parte1.transform.GetChild(numeroactual).GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.black);
        yield return new WaitForSeconds(velocidadParte2);



    }

    public IEnumerator parte3cicle()
    {

        yield return new WaitForSeconds(velocidadParte3);



        yield return new WaitForSeconds(velocidadParte3);
        numeroactual = Random.Range(0, parte1.transform.childCount);
        if (parte1.transform.GetChild(numeroactual).tag == "Verde")
        {

            esverde = true;
            parte1.transform.GetChild(numeroactual).GetComponent<Renderer>().material.EnableKeyword("_EMISSION");
            parte1.transform.GetChild(numeroactual).GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.green);
            yield return new WaitForSeconds(velocidadParte3);
            StartCoroutine(endcicle3());

        }
        else
        {
            yield return new WaitForSeconds(velocidadParte3);
            parte1.transform.GetChild(numeroactual).GetComponent<Renderer>().material.EnableKeyword("_EMISSION");
            parte1.transform.GetChild(numeroactual).GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.red);
            yield return new WaitForSeconds(velocidadParte3);
            StartCoroutine(endcicle3());
        }


        cambiocorrtinas = false;


    }





    public IEnumerator endcicle3()
    {

        yield return new WaitForSeconds(velocidadParte3);
        esverde = false;
        parte1.transform.GetChild(numeroactual).GetComponent<Renderer>().material.EnableKeyword("_EMISSION");
        parte1.transform.GetChild(numeroactual).GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.black);
        yield return new WaitForSeconds(velocidadParte3);



    }

    public IEnumerator wincicle1()
    {
        yield return new WaitForSeconds(0.1f);
      Indicators.transform.GetChild(0).GetComponent<Renderer>().material.EnableKeyword("_EMISSION");
        Indicators.transform.GetChild(0).GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.green);
        puntosGanados++;
        cambiocorrtinas = false;

    }
    public IEnumerator wincicle2()

    {
        yield return new WaitForSeconds(0.1f);

        Indicators.transform.GetChild(1).GetComponent<Renderer>().material.EnableKeyword("_EMISSION");
        Indicators.transform.GetChild(1).GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.green);
        puntosGanados++;

        cambiocorrtinas = false;
    }

    public IEnumerator wincicle3()

    {
        yield return new WaitForSeconds(0.1f);
        Indicators.transform.GetChild(2).GetComponent<Renderer>().material.EnableKeyword("_EMISSION");
        Indicators.transform.GetChild(2).GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.green);
        puntosGanados++;
        for (int i = 0; i < parte1.transform.childCount; i++)
        {
            yield return new WaitForSeconds(0.1f);
            parte1.transform.GetChild(i).GetComponent<Renderer>().material.EnableKeyword("_EMISSION");
            parte1.transform.GetChild(i).GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.green);
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
    public void PlayMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
