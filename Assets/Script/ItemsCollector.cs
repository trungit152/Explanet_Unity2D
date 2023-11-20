using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemsCollector : MonoBehaviour
{
    public DataSO data;
    [SerializeField] private Text cherriesText;

    private void Start()
    {
        cherriesText.text = "Cherries: " + data.cherries;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Cherry"))
        {
            data.cherries++;
            cherriesText.text = "Cherries: " + data.cherries;
        }
        if (collision.gameObject.CompareTag("Bananas"))
        {
            DropBananaText.Instance.ShowNoti();
            data.canShot = true;
        }
    }
}
