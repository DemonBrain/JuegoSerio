using UnityEngine;

public class ButtonInteract : MonoBehaviour
{
    public DoorController[] linkedDoor; // Drag the door you want to control in the inspector
    public KeyCode interactionKey = KeyCode.E; // The key to interact with the button

    private bool isPlayerNearby = false;

    private void Update()
    {
        if (isPlayerNearby && Input.GetKeyDown(interactionKey))
        {
            foreach (DoorController controller in linkedDoor)
            {
                controller.ToggleDoor();
            }
            //linkedDoor.ToggleDoor();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isPlayerNearby = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isPlayerNearby = false;
        }
    }
}

