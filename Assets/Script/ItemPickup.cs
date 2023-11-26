 using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("colision");
            Parrot parrot = collision.GetComponent<Parrot>();
            Raccoon raccoon = collision.GetComponent<Raccoon>();
            if (parrot != null)
            {
                parrot.HasItem = true;
                ItemCollectionTracker.Instance.AddSeed(); // Notify the collection tracker
                Destroy(gameObject);
            }
            else if (raccoon != null)
            {
                raccoon.HasItem = true;
                ItemCollectionTracker.Instance.AddSeed(); // Notify the collection tracker
                Destroy(gameObject);
            }
        }
    }
}

