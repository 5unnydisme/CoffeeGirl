using System.Collections;
using System.Collections.Generic;
using UnityEngine;
    
   
public class Bolt_Projectile : MonoBehaviour
{
    // Start is called before the first frame update
        public float speed;
    private Rigidbody2D rb;
    public GameObject explodePrefab;
    private Collider2D col;
    private SpriteRenderer spriteRenderer;


    // Update is called once per frame
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * speed;
        col = GetComponent<Collider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        Destroy(gameObject, 3.0f);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
       if (other.CompareTag("Platform") || other.CompareTag("Enemy"))
       {
        Instantiate(explodePrefab, gameObject.transform.position, gameObject.transform.rotation);
        col.enabled = false;
        spriteRenderer.enabled = false;
        Destroy(gameObject, 1.5f);
       }
        
    }
}
