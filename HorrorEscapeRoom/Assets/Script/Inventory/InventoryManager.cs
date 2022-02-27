using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    #region singleton
    private static InventoryManager instance = null;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public static InventoryManager Instance => instance == null ? null : instance;

    #endregion
    public GameObject inventory;
    public GameObject go_SlotParent;
    public Slot[] slots;
    public Item[] items; 

    private void Start()
    {
        slots = go_SlotParent.GetComponentsInChildren<Slot>();

        //AcquireItem(items[0]);
    }

    void Update()
    {
        
    }
    public void AcquireItem(Item _item)
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i].item == null)
            {
                slots[i].AddItem(_item);
                return;
            }
        }
    }

    public void InitSlots()
    {

    }

    public void AddItem(Item _item)
    {
        
    }

    public void InventoryOn()
    {
        inventory.SetActive(true);
        GameManager.Instance.playerCanControl = false;
    }
    public void InventoryOff()
    {
        inventory.SetActive(false);
        GameManager.Instance.playerCanControl = true;
    }
}
