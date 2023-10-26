using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxBG : MonoBehaviour
{
    public Transform mainCamera;
    public float parallaxAmount;

    private float length;
    private float startPos;

    // Start is called before the first frame update
    void Start()
    {
       startPos = transform.position.x; 
       length = GetComponent<SpriteRenderer>().bounds.size.x; 
    }

    // Update is called once per frame
    void Update()
    {
      float temp = (mainCamera.position.x * (1f - parallaxAmount));  
      float dist = (mainCamera.position.x * parallaxAmount);
      transform.position = new Vector3(startPos + dist, transform.position.y, transform.position.z);
    if (temp > startPos + length)
    {
        startPos += length;

    }
    else if (temp < startPos - length)
    {
        startPos -= length;
    }
    }
}
