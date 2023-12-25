using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectItem : MonoBehaviour
{
    private int Point = 0;
    [SerializeField] private Text pointText;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("CollectPoint"))
        {
            Point += 1;
pointText.text = "Banana:" + Point;  
            Destroy(collision.gameObject);        }

    }
}
