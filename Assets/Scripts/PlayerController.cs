using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed; 
    public bool GotPowerUp;
     Rigidbody playerRb; 
     GameObject focalpoint; 
     public float PowerUpStrength = 15.0f; 
     public GameObject PowerupIndicator; 

    
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
      PowerupIndicator.transform.position = transform.position + new Vector3(0, -0.5f, 0);
    }

    void OnTriggerEnter(Collider other)
    {
      if (other.CompareTag("Power Up"))
      {
        GotPowerUp = true;
        Destroy(other.gameObject);
        StartCoroutine(PowerupCountdownLoop());
        PowerupIndicator.gameObject.SetActive(true);  
      }
    }

     IEnumerator PowerupCountdownLoop()
     {
        yield return new WaitForSeconds(7);
        GotPowerUp = false;
        PowerupIndicator.gameObject.SetActive(false);  
     }   

    void OnCollisionEnter(Collision collision)
    {
      Rigidbody enemyRigidbody = collision.gameObject.GetComponent<Rigidbody>();
      Vector3 awayFromPlayer = (collision.gameObject.transform.position - transform.position);
      
      if (collision.gameObject.CompareTag("Enemy") && GotPowerUp)
      {
        Debug.Log("Collided with" + collision.gameObject.name + "with power set to" + GotPowerUp);
        enemyRigidbody.AddForce(awayFromPlayer * PowerUpStrength, ForceMode.Impulse);
      }
    }
}
