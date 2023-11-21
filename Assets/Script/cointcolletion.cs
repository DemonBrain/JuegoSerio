using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class cointcolletion : MonoBehaviour
{
    private int monedas = 0;
    [SerializeField] private Text monedasText;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Monedas"))
        {
            Destroy(collision.gameObject);
            monedas++;
            monedasText.text = "Monedas: " + monedas;
        }
    }
}
