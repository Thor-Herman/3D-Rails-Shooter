using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] float loadDelay = 1.0f;

    // NB! Remember the ship has several colliders. Might lead to bugs in the future. 
    void OnTriggerEnter(Collider other)
    {
        StartCoroutine(EndGame());
        Debug.Log(other.gameObject.name);
    }
    
    IEnumerator EndGame() {
        GetComponent<PlayerController>().enabled = false;
        yield return new WaitForSeconds(loadDelay);
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }
}
