using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
     [Header("References")]
    [Tooltip("The character controller to move with")]
    public CharacterController characterController;

    [Tooltip("The object, that I want to rotate to face travel direction")]
    public Transform transformer;

    [Header("Move properties")]
    [Tooltip("Max speed of player")]
    public float moveMaxPerSecond = 24;

    [Tooltip("Time to reach maximum velocity")]
    public float moveTimeToMax = .26f;

    [Tooltip("Time to slow down to zero velocity")]
    public float moveTimeToZero = .2f;

    [Tooltip("The momentum (multiplied velocity) when switching into an opposite direction")]
    public float moveReverseMomentum = 2.2f;

    // Private attribute to store movement in
    private Vector3 _movement = Vector3.zero;

    // Derived velocity gain per second
    private float MoveVelocityGain
    {
        get => moveMaxPerSecond / moveTimeToMax;
    }

    // Derived velocity loss per second
    public float MoveVelocityLoss
    {
        get => moveMaxPerSecond / moveTimeToZero;
    }

    public Vector3 Position
    { 
        get => characterController.gameObject.transform.position;
    }


    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    // Handle character movement in a separate method
    void Movement()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            if (_movement.z >= 0)
            {
                // Forwards
                transform.position += transform.forward * Time.deltaTime ;
            }
            else
            {
                // Reverse forwards
                _movement.z += MoveVelocityGain * moveReverseMomentum * Time.deltaTime;
            }
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            if (_movement.z <= 0)
            {
                // Backwards
                transform.position += Vector3.back * Time.deltaTime ;
            }
            else
            {
                // Reverse backwards
                _movement.z -= MoveVelocityGain * moveReverseMomentum * Time.deltaTime;
            }
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            // move player to right
            transform.position += Vector3.right * Time.deltaTime ;

        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            // move player to right
            transform.position += Vector3.left * Time.deltaTime ;

        }
        else
        {
            // Slow down 
            if (_movement.z > 0)
            {
                // From forwards
                _movement.z -= MoveVelocityLoss * Time.deltaTime;
                _movement.z = Mathf.Max(0, _movement.z);
            }
            else if (_movement.z < 0)
            {
                // From backwards
                _movement.z += MoveVelocityLoss * Time.deltaTime;
                _movement.z = Mathf.Min(0, _movement.z);
            }

        }


        // Same as above, but in the left/right of the X dimension
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            if (_movement.x >= 0)
            {
                // Right
                _movement.x += MoveVelocityGain * Time.deltaTime;
                _movement.x = Mathf.Min(moveMaxPerSecond, _movement.x);
            }
            else
            {
                // Reverse right
                _movement.x += MoveVelocityGain * moveReverseMomentum * Time.deltaTime;
                //_movement.x = Mathf.Min(0, _movement.x);
            }

        }
        else if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            if (_movement.x <= 0)
            {
                // Left
                _movement.x -= MoveVelocityGain * Time.deltaTime;
                _movement.x = Mathf.Max(-moveMaxPerSecond, _movement.x);
            }
            else
            {
                // Break left
                _movement.x -= MoveVelocityGain * moveReverseMomentum * Time.deltaTime;
                //_movement.x = Mathf.Max(0, _movement.x);
            }
        }
        else
        {
            // Slow down 
            if (_movement.x > 0)
            {
                // From right
                _movement.x -= MoveVelocityLoss * Time.deltaTime;
                _movement.x = Mathf.Max(0, _movement.x);
            }
            else if (_movement.x < 0)
            {
                // From left
                /*
                _movement.x += MoveVelocityLoss * Time.deltaTime;
                */
                _movement.x = Mathf.Min(0, _movement.x);
            }

        }
    }

}
