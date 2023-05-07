using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [Tooltip("The object, that I want to rotate to face travel direction")]
    public Transform transformer;
    
    float m_Speed;
    Rigidbody m_Rigidbody;
    private Vector3 _movement = Vector3.zero;
    
   
    // Start is called before the first frame update
    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
        m_Speed = 1.0f;
    }


    // Update is called once per frame
    void Update()
    {
        Movement(); 
    }

    /// <summary>
    /// Player movement is handled by this method
    /// </summary>
    void Movement()
    {
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            if (_movement.z >= 0)
            {
                m_Rigidbody.velocity = transform.forward * m_Speed;
            }
        }

    }

}
