using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{

    public float m_speed;
    public float jump;
    float moveVelocity;
    bool grounded = false;



    void Update()
    {
        if (Input.GetKeyDown (KeyCode.UpArrow))
        {
            if (grounded)
            
            
                GetComponent<Rigidbody2D>().velocity = new Vector2(
                GetComponent<Rigidbody2D>().velocity.x, jump);
            
        }

           Vector3 input = Vector3.zero;
           if (Input.GetKey(KeyCode.LeftArrow))
               input += Vector3.left;
           if (Input.GetKey(KeyCode.RightArrow))
               input += Vector3.right;
           

           input.Normalize();

            transform.position += input * m_speed * Time.deltaTime;
         
    }
    void OnTriggerEnter2D()
    {
        grounded = true;
    }

    void OnTriggerExit2D()
    {
        grounded = false;
    }
}
