using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class Coin_Collection : MonoBehaviour
{
    public TextMeshProUGUI coinText;
    public int coinCount; 
    // Start is called before the first frame update
    void Start()
    {
       coinCount = 0;  
    }

   void OnTriggerEnter2D(Collider2D other)
   {
    if (other.CompareTag("Coin"))
    {
        other.gameObject.GetComponent<SpriteRenderer>().enabled = false;
        other.gameObject.GetComponent<Collider2D>().enabled = false;
        other.gameObject.GetComponent<AudioSource>().Play();
        Destroy(other.gameObject, 1f);

        coinCount ++;
        coinText.text = coinCount.ToString();
    }
   }
}
