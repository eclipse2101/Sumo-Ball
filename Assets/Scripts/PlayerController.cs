using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed; 
     Rigidbody playerRb; 
     GameObject focalpoint; 

    
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        focalpoint = GameObject.Find("focus point");
    }

    // Update is called once per frame
    void Update()
    {
      float vertical = Input.GetAxis("Vertical"); 
      playerRb.AddForce(focalpoint.transform.forward * speed * vertical); 
    }
}
