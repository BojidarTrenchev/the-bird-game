using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class MenuManager : MonoBehaviour
{
    public float showMenuTime = 3f;

    public GameObject panel;
    private Text highScore;

    // Use this for initialization
    void Awake()
    {
        this.panel = GameObject.FindGameObjectWithTag("ExitPanel");
        this.highScore = GameObject.Find("HighScore").GetComponent<Text>();
        this.panel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {  
        if (BirdController.isDead)
        {
            this.Invoke("ShowMenu", showMenuTime);
        }
    }

    private void ShowMenu()
    {
        this.highScore.text = "Highscore: " + ScoreManager.highScore;
        this.panel.SetActive(true);
    }

    public void OnExitPress()
    {
        Application.Quit();
    }

    public void OnRestartPress()
    {
        Application.LoadLevel("Main");
        BirdController.isDead = false;
        Time.timeScale = 1;
    }
}
