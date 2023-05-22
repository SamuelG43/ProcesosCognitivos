using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StroopScript2 : MonoBehaviour
{
    public TextMeshProUGUI colorText;
    public TextMeshProUGUI messageText;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI timerText;
    public Button restartButton;
    public Button startButton;
    public GameObject failsound;
    public GameObject correctSound;


    private int indNombre;
    private int score = 0;
    private int attempt = 0;
    private float timer = 100f;

    private string[] colorNames = { "ROJO", "VERDE", "AZUL", "NARANJA", "MORADO" };
    private Color[] colors = { Color.red, Color.green, Color.blue, new Color(1f, 0.5f, 0f), new Color(0.5f, 0f, 1f) };

    private bool gameActive = false;

    void Start()
    {
        restartButton.gameObject.SetActive(false);
        startButton.onClick.AddListener(StartGame);

    }

    void StartGame()
    {
        startButton.gameObject.SetActive(false);
        restartButton.gameObject.SetActive(false);
        gameActive = true;
        StartCoroutine(ShowStroopText());
    }

    void Update()
    {
        if (gameActive)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                CheckAnswer(Color.red);
            }
            else if (Input.GetKeyDown(KeyCode.V))
            {
                CheckAnswer(Color.green);
            }
            else if (Input.GetKeyDown(KeyCode.A))
            {
                CheckAnswer(Color.blue);
            }

            else if (Input.GetKeyDown(KeyCode.N))
            {
                CheckAnswer(new Color(1f, 0.5f, 0f));
            }
            else if (Input.GetKeyDown(KeyCode.M))
            {
                CheckAnswer(new Color(0.5f, 0f, 1f));
            }

            UpdateTimer();
        }
    }

    IEnumerator ShowStroopText()
    {
        timer = 6;
        yield return new WaitForSeconds(1f);

        int colorIndex = Random.Range(0, 5);
        int nameIndex = Random.Range(0, 5);
        indNombre = colorIndex;

        colorText.text = colorNames[nameIndex];
        colorText.color = colors[colorIndex];

        messageText.text = "PRESIONA ";

        attempt++;
        scoreText.text = "Puntos: " + score.ToString() + " / 10";

        if (attempt > 10)
        {
            EndGame();
            yield break;
        }

        yield return new WaitForSeconds(1f);

        colorText.text = "";
        colorText.color = Color.white;

        messageText.text = "";


    }

    void CheckAnswer(Color color)
    {
        if (color == colors[indNombre])
        {
            correctSound.GetComponent<AudioSource>().Play();
            timer = 6;
            score++;
            StartCoroutine(ShowStroopText());
        }
        else
        {
            timer = 6;
            messageText.text = "WRONG";
            StartCoroutine(ShowStroopText());
            failsound.GetComponent<AudioSource>().Play();
        }
    }

    void UpdateTimer()
    {
        timer -= Time.deltaTime;
        timerText.text = "Tiempo: " + Mathf.Round(timer).ToString();

        if (timer <= 0)
        {

            CheckAnswer(Color.white);
        }
    }

    void EndGame()
    {
        gameActive = false;
        messageText.text = "Juego Terminado";
        colorText.text = "";
        colorText.color = Color.white;
        restartButton.gameObject.SetActive(true);
   
   
    }

    public void RestartGame()
    {
        score = 0;
        attempt = 0;
        timer = 6f;
        gameActive = true;
        restartButton.gameObject.SetActive(false);
        StartCoroutine(ShowStroopText());
    }
}