using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreBoard : MonoBehaviour
{
    private int _score;
    private TMP_Text _scoreText;

    void Start()
    {
        _scoreText = GetComponent<TMP_Text>();
    }
    
    public void ModifyScore(int change) {
        _score += change;
        _scoreText.SetText("Score: " + _score.ToString());
    }
}
