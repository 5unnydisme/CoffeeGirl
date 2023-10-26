using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPosition : MonoBehaviour
{
    private SpawnManager spawnManager; 

    // Start is called before the first frame update
    void Start()
    {
       spawnManager = GameObject.FindGameObjectWithTag("SpawnManager").GetComponent<SpawnManager>();
       transform.position = spawnManager.lastCheckpointPos; 
 
    }

   
}
