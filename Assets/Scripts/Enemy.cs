using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float hitPoint;
    public float boltDamage;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bolt"))
        {
            hitPoint -= boltDamage;
        }

        if(hitPoint <= 0)
        {
            Destroy(gameObject);
        }
    }
}
