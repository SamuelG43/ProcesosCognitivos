using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Button playStroop;
    public Button playSimon;
    public Button playLight;

    private void Start()
    {
        playStroop.onClick.AddListener(PlayStroopGame);
        playSimon.onClick.AddListener(PlaySimonGame);
        playLight.onClick.AddListener(PlayLightGame);
    }

    public void PlayStroopGame()
    {
        SceneManager.LoadScene(3);
    }
    public void PlaySimonGame()
    {
        SceneManager.LoadScene(1);
    }
    public void PlayLightGame()
    {
        SceneManager.LoadScene(2);
    }
}
