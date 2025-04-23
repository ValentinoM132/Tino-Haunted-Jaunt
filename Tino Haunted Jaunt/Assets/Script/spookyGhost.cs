using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class spookyGhost : MonoBehaviour
{
    public Vector3 rotationAxis = Vector3.up; // Axis to rotate around
    public float rotationAngle = 90f;       // Total degrees to rotate
    public float duration = 2f;            // Duration of the rotation in seconds
    private bool activate = false;

    private bool isRotating = false;
    private float timer = 0f;
    private Quaternion startRotation;
    private Quaternion endRotation;
    
    public AudioSource m_AudioSource;
    public GameObject Ghost;
    public GameObject Door;
    public float speed;

    public void Start()
    {
       StartRotation();
       StartCoroutine(moveForward());
    }
    public void StartRotation()
    {
        if (!isRotating)
        {
            isRotating = true;
            timer = 0f;
            startRotation = transform.rotation;
            endRotation = transform.rotation * Quaternion.Euler(rotationAxis * rotationAngle);
            StartCoroutine(Rotate());
        }
    }

    private IEnumerator Rotate()
    {
        while (timer < duration)
        {
            timer += Time.deltaTime;
            float t = Mathf.Clamp01(timer / duration);
            transform.rotation = Quaternion.Slerp(startRotation, endRotation, t);
            yield return null;
        }
        transform.rotation = endRotation; 
        isRotating = false;
    }
    private IEnumerator moveForward()
    {
        yield return new WaitForSeconds(4f);
        activate = true;
        m_AudioSource.Play();




    }
    private void Update()
    {
        if (activate == true)
        {
            Ghost.transform.position = Vector3.MoveTowards(Ghost.transform.position, Door.transform.position, speed);
            
        }
    }
}
