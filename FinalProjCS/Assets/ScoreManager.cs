using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    // Start is called before the first frame update
    public Text ScoreText;
    private int score = 0;
    void Start()
    {
        UpdateScoreUI();
    }
    public void IncreaseScore(int amount){
        score += amount;
        UpdateScoreUI();
    }
    // Update is called once per frame
    void UpdateScoreUI()
    {
        ScoreText.text = "Score: " + score;
    }
}
