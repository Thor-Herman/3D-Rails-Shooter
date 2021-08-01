using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruct : MonoBehaviour
{
    [Tooltip("How long before self-destruct")][SerializeField] private float _delay = 1.0f;
    
    void Start() {
        Destroy(this.gameObject, _delay);
    }

}
