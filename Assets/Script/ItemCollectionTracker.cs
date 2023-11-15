using UnityEngine;
using UnityEngine.UI;

public class ItemCollectionTracker : MonoBehaviour
{
    public static ItemCollectionTracker Instance;

    public int totalSeedsCollected { get; private set; } = 0;
    public GameObject seedUIPrefab; 
    public Transform seedUIParent; 

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddSeed()
    {
        totalSeedsCollected++;
        Debug.Log("Total Seeds Collected: " + totalSeedsCollected);
    }

    // For the pause and finished level UI. It displays the total seeds collected until that point
    // Attach a panel UI element to the parentUI parameter
    // Attach the prefab seed to the parameter
    public void DisplayCollectedSeeds()
    {
        // Clear previous seeds
        foreach (Transform child in seedUIParent)
        {
            Destroy(child.gameObject);
        }

        // Display new seeds
        for (int i = 0; i < totalSeedsCollected; i++)
        {
            Instantiate(seedUIPrefab, seedUIParent);
        }
    }
}


