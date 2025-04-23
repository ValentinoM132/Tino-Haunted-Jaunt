using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraChanger3 : MonoBehaviour
{

    public GameObject cameraOld;
    public GameObject cameraNew;

    public float waitTime = 0.5f;
   
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
            Player.silly = true;
            Player.goofy = false;
            Player.flipped = false;
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
