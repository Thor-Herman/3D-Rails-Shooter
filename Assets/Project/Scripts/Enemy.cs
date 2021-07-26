using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public void OnParticleCollision(GameObject other)
    {
        Destroy(this.gameObject);
    }
}
