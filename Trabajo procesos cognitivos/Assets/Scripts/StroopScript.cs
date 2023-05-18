using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class StroopScript : MonoBehaviour
{
    
        public TextMeshProUGUI colorText;
        public TextMeshProUGUI messageText;
        public TextMeshProUGUI scoreText;
        private int indNombre;
        private int score = 0;
        private int attempt = 0;
        private string[] colorNames = { "RED", "GREEN", "BLUE", "YELLOW", "ORANGE", "PURPLE" };
        private Color[] colors = { Color.red, Color.green, Color.blue, Color.yellow, new Color(1f, 0.5f, 0f), new Color(0.5f, 0f, 1f) };

        // Start is called before the first frame update
        void Start()
        {
            StartCoroutine(ShowStroopText());
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                CheckAnswer(Color.red);
            }
            else if (Input.GetKeyDown(KeyCode.G))
            {
                CheckAnswer(Color.green);
            }
            else if (Input.GetKeyDown(KeyCode.B))
            {
                CheckAnswer(Color.blue);
            }
            else if (Input.GetKeyDown(KeyCode.Y))
            {
                CheckAnswer(Color.yellow);
            }
            else if (Input.GetKeyDown(KeyCode.O))
            {
                CheckAnswer(new Color(1f, 0.5f, 0f));
            }
            else if (Input.GetKeyDown(KeyCode.P))
            {
                CheckAnswer(new Color(0.5f, 0f, 1f));
            }
        }

        IEnumerator ShowStroopText()
        {
            // Wait for a second
            yield return new WaitForSeconds(1f);

            // Randomly select a color and a name
            int colorIndex = Random.Range(0, 6);
            int nameIndex = Random.Range(0, 6);
            indNombre = colorIndex;

            // Set the color and the name of the color text
            colorText.text = colorNames[nameIndex];
            colorText.color = colors[colorIndex];

            // Set the message text to "PRESS [COLOR NAME]"
            messageText.text = "PRESS " + colorNames[nameIndex];

            // Increment the attempt counter
            attempt++;

            // Update the score text
            scoreText.text = "Score: " + score.ToString() + " / 10";

            // Check if the maximum number of attempts has been reached
            if (attempt > 10)
            {
                // End the game
                messageText.text = "GAME OVER";
                yield break;
            }

            // Wait for a second
            yield return new WaitForSeconds(1f);

            // Clear the color and name of the color text
            colorText.text = "";
            colorText.color = Color.white;

            // Clear the message text
            messageText.text = "";
        }

        void CheckAnswer(Color color)
        {
            
                if (color == colors[indNombre])
                {
                    // Update the score
                    score++;

                    // Show the next Stroop text
                    StartCoroutine(ShowStroopText());
                }
               else
               {
            // Show the message "WRONG"
            messageText.text = "WRONG";

            // Show the next Stroop text
            StartCoroutine(ShowStroopText());
               }

        // Check if the color name matches the pressed key

        }
    
}

