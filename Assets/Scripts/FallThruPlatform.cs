using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallThruPlatform : MonoBehaviour
{
    private Collider2D platformCOllider;
    private bool playerOnPlatform; 

    // Start is called before the first frame update
    void Start()
    {
     platformCOllider = GetComponent<Collider2D>();

    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log (playerOnPlatform);

        if (playerOnPlatform == true && Input.GetAxisRaw("Vertical")<0)
        {
            platformCOllider.enabled = false; 
            StartCoroutine(EnableCOllider());
        }
    }

    private IEnumerator EnableCOllider()
    {
        yield return new WaitForSeconds(0.5f);
        platformCOllider.enabled = true; 
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerOnPlatform = true; 
        }
    }

private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerOnPlatform = false; 
        }
    }
}
