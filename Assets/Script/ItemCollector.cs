using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    [SerializeField] private Text SeedsText;
    private int items = 0;
    private void OnTriggerEnter2D(Collider2D collision){
        if (collision.gameObject.CompareTag("Monedas")){
            Destroy(collision.gameObject);
            items++;
            SeedsText.text = "Seeds: "+ items;
        }
    }
}
