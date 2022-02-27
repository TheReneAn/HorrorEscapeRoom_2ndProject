using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    public Item item;
    public bool isItem;
    private Image image;

    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddItem(Item _item)
    {
        Debug.Log(_item);
        isItem = true;
        item = _item;
        image.sprite = item.itemImage;
    }

    public void ClearSlot()
    {
        image.sprite = null;
        isItem = false;
        item = null;
    }
}
