using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using PlayFab;
using PlayFab.ClientModels;
using System.Collections.Generic;
public class GameManager : MonoBehaviour
{
    public int score = 0;
    public int health = 5;
    public AudioSource losemusic;
    public AudioSource winmusic;
    public Text scoreText;
    public GameObject[] healthIcons;
    public GameObject winText; 
    public GameObject loseText; 
    public float delayTime = 2f;
    public static GameManager Instance { get; private set; }
    private bool sceneLoaded = false; 
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            SceneManager.sceneLoaded += OnSceneLoaded; 
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        sceneLoaded = false;
    }

    private void Update()
    {
        if (!sceneLoaded)
        {
            SetupScene();
            sceneLoaded = true;
        }
    }
    void UpdateScoreAndHealthDisplay()
    {
        scoreText.text = "SCORE: " + score;
        
        for (int i = 0; i < healthIcons.Length; i++)
        {
            healthIcons[i].SetActive(i < health);
        }
    }
    public void SetupScene()
    {
        scoreText = GameObject.Find("ScoreText").GetComponent<Text>(); 
        healthIcons = GameObject.FindGameObjectsWithTag("healthIcons"); 
        UpdateScoreAndHealthDisplay(); 
    }

    void tiaozhaun()
    {
        SceneManager.LoadScene("denglu");
    }
    public void AddScore()
    {
        score++;
        UpdateScoreAndHealthDisplay();

        if (score >= 5)
        {
            winText.SetActive(true);
            Invoke("tiaozhaun", delayTime);
        }
    }

    public void TakeDamage()
    {
        health--;
        UpdateScoreAndHealthDisplay();

        if (health <= 0)
        {
            loseText.SetActive(true); 
            Invoke("tiaozhaun", delayTime);
        }
    }

    public void loseplay()
         {
             losemusic.Play();
         }
    public void winplay()
    {
        winmusic.Play();
    }
    
}