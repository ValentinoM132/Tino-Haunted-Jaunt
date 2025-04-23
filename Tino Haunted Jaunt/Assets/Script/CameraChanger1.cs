using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraChanger1 : MonoBehaviour
{

    public GameObject cameraOld;
    public GameObject cameraNew;
    public float waitTime = .75f;
    [SerializeField] public PlayerMovement Player;

    private void Start()
    {
        
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            
            {
                StartCoroutine(frozen());
            }    
            Player.goofy = true;
            Debug.Log("Works!");
            cameraOld.SetActive(false);
            cameraNew.SetActive(true);
            
        }
    }
 
    IEnumerator frozen()
    {
        Player.frozen = true;
        yield return new WaitForSeconds(waitTime);
        Player.frozen = false;
    }
}
