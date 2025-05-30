using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float turnSpeed = 20f;
    public bool goofy = false;
    public bool flipped = false;
    public bool silly = false;
    public bool frozen = false;
    public bool open;

    Animator m_Animator;
    Rigidbody m_Rigidbody;
    AudioSource m_AudioSource;
    Vector3 m_Movement;
    Quaternion m_Rotation = Quaternion.identity;

    


    void Start()
    {
        m_Animator = GetComponent<Animator>();
        m_Rigidbody = GetComponent<Rigidbody>();
        m_AudioSource = GetComponent<AudioSource>();
    }
   

    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        

        if (frozen == true)
        {
            horizontal = 0f;
            vertical = 0f;

        }

        else if (goofy != true & flipped != true & silly != true)
        {
            m_Movement.Set(horizontal, 0f, vertical);
        }
        else if (goofy = true & flipped != true & silly != true)
        {
            m_Movement.Set(-vertical, 0f, horizontal);
        }
        else if (goofy != true & flipped == true & silly != true)
        {
            m_Movement.Set(-horizontal, 0f, -vertical);
        }
        else if (silly = true & flipped != true & goofy != true)
        {
            m_Movement.Set(vertical, 0f, -horizontal);
        }
            m_Movement.Normalize();

        bool hasHorizontalInput = !Mathf.Approximately(horizontal, 0f);
        bool hasVerticalInput = !Mathf.Approximately(vertical, 0f);
        bool isWalking = hasHorizontalInput || hasVerticalInput;
        m_Animator.SetBool("IsWalking", isWalking);
  


        if (isWalking)
        {
            if (!m_AudioSource.isPlaying)
            {
                m_AudioSource.Play();
            }
        }
        else
        {
            m_AudioSource.Stop();
        }

        
        Vector3 desiredForward = Vector3.RotateTowards(transform.forward, m_Movement, turnSpeed * Time.deltaTime, 0f);
        m_Rotation = Quaternion.LookRotation(desiredForward);
    }

   
    void OnAnimatorMove()
    {
        m_Rigidbody.MovePosition(m_Rigidbody.position + m_Movement * m_Animator.deltaPosition.magnitude);
        m_Rigidbody.MoveRotation(m_Rotation);
    }
}
