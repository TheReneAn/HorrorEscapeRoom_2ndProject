using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

[System.Serializable]
public class Dialogue
{
    public string name;
    public string[] conTexts;
}

[System.Serializable]
public class DialogueEvent
{
    public string name;
    public Vector2 line;
    public Dialogue[] dialogues;
}