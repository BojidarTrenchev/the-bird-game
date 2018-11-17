using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PauseManager : MonoBehaviour
{
    private GameObject panel;
    private GameObject resumeButton;
    private float offset;
    public float buttonPosition = 25;

    // Use this for initialization
    void Awake()
    {
        this.panel = GameObject.FindGameObjectWithTag("ExitPanel");
        this.resumeButton = GameObject.Find("Resume");
        this.resumeButton.SetActive(false);
    }

    public void Update()
    {
        if (BirdController.isDead)
        {
            this.gameObject.SetActive(false);
        }
    }

    public void OnPausePress()
    {
        Time.timeScale = 0;
        this.resumeButton.SetActive(true);
        this.panel.SetActive(true);
        this.gameObject.SetActive(false);
    }

    public void OnResumePress()
    {
        Time.timeScale = 1;
        this.resumeButton.SetActive(false);
        this.panel.SetActive(false);
        this.gameObject.SetActive(true);
    }
}
