using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    void Awake() {
        int instanceCount = FindObjectsOfType<MusicPlayer>().Length;
        if (instanceCount > 1) Destroy(gameObject);
        else DontDestroyOnLoad(gameObject);
    }
}
