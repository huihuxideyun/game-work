using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int score = 0;
    public int health = 5;

    public Text scoreText;
    public GameObject[] healthIcons;
    public GameObject winText; 
    public GameObject loseText; 

    void UpdateScoreAndHealthDisplay()
    {
        scoreText.text = "SCORE: " + score;

        for (int i = 0; i < healthIcons.Length; i++)
        {
            healthIcons[i].SetActive(i < health);
        }
    }

    public void AddScore()
    {
        score++;
        UpdateScoreAndHealthDisplay();

        if (score >= 5)
        {
            winText.SetActive(true);
        }
    }

    public void TakeDamage()
    {
        health--;
        UpdateScoreAndHealthDisplay();

        if (health <= 0)
        {
            loseText.SetActive(true); 
        }
    }
}