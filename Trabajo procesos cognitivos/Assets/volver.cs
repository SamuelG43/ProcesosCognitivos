using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class volver : MonoBehaviour
{
    public Button regreso;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(regreso.enabled==true)
        {
            regreso.onClick.AddListener(PlayMainMenu);
        }
    }

    public void PlayMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
