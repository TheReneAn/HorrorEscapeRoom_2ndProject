using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum ItemType
{
    QUEST,
    USE
}

public class Item : MonoBehaviour
{
    public int itemIdx;
    public string itemName;
    public Sprite itemImage;
    public ItemType itemType;
    public string itemDescription;

    public void Start()
    {
        GetComponent<Image>().sprite = itemImage;
    }
}