using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private static SpawnManager instance;
    public Vector2 lastCheckpointPos; 

    void Awake()
    {
        if(instance == null)
        {
            instance = this; 
            DontDestroyOnLoad (instance);
        }
        else 
        {
            Destroy(gameObject);
        }
    }
}
