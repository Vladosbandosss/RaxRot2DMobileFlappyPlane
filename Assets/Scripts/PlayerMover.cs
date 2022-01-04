using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] float tapForce = 250f;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private float maxRotationZ;
    [SerializeField] private float minRotationZ;

    private Quaternion maxRotation;
    private Quaternion minRotation;

    private Rigidbody2D rb;

    bool canMove;

    bool startgame;
    
   private void Start()
   {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.zero;
        rb.gravityScale = 0f;

        maxRotation = Quaternion.Euler(0, 0, maxRotationZ);
        minRotation = Quaternion.Euler(0, 0, minRotationZ);

        canMove = true;
   }

   private void Update()
   {
        if (Input.anyKey)
        {
            startgame = true;
        } 
        
        MovePlaneUp(); 
   }

    private void MovePlaneUp()
    {
        if (canMove)
        {
            if (Input.GetMouseButtonDown(0))
            {
                rb.gravityScale = 1f; 
                transform.rotation = maxRotation;
                rb.velocity = Vector2.zero;
                rb.AddForce(Vector2.up * tapForce, ForceMode2D.Force);

            }
            if (startgame)
            {
                transform.rotation = Quaternion.Lerp(transform.rotation, minRotation, rotationSpeed * Time.deltaTime);
            }
           
        }
       
    }

    public void Die()
    {
        rb.velocity = Vector2.zero;
        canMove = false;
    }
}
