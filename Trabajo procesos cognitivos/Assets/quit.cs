using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class quit : MonoBehaviour
{

    public Button salir;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        salir.onClick.AddListener(quitaction);
    }

    public void quitaction()
    {
        Application.Quit();
    }
}
