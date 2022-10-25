using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpener : MonoBehaviour
{
    [SerializeField] public GameObject KeyCollider;
    private bool isDoorOpen = false;
 
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("Key") && !isDoorOpen)
        {
            OpenDoor();
            isDoorOpen = true;
        }
    }
    
    private void OpenDoor()
    {
        gameObject.transform.Rotate(0,0,90);
    }
}
