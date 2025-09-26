using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed; 
    Rigidbody badGuyRb; 
    GameObject player; 
    float bottomBound = -5;
    float sideBound = 25;
    
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        badGuyRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player"); 
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 lookDirection = (player.transform.position - transform.position).normalized;
        badGuyRb.AddForce( lookDirection * speed);
       
       
        if (transform.position.y < bottomBound || (transform.position.z > sideBound || transform.position.z < -sideBound) || (transform.position.x > sideBound || transform.position.x < -sideBound))
        {
           Destroy(gameObject); // destorys prefabs
        }
        
    }
}
