using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private bool _isGameOver = false;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && _isGameOver) SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GameOver() {
        _isGameOver = true;
    }
}
