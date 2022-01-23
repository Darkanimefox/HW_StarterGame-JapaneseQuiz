using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeLimit : MonoBehaviour
{
    
    float currentTime = 0f;
    public float startingTime = 12f;
    public Text timerText;
    public GameObject losePanel;
    [SerializeField]
    public AudioSource bgMusic;
    [SerializeField]
    public AudioSource timeAudioGameOver;
    

    void Start()
    {
        currentTime = startingTime;
        bgMusic.PlayDelayed(2);
    }

    void Update()
    {
        currentTime -= 1*Time.deltaTime;

        float minutes = Mathf.FloorToInt(currentTime / 60);
        float seconds = Mathf.FloorToInt(currentTime % 60);

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        if(currentTime <= 0) {
            currentTime = 0;
            bgMusic.Stop();
            timeAudioGameOver.Play();
            losePanel.SetActive(true);
            Time.timeScale =0f;
        }
    }
}
