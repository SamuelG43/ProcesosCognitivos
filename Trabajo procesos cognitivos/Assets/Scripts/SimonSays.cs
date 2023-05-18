using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimonSays : MonoBehaviour
{
    public GameObject whiteButton;
    public List<GameObject> buttons;
    public int sequenceLength;
    public float sequenceDelay;
    public float sequenceDelayPressed;
    private Ray ray;
    private RaycastHit hit;
    private List<int> sequence = new List<int>();
    private int currentIndex = 0;
    private bool playerTurn = false;
    private Color colorWhite;
    private Color colorRed;
    private Color colorBlue;
    private Color colorgreen;
    private Color coloryellow;
    private Color colorRedlit;
    private Color colorBlueLit;
    private Color colorGreenLit;
    private Color colorYellowLit;
    private Color colorWhitelit;
    public GameObject failsound;
 public bool acabar=false;
    public float tiempoEntreNiveles;
public bool oprimirbool=false;
    private int Nivelactual;
    int actualnumber;
    private  int puntos=0;
    public GameObject indicators;

   private int indicatorsnumber=0;
    int primarysecuence;

    public GameObject azul;
  

    // Start is called before the first frame update
    void Start()
    {
        azul.transform.GetComponent<Renderer>().material.EnableKeyword("_EMISSION");
        azul.transform.GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.red);
        primarysecuence = sequenceLength;
        for (int i = 0; i < indicators.transform.childCount; i++)
        {
            indicators.transform.GetChild(i).GetComponent<Renderer>().material.EnableKeyword("_EMISSION");
            indicators.transform.GetChild(i).GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.red);
        }
        colorWhite = whiteButton.transform.GetComponent<Renderer>().material.color;
        if(buttons.Count==4)
        { 
        colorRed = buttons[0].transform.GetComponent<Renderer>().material.color;
       colorBlue = buttons[1].transform.GetComponent<Renderer>().material.color;
        colorgreen = buttons[2].transform.GetComponent<Renderer>().material.color;
         coloryellow = buttons[3].transform.GetComponent<Renderer>().material.color;
            }
        if (buttons.Count == 4)
        {
            colorRedlit = new Color(buttons[0].transform.GetComponent<Renderer>().material.color.r + 0.3f, buttons[0].transform.GetComponent<Renderer>().material.color.g, buttons[0].transform.GetComponent<Renderer>().material.color.b, buttons[0].transform.GetComponent<Renderer>().material.color.a);
            colorBlueLit = new Color(buttons[1].transform.GetComponent<Renderer>().material.color.r, buttons[1].transform.GetComponent<Renderer>().material.color.g, buttons[1].transform.GetComponent<Renderer>().material.color.b + 0.3f, buttons[1].transform.GetComponent<Renderer>().material.color.a);
            colorGreenLit = new Color(buttons[2].transform.GetComponent<Renderer>().material.color.r, buttons[2].transform.GetComponent<Renderer>().material.color.g + 0.3f, buttons[2].transform.GetComponent<Renderer>().material.color.b, buttons[2].transform.GetComponent<Renderer>().material.color.a);
            colorYellowLit = new Color(buttons[3].transform.GetComponent<Renderer>().material.color.r, buttons[3].transform.GetComponent<Renderer>().material.color.g + 0.3f, buttons[3].transform.GetComponent<Renderer>().material.color.b, buttons[3].transform.GetComponent<Renderer>().material.color.a);
        }
        colorWhitelit = Color.gray;
        actualnumber = sequenceLength;
    }

    // Update is called once per frame
    void Update()
    {
        ray =
          Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Input.GetMouseButtonDown(0))
        {

            if (Physics.Raycast(ray, out hit))
            {
             
                if (acabar == false)
                {
                    if (hit.collider != null && hit.collider.transform.name == "Button_Object_start")
                    {
                        indicatorsnumber = 0;
                        puntos = 0;
                        sequenceLength = primarysecuence;
                        StartCoroutine(PlaySequencePressed(4));
                        GenerateSequence();
                        StartCoroutine(PlaySequence());
                        playerTurn = true;
                    }
                    if (hit.collider != null && hit.collider.transform.name == "Button_Object_red")
                    {
                        StartCoroutine(PlaySequencePressed(0));
                    }
                    if (hit.collider != null && hit.collider.transform.name == "Button_Object_blue")
                    {
                        StartCoroutine(PlaySequencePressed(1));
                    }
                    if (hit.collider != null && hit.collider.transform.name == "Button_Object_green")
                    {
                        StartCoroutine(PlaySequencePressed(2));
                    }
                    if (hit.collider != null && hit.collider.transform.name == "Button_Object_yellow")
                    {
                        StartCoroutine(PlaySequencePressed(3));
                    }
                }
            }
        }
        if (playerTurn)
        {
            // check if player clicked the correct button
            if (Input.GetMouseButtonDown(0))
            {
                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.collider.tag == "button")
                    {
                        Debug.Log(hit.collider.name.ToString());
                        if (hit.collider != null && hit.collider.gameObject == buttons[sequence[currentIndex]])
                        {
                            currentIndex++;

                        }
                        else
                        {
                            if (hit.collider != null && hit.collider.transform.name == "Button_Object_start")
                            {
                                indicatorsnumber = 0;
                                currentIndex = 0;
                                sequenceLength = primarysecuence;
                
                                azul.transform.GetComponent<Renderer>().material.EnableKeyword("_EMISSION");
                                azul.transform.GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.red);
                                Debug.Log("Game Over");
                                puntos = 0;
                                for (int i = 0; i < indicators.transform.childCount; i++)
                                {
                                    indicators.transform.GetChild(i).GetComponent<Renderer>().material.EnableKeyword("_EMISSION");
                                    indicators.transform.GetChild(i).GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.red);
                                }
                                playerTurn = false;
                            }
                            else
                            {
                                indicatorsnumber = 0;
                                currentIndex = 0;
                                sequenceLength = primarysecuence;
                                StartCoroutine(failsoundcoroutine());
                                azul.transform.GetComponent<Renderer>().material.EnableKeyword("_EMISSION");
                                azul.transform.GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.red);
                                Debug.Log("Game Over");
                                puntos = 0;
                                for (int i = 0; i < indicators.transform.childCount; i++)
                                {
                                    indicators.transform.GetChild(i).GetComponent<Renderer>().material.EnableKeyword("_EMISSION");
                                    indicators.transform.GetChild(i).GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.red);
                                }
                                playerTurn = false;
                            }
                        }

                        if (currentIndex == sequence.Count)
                        {
                            puntos++;
                            if (puntos == indicators.transform.childCount)
                            {
                                StartCoroutine(tiempoExtra());
                                Ganaste();
                                playerTurn = false;
                                currentIndex = 0;
                                acabar = true;
                            }
                            else
                            {
                                playerTurn = false;
                                currentIndex = 0;



                                avanzarnivel();



                            }


                        }
                    }
                }
            }

        }
    }

    public IEnumerator failsoundcoroutine()
    {
        yield return new WaitForSeconds(0.2f);
        failsound.GetComponent<AudioSource>().Play();
    }
    public void avanzarnivel()
    {
        
                sequenceLength= actualnumber + puntos;

        
        GenerateSequence();
        StartCoroutine(PlaysecuenceTiempo());
        StartCoroutine(tiempoExtra());
        
    }    

  

    public void Ganaste()
    {
        Debug.Log("Ganaste");
    }

    public void GenerateSequence()
    {
        sequence.Clear();

        for (int i = 0; i < sequenceLength; i++)
        {
            sequence.Add(Random.Range(0, buttons.Count));
        }
    }

  public  IEnumerator PlaySequence()
    {
        azul.transform.GetComponent<Renderer>().material.EnableKeyword("_EMISSION");
        azul.transform.GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.red);
        yield return new WaitForSeconds(0.3f);

        foreach (int i in sequence)
        {
            if(buttons[i].transform.GetComponent<Renderer>().material.color==colorRed)
            {
                buttons[i].transform.GetComponent<Renderer>().material.color = colorRedlit;
                buttons[i].transform.GetComponent<Renderer>().material.EnableKeyword("_EMISSION");
                buttons[i].transform.GetComponent<Renderer>().material.SetColor("_EmissionColor", colorRedlit);
                buttons[i].gameObject.GetComponent<AudioSource>().Play();
            }
            else if (buttons[i].transform.GetComponent<Renderer>().material.color == colorBlue)
            {
                buttons[i].transform.GetComponent<Renderer>().material.color = colorBlueLit;
                buttons[i].transform.GetComponent<Renderer>().material.EnableKeyword("_EMISSION");
                buttons[i].transform.GetComponent<Renderer>().material.SetColor("_EmissionColor", colorBlueLit);
                buttons[i].gameObject.GetComponent<AudioSource>().Play();
            }
            else if (buttons[i].transform.GetComponent<Renderer>().material.color == colorgreen)
            {
                buttons[i].transform.GetComponent<Renderer>().material.color = colorGreenLit;
                buttons[i].transform.GetComponent<Renderer>().material.EnableKeyword("_EMISSION");
                buttons[i].transform.GetComponent<Renderer>().material.SetColor("_EmissionColor", colorGreenLit);
                buttons[i].gameObject.GetComponent<AudioSource>().Play();

            }

            else if (buttons[i].transform.GetComponent<Renderer>().material.color == coloryellow)
            {
                buttons[i].transform.GetComponent<Renderer>().material.color = colorYellowLit;
                buttons[i].transform.GetComponent<Renderer>().material.EnableKeyword("_EMISSION");
                buttons[i].transform.GetComponent<Renderer>().material.SetColor("_EmissionColor", colorYellowLit);
                buttons[i].gameObject.GetComponent<AudioSource>().Play();
            }

            //buttons[i].GetComponent<AudioSource>().Play();
            yield return new WaitForSeconds(sequenceDelay);

            if (buttons[i].transform.GetComponent<Renderer>().material.color == colorRedlit)
            {
                buttons[i].transform.GetComponent<Renderer>().material.color = colorRed;
                buttons[i].transform.GetComponent<Renderer>().material.EnableKeyword("_EMISSION");
                buttons[i].transform.GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.black);
            }
            else if (buttons[i].transform.GetComponent<Renderer>().material.color == colorBlueLit)
            {
                buttons[i].transform.GetComponent<Renderer>().material.color = colorBlue;
                buttons[i].transform.GetComponent<Renderer>().material.EnableKeyword("_EMISSION");
                buttons[i].transform.GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.black);
            }
            else if (buttons[i].transform.GetComponent<Renderer>().material.color == colorGreenLit)
            {
                buttons[i].transform.GetComponent<Renderer>().material.color = colorgreen;
                buttons[i].transform.GetComponent<Renderer>().material.EnableKeyword("_EMISSION");
                buttons[i].transform.GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.black);
            }

            else if (buttons[i].transform.GetComponent<Renderer>().material.color == colorYellowLit)
            {
                buttons[i].transform.GetComponent<Renderer>().material.color = coloryellow;
                buttons[i].transform.GetComponent<Renderer>().material.EnableKeyword("_EMISSION");
                buttons[i].transform.GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.black);
            }

            //buttons[i].GetComponent<AudioSource>().Play();
            yield return new WaitForSeconds(sequenceDelay);
        }

        playerTurn = true;
        azul.transform.GetComponent<Renderer>().material.EnableKeyword("_EMISSION");
        azul.transform.GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.blue);
    }


   public IEnumerator PlaySequencePressed(int i)
    {
        yield return new WaitForSeconds(0.3f);

        
            if (i==0)
            {
            buttons[i].transform.GetComponent<Renderer>().material.color = colorRedlit;
            buttons[i].transform.GetComponent<Renderer>().material.EnableKeyword("_EMISSION");
            buttons[i].transform.GetComponent<Renderer>().material.SetColor("_EmissionColor", colorRedlit);
            buttons[i].gameObject.GetComponent<AudioSource>().Play();
        }
            else if (i == 1)
            {
            buttons[i].transform.GetComponent<Renderer>().material.color = colorBlueLit;
            buttons[i].transform.GetComponent<Renderer>().material.EnableKeyword("_EMISSION");
            buttons[i].transform.GetComponent<Renderer>().material.SetColor("_EmissionColor", colorBlueLit);
            buttons[i].gameObject.GetComponent<AudioSource>().Play();
        }
            else if (i == 2)
            {
            buttons[i].transform.GetComponent<Renderer>().material.color = colorGreenLit;
            buttons[i].transform.GetComponent<Renderer>().material.EnableKeyword("_EMISSION");
            buttons[i].transform.GetComponent<Renderer>().material.SetColor("_EmissionColor", colorGreenLit);
            buttons[i].gameObject.GetComponent<AudioSource>().Play();
        }

            else if (i == 3)
            {
            buttons[i].transform.GetComponent<Renderer>().material.color = coloryellow;
            buttons[i].transform.GetComponent<Renderer>().material.EnableKeyword("_EMISSION");
            buttons[i].transform.GetComponent<Renderer>().material.SetColor("_EmissionColor", colorYellowLit);
            buttons[i].gameObject.GetComponent<AudioSource>().Play();
        }
        else if  (i==4)
        {
            whiteButton.transform.GetComponent<Renderer>().material.color = colorWhitelit;
            whiteButton.transform.GetComponent<Renderer>().material.EnableKeyword("_EMISSION");
            whiteButton.transform.GetComponent<Renderer>().material.SetColor("_EmissionColor", colorWhitelit);
        }

        //buttons[i].GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(sequenceDelayPressed);

            if (i==0)
            {
            buttons[0].transform.GetComponent<Renderer>().material.color = colorRed;
            buttons[i].transform.GetComponent<Renderer>().material.EnableKeyword("_EMISSION");
            buttons[i].transform.GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.black);
        }
            else if (i==1)
            {
            buttons[1].transform.GetComponent<Renderer>().material.color = colorBlue;
            buttons[i].transform.GetComponent<Renderer>().material.EnableKeyword("_EMISSION");
            buttons[i].transform.GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.black);
        }
            else if (i == 2)
            {
            buttons[2].transform.gameObject.GetComponent<Renderer>().material.color = colorgreen;
            buttons[i].transform.GetComponent<Renderer>().material.EnableKeyword("_EMISSION");
            buttons[i].transform.GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.black);
        }

            else if (i == 3)
            {
            buttons[3].transform.gameObject.GetComponent<Renderer>().material.color = coloryellow;
            buttons[i].transform.GetComponent<Renderer>().material.EnableKeyword("_EMISSION");
            buttons[i].transform.GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.black);
        }
            else if(i==4)
        {
            whiteButton.transform.GetComponent<Renderer>().material.color = colorWhite;
            whiteButton.transform.GetComponent<Renderer>().material.EnableKeyword("_EMISSION");
            whiteButton.transform.GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.black);
        }
            //buttons[i].GetComponent<AudioSource>().Play();
            yield return new WaitForSeconds(sequenceDelayPressed);
        
    }


    public IEnumerator PlaysecuenceTiempo()
    {
        yield return new WaitForSeconds(tiempoEntreNiveles);
        StartCoroutine(PlaySequence());
    }
    public IEnumerator tiempoExtra()
    {
        yield return new WaitForSeconds(1.5f);
        indicators.transform.GetChild(indicatorsnumber).GetComponent<Renderer>().material.EnableKeyword("_EMISSION");
        indicators.transform.GetChild(indicatorsnumber).GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.green);
        indicatorsnumber++;
    }


    public void puntoscero()
    {
        puntos = 0;
    }

    public void indicatorscero()
    {
        indicatorsnumber = 0;
    }

    
}
