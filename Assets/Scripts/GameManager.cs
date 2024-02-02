using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int score;
    public static GameManager inst;
    public Text ScoreText;
    

    public void ADD_score()
    {
        score++;
        ScoreText.text = "Arcs : " + score.ToString();
    }
    private void Awake()
    {
        inst = this;
    }
}
