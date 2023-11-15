using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PjMovimiento player = collision.GetComponent<PjMovimiento>();
            if (player != null)
            {
                player.HasItem = true;
                ItemCollectionTracker.Instance.AddSeed(); //Notify the collection tracker
                Destroy(gameObject);
            }
        }
    }
}

