using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class DialogHandler : MonoBehaviour
{
    [SerializeField] private GameObject canvas;
    [SerializeField] private GameObject genralTextBox;
    [SerializeField] private Texture empty;

    private TMP_Text tmp;

    [SerializeField] private List<Texture> franklinEmo = new List<Texture>();
    [SerializeField] private List<Texture> vasuliEmo = new List<Texture>();
    [SerializeField] private List<Texture> ngoEmo = new List<Texture>();
    [SerializeField] private List<Texture> oppEmo = new List<Texture>();
    
    // IF YOU CHANGE NAMES OF ANY CHARACTERS ABOVE CHANGE THEM IN VOID START AND SWITCH CASE IN VOID DIALOG ALSO
    // ADD NEW LIST FOR A NEW CHARACTER
    // REFERENCE TEXTURES IN THE INSPECTOR TO BE USED
    
    public List<List<Texture>> chardata = new List<List<Texture>>();
    
    // FULL MATRIX OF ALL CHARACTERS AND EMOTIONAL STATES
    
    // THE DIALOG FUNCTION CAN BE USED DIRECTLY IF A CANVAS IS PRESENT IN THE SCENE
    public void Dialog(string dialog, int characterIndex, int emoIndex)
    {
        string characterName;
        switch (characterIndex)
        {
            case 0:
                characterName = "franklin";
                break;
            case 1:
                characterName = "Vasuli";
                break;
            case 2:
                characterName = "NGO";
                break;
            case 3:
                characterName = "Owner";
                break;
            default:
                characterName = "";
                Debug.Log("CharacterIndex is Wrong");
                break;
        }
        
        var dialogbox = GameObject.FindWithTag("DialogBox");
        if (dialogbox == null)
        {
            var dialogBox = Instantiate(genralTextBox, canvas.transform);
            tmp = dialogBox.GetComponentInChildren<TMP_Text>();
            tmp.text = dialog;

            var characterBox = GameObject.FindWithTag("CharacterNameBox");
            tmp = characterBox.GetComponentInChildren<TMP_Text>();
            tmp.text = characterName;

            var imager = GameObject.FindWithTag("CharacterImage").GetComponent<RawImage>();
            imager.texture = chardata[characterIndex][emoIndex];
        }
        else
        {
            var dialogBox = GameObject.FindWithTag("DialogBox");
            tmp = dialogBox.GetComponentInChildren<TMP_Text>();
            tmp.text = dialog;
            
            var characterBox = GameObject.FindWithTag("CharacterNameBox");
            tmp = characterBox.GetComponentInChildren<TMP_Text>();
            tmp.text = characterName;

            var imager = GameObject.FindWithTag("CharacterImage").GetComponent<RawImage>();
            imager.texture = chardata[characterIndex][emoIndex];
        }
    }

    private void Start()
    {
        chardata.Add(franklinEmo); // 0
        chardata.Add(vasuliEmo); // 1
        chardata.Add(ngoEmo); // 2
        chardata.Add(oppEmo); // 3
        Dialog("sad!!!", 0, 2);
    }
}