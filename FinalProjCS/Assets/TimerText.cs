using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerText : MonoBehaviour
{
    // Start is called before the first frame update
    public float totalTime = 600f;
    private float currTime = 0f;
    public Text timerText;
    public GameObject gameoverPanel;
    void Start()
    {
        currTime = totalTime;
        gameoverPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(currTime > 0){
            currTime -= Time.deltaTime;
            UpdateTimerText();
        }
        else{
            EndGame();
        }

    }
    void UpdateTimerText(){
        int min = Mathf.FloorToInt(currTime / 60);
        int sec = Mathf.FloorToInt(currTime % 60);

        timerText.text = string.Format("{0:00}:{1:00}", min, sec);
    }
    void EndGame(){
        gameoverPanel.SetActive(true);
        Debug.Log("Time Limit Reached. Game Over!");
    }
}
