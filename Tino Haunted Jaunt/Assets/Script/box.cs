using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class box : MonoBehaviour
{
    public bool isIn = false;
    public GameObject UI;

    // Start is called before the first frame update
    void Start()
    {

    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {

            {
                isIn = true;
                UI.SetActive(true);
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        isIn = false;
        UI.SetActive(false);
    }
}
   