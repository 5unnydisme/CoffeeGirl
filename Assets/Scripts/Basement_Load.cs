using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Basement_Load : MonoBehaviour
{
    public int sceneBuildIndex;

    private void OnTriggerEnter2D(Collider2D other)
    {
        print("Trigger Entered");

        if (other.CompareTag("Player"))
            {
            SceneManager.LoadScene(sceneBuildIndex);
        }

        }
    }

