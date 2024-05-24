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
    private GameObject textbox;

    void Dialog(string dialog)
    {
        var textbox = GameObject.FindWithTag("TextBox");
        if (textbox == null)
        {
            var textBox = Instantiate(genralTextBox, canvas.transform);
            tmp = textBox.GetComponentInChildren<TMP_Text>();
            tmp.text = dialog;
        }
        else
        {
            tmp = textbox.GetComponentInChildren<TMP_Text>();
            tmp.text = dialog;
        }
    }

    private void Start()
    {
        Dialog("make"); 
    }
}