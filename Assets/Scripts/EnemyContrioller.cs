using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyContrioller : MonoBehaviour
{
    private float speed = 2;
    private Rigidbody enemyRb;
    public List<GameObject> enemy;
    public GameObject followEnemy;
    private int index;
   
   
    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        index = Random.Range(0, enemy.Count);
        followEnemy = enemy[index]; // set destination emeny from any nearby enemy or player
    }

    // Update is called once per frame
    void Update()
    {
        if(followEnemy != null) // check that follow enemy index recieved actualy exists
        {
            
            Vector3 lookDirection = (followEnemy.transform.position - transform.position).normalized; // set direction of movement
            enemyRb.AddForce(lookDirection * speed *enemyRb.mass); // apply force in direction set
           
        }
        else
        {
            index = Random.Range(0, enemy.Count); // if enemy index assigned had no enemy in list then generate new random index
            followEnemy = enemy[index]; // set followenemy to enemy at index position in enemy list
        } 
        
        
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Lava"))
        {
            enemy.Remove(this.gameObject); // remove enemy destroyed from list
            Destroy(this.gameObject); // destroy enemy colliding with lava
        }
    }


}
