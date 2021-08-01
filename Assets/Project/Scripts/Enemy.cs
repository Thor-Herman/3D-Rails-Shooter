using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject deathVFX;
    [Tooltip("How much to increase the player's score")] [SerializeField] private int _scoreIncrementation = 10;
    private ScoreBoard _scoreBoard;
    private bool _hasBeenHit = false;

    void Start()
    {
        _scoreBoard = FindObjectOfType<ScoreBoard>();
    }

    public void OnParticleCollision(GameObject other)
    {
        if (!_hasBeenHit)
        {
            _hasBeenHit = true;
            _scoreBoard.ModifyScore(_scoreIncrementation);
            Instantiate(deathVFX, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
}
