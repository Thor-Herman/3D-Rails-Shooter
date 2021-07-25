using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    // NB! Remember the ship has several colliders. Might lead to bugs in the future. 
    
    void OnCollisionEnter(Collision other) {
        Debug.Log(other.gameObject.name);
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name);
    }
}
