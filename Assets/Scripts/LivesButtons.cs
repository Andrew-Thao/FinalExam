using UnityEngine;
using UnityEngine.UI;

public class LivesButtons : MonoBehaviour
{
    //remember to create empty game object and drag script in
    public Text livesText;
    public Button decreaseButton;
    public Button increaseButton;

    public static int lives;

    void Start()
    {
        // Get the number of lives from the PlayerPrefs variable
        lives = PlayerPrefs.GetInt("lives", 3); // Default to 3 lives if the variable is not set

        // Set the lives text to the number of lives
        livesText.text = "Lives: " + lives.ToString();

        // Add listeners to the decrease and increase buttons
        decreaseButton.onClick.AddListener(DecreaseLives);
        increaseButton.onClick.AddListener(IncreaseLives);
    }

    void DecreaseLives()
    {
        // Decrease the number of lives by 1
        lives--;

        // Save the new number of lives to the PlayerPrefs variable
        PlayerPrefs.SetInt("lives", lives);

        // Update the lives text
        livesText.text = "Lives: " + lives.ToString();
    }

    void IncreaseLives()
    {
        // Increase the number of lives by 1
        lives++;

        // Save the new number of lives to the PlayerPrefs variable
        PlayerPrefs.SetInt("lives", lives);

        // Update the lives text
        livesText.text = "Lives: " + lives.ToString();
    }
}