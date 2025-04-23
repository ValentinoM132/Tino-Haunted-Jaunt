using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraChanger : MonoBehaviour
{

    public GameObject cameraOld;
    public GameObject cameraNew;

    public float waitTime = .5f;
    [SerializeField] public PlayerMovement Player;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(frozen());
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
