using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    #region singleton
    private static DialogueManager instance = null;
    
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

    public static DialogueManager Instance => instance == null ? null : instance;

    #endregion

    [SerializeField]
    GameObject dialogueBar;

    [SerializeField]
    Text dialogueText;

    Dialogue[] dialogues;

    bool isDialogue = false;

    InteractionController theIC;

    private void Start()
    {
        theIC = FindObjectOfType<InteractionController>();
    }

    public void ShowDialogue(Dialogue[] _dialogues)
    {
        dialogueText.text = "";
        SettingUI(true);
        dialogues = _dialogues;
    }

    public void CloseDialogue()
    {
        dialogueText.text = "";
        SettingUI(false);
    }

    void SettingUI(bool _flag)
    {
        dialogueBar.SetActive(_flag);
    }
}
