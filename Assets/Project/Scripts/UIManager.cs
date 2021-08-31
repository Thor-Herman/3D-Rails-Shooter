using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] PlayableDirector director;
    private TMP_Text _restartText;
    [SerializeField] GameObject[] guiElementsToDisableOnGameOver;

    void OnEnable()
    {
        director.stopped += OnPlayableDirectorStopped;
    }

    void Start()
    {
        _restartText = GameObject.Find("RestartText").GetComponent<TMP_Text>();
        _restartText.enabled = false;
    }

    void OnPlayableDirectorStopped(PlayableDirector aDirector)
    {
        if (director == aDirector)
        {
            GameObject.FindObjectOfType<GameManager>().GameOver();
            _restartText.enabled = true;
            foreach (GameObject obj in guiElementsToDisableOnGameOver)
            {
                obj.SetActive(false);
            }
        }
    }

    void OnDisable()
    {
        director.stopped -= OnPlayableDirectorStopped;
    }
}
