using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Shoot_Projectile : MonoBehaviour
{
    public Transform shootPoint; 
    public GameObject boltPrefab; 

    void Update()
    {
       if (Input.GetButtonDown("Fire1"))
       {
        Shoot();
       } 
    }

    void Shoot ()
    {
        Instantiate (boltPrefab, shootPoint.position, shootPoint.rotation);
    
    }
}
