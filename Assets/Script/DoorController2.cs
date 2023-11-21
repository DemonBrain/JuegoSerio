using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController1 : MonoBehaviour
{
    public bool isOpen = false; // Initial state of the door
    public GameObject[] doorObject; // The actual door object that will disappear
    
    public void ToggleDoor()
    {
        isOpen = !isOpen;

        if (isOpen)
        {
            OpenDoor();
        }
        else
        {
            CloseDoor();
        }
    }

    void OpenDoor()
    {
       // doorObject.SetActive(false); // Makes the door disappear
       foreach (GameObject door in doorObject)
        {
            door.SetActive(false);
        }
        
    }

    void CloseDoor()
    {
        //doorObject.SetActive(true); // Makes the door reappear
        foreach (GameObject door in doorObject)
        {
            door.SetActive(true);
        }

    }
}
