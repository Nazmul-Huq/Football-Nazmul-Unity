using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class BallController : MonoBehaviour
{
    //https://answers.unity.com/questions/364721/how-to-make-a-ball-roll-by-pushing-it-with-a-cube.html
    

    public Rigidbody rigidbody;
    
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
         
    }

    private void OnCollisionEnter(Collision other)
    {
        PlayerMovement playerMovement = other.gameObject.GetComponent<PlayerMovement>();
        var deltaPosition = rigidbody.transform.position - playerMovement.Position;
        deltaPosition.y = 0;
        var forward = deltaPosition.normalized;
        rigidbody.AddForce(forward * 1000f * Time.fixedDeltaTime, ForceMode.VelocityChange);
        //rigidbody.MovePosition(transform.position + Vector3.forward * 100f * Time.fixedDeltaTime);
        
    }
    
}
