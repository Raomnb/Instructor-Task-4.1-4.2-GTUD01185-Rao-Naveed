using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    private float speed = 3;
    private Rigidbody playerRb;
    private GameObject focalPoint;
    
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("Focal Point"); // set focal point object in focalpoint variable
    }

    // Update is called once per frame
    void Update()
    {
        
        float forwardInput = Input.GetAxis("Vertical"); //set vertical axis as forward input so up down keys can be used to move player
        float horizonalInput = Input.GetAxis("Horizontal");//set horizontal axis as horizontal input so left right keys can be used to rotate player
        if (forwardInput != 0)
        {
            playerRb.AddForce(focalPoint.transform.forward * speed * forwardInput * playerRb.mass); //add force in forward or backward direction with reference to direction of camera

        }
        else
        {
            playerRb.velocity = Vector3.zero; // if forward or backward key is not pressed dont move player
        } 
        transform.Rotate(Vector3.up * horizonalInput * 50 * Time.deltaTime); // rotates player
    
      
                
       
    }
   
}
