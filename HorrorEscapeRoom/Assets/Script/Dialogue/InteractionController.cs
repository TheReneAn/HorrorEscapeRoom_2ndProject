using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionController : MonoBehaviour
{
    public bool isContact;
    
    void Update()
    {
        if(isContact)
        {
            isContact = false;
            Interact();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Interaction") && InputManager.Instance.PlayerAction())
        {
            isContact = true;
            GameManager.Instance.playerCanControl = false;
            DialogueManager.Instance.ShowDialogue(other.transform.GetComponent<InteractEvent>().GetDialogue());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        DialogueManager.Instance.CloseDialogue();
    }

    private void Interact()
    {
        //DialogueManager.Instance.ShowDialogue();
    }
}
