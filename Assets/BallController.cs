using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.PlayerLoop;
using Random = System.Random;

public class BallController : MonoBehaviour
{
    //https://answers.unity.com/questions/364721/how-to-make-a-ball-roll-by-pushing-it-with-a-cube.html
    //https://stackoverflow.com/questions/7447271/how-to-find-which-side-of-a-collider-has-been-hit-from-hit-normal
    

    public Rigidbody rigidbody;
    
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        //rigidbody.velocity = transform.forward * 20f;
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
