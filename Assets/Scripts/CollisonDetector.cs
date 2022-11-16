using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisonDetector : MonoBehaviour
{
    public static GameObject lastHit;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag("Ground") && !collision.gameObject.CompareTag("Lava")) //check that its not collided with lava or ground
        {
            
                lastHit = collision.gameObject; // set the gameobject hit as lasthit object
            
        }
        else if (collision.gameObject.CompareTag("Lava")) //check that the object is hit by lava
        {
            if (lastHit != null)// if there is an object in last hit 
            {
                lastHit.transform.localScale += new Vector3(0.5f, 0.5f, 0.5f);  // increase size of player who hit last
                Rigidbody rb = lastHit.gameObject.GetComponent<Rigidbody>(); // get rigid body of last hit component
                Renderer rc = lastHit.gameObject.GetComponent<Renderer>(); // get renderer of last hit object to change color
                rc.material.color = Random.ColorHSV(); // change random clolr of last hit object
                rb.mass++; // increase mass of last hit player
            }
            Destroy(gameObject); // destroy the object coliding with lava

        }
           
        
        
    }
}
