using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Sirenix.OdinInspector;

public class Interaction : MonoBehaviour
{
    [EnumPaging]
    public INTERACTION interType;
    public bool isConversation;
    [ShowIf("interType", INTERACTION.DOOR)]
    public Transform doorTf;
    [ShowIf("interType", INTERACTION.CLOSET)]
    public Transform closetTf;
    [ShowIf("interType", INTERACTION.DESK)]
    public Transform deskTf;
    [ShowIf("interType", INTERACTION.ITEM)]
    public Item item;
    [ShowIf("isConversation", true)]
    public int convNum;

    public float goalRotation;
    public float time;

    private bool activeObj;

    void OnTriggerStay(Collider other)
    {
       
    }

    void ReStartControl()
    {
        GameManager.Instance.playerCanControl = true;
    }

    public void StartItemEvent()
    {
        InventoryManager.Instance.AddItem(item);

        if (isConversation)
        {
            GameManager.Instance.playerCanControl = false;
            DialogueManager.Instance.StartConversation(convNum);
        }

        Destroy(gameObject);
    }

    public void StartDoorEvent()
    {
        GameManager.Instance.playerCanControl = false;

        if (activeObj)
        {
            doorTf.DORotate(new Vector3(doorTf.rotation.x, 0, doorTf.rotation.z), time);
            activeObj = false;
        }
        else
        {
            doorTf.DORotate(new Vector3(doorTf.rotation.x, goalRotation, doorTf.rotation.z), time);
            activeObj = true;
        }

        if (isConversation)
        {
            DialogueManager.Instance.StartConversation(convNum);
        }
        else
        {
            Invoke("ReStartControl", time);
        }
    }

    public void StartClosetEvent()
    {
        Debug.Log("Closet");
        GameManager.Instance.playerCanControl = false;

        if (activeObj)
        {
            closetTf.DORotate(new Vector3(closetTf.rotation.x, 0, closetTf.rotation.z), time);
            activeObj = false;
        }
        else
        {
            closetTf.DORotate(new Vector3(closetTf.rotation.x, goalRotation, closetTf.rotation.z), time);
            activeObj = true;
        }

        if (isConversation)
        {
            DialogueManager.Instance.StartConversation(convNum);
        }
        else
        {
            Invoke("ReStartControl", time);
        }
    }
    public void StartDeskEvent()
    {

        GameManager.Instance.playerCanControl = false;

        if (activeObj)
        {
            closetTf.DORotate(new Vector3(deskTf.rotation.x, 0, deskTf.rotation.z), time);
            activeObj = false;
        }
        else
        {
            closetTf.DORotate(new Vector3(deskTf.rotation.x, goalRotation, deskTf.rotation.z), time);
            activeObj = true;
        }

        if (isConversation)
        {
            DialogueManager.Instance.StartConversation(convNum);
        }
        else
        {
            Invoke("ReStartControl", time);
        }
    }
}
