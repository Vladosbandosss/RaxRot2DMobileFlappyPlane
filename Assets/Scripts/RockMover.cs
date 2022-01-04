using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockMover : MonoBehaviour
{
    [SerializeField] float speed = 2f;
    
    private void Update()
    {
       
        transform.Translate(-speed*Time.deltaTime,0,0);

        if (transform.position.x < -5f)
        {
            Destroy(gameObject);
        }
    }
    
    public void StopMove()
    {
        speed = 0f;
    }
}
