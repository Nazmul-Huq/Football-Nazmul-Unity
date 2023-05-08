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
        //rigidbody.velocity = transform.forward * 20f;
    }

    // Update is called once per frame
    void Update()
    {
         
    }

    private void OnCollisionEnter(Collision other)
    {
        rigidbody.MovePosition(transform.position + Vector3.forward * 100f * Time.fixedDeltaTime);
        
    }
    
}
