using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;

public class DialogHandler : MonoBehaviour
{
    [SerializeField] private GameObject canvas;
    [SerializeField] private GameObject genralTextBox;

    private TMP_Text tmp;

    void Dialog(string dialog, string character)
    {
        var dialogbox = GameObject.FindWithTag("DialogBox");
        if (dialogbox == null)
        {
            var dialogBox = Instantiate(genralTextBox, canvas.transform);
            tmp = dialogBox.GetComponentInChildren<TMP_Text>();
            tmp.text = dialog;

            var characterBox = GameObject.FindWithTag("CharacterNameBox");
            tmp = characterBox.GetComponentInChildren<TMP_Text>();
            tmp.text = character;
        }
        else
        {
            var dialogBox = GameObject.FindWithTag("DialogBox");
            tmp = dialogBox.GetComponentInChildren<TMP_Text>();
            tmp.text = dialog;
            
            var characterBox = GameObject.FindWithTag("CharacterNameBox");
            tmp = characterBox.GetComponentInChildren<TMP_Text>();
            tmp.text = character;
        }
    }

    private void Start()
    {
        Dialog("iam kirmada", "kirmada"); 
    }
}