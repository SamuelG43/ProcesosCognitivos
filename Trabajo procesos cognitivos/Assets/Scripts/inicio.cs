using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inicio : MonoBehaviour
{

    public GameObject portada;
    public GameObject instrucciones;
    public GameObject otherUi;
    private int fases = 0;
    // Start is called before the first frame update
    void Start()
    {
        portada.SetActive(true);
        instrucciones.SetActive(false);
        otherUi.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(fases==1)
        {
            portada.SetActive(false);
            instrucciones.SetActive(true);
        }

        if(fases==2)
        {
            instrucciones.SetActive(false);
            otherUi.SetActive(true);
        }

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            fases++;
        }
    }
}
