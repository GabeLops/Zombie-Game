using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerCollision : MonoBehaviour {
    public PlayerMovement movement;
    
    



    void OnCollisionEnter2D(Collision2D collisionInfo)
    {

        if (collisionInfo.collider.tag == "Zombie")
        {
            movement.enabled = false; //disable movement
            FindObjectOfType<GameMaster>().EndGame();
        }

        if (collisionInfo.collider.tag == "Winner")
        {
            movement.enabled = false; //disable movement
            
            FindObjectOfType<GameMaster>().GameWin();
            

        }

    }

}


