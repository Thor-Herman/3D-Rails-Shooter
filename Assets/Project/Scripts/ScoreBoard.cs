using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreBoard : MonoBehaviour
{
    private int _score;

    public void ModifyScore(int change) {
        _score += change;
        Debug.Log(_score);
    }
}
