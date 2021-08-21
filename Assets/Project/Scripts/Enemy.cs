using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject deathVFX;
    [Tooltip("Material to display when the enemy is hit")][SerializeField] Material hitMaterial;
    private Material _standardMaterial;
    private MeshRenderer _meshRenderer;
    private readonly float _hitDisplayTime = 0.3f;

    [Tooltip("How much to increase the player's score")] [SerializeField] private int _scoreIncrementation = 10;
    [SerializeField] private int _hp = 10;
    private ScoreBoard _scoreBoard;

    void Start()
    {
        _scoreBoard = FindObjectOfType<ScoreBoard>();
        _meshRenderer = GetComponent<MeshRenderer>();
        _standardMaterial = _meshRenderer.material;
        Rigidbody rb = gameObject.AddComponent<Rigidbody>() as Rigidbody;
        rb.useGravity = false;
    }

    public void OnParticleCollision(GameObject other)
    {
        IncreasePlayerScore();
        _hp--;
        if (_hp == 0) DestroyShip();
        else StartCoroutine(PlayHitAnimation());
    }

    private void IncreasePlayerScore()
    {
        _scoreBoard.ModifyScore(_scoreIncrementation);
    }

    private void DestroyShip() {
        Instantiate(deathVFX, transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }

    private IEnumerator PlayHitAnimation() {
        _meshRenderer.material = hitMaterial;
        yield return new WaitForSeconds(_hitDisplayTime);
        _meshRenderer.material = _standardMaterial;
    }
}
