using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Owner : MonoBehaviour
{
    public int i = -1;
    
    public List<string> dialogs = new List<string>();
    public List<int> charintexes = new List<int>();
    public List<int> emoindexes = new List<int>();
    void Start()
    {

        //NGO path after Level 1
        dialogs.Add("Why aren't you cleaning? I'm not paying you to laze around!");//1
        dialogs.Add("You don't pay me...");//Player1
        dialogs.Add("What did you say?");//2
        dialogs.Add("He slowly takes off his belt as he walks towards me. I close my eyes, knowing what's coming next.");//Player2

        //Vasooli Path after Level 1
        dialogs.Add("There was a man asking for you.");//Player3
        dialogs.Add("What did you tell him?");//3
        dialogs.Add("I told him you were at the back.");//Player4
        dialogs.Add("You idiot!");//4
        dialogs.Add("I feel a sharp pain in my cheek as his hands leave their mark.");//Player5
        dialogs.Add("Get back to work! And tell him I'm not here!");//5
        dialogs.Add("");

        charintexes.Add(3);//1
        charintexes.Add(0);//Player1
        charintexes.Add(3);//2
        charintexes.Add(0);//Player2
        charintexes.Add(0);//Player3
        charintexes.Add(3);//3
        charintexes.Add(0);//Player4
        charintexes.Add(3);//4
        charintexes.Add(0);//Player5
        charintexes.Add(3);//5

        emoindexes.Add(1);//1
        emoindexes.Add(0);//Player1
        emoindexes.Add(3);//2
        emoindexes.Add(0);//Player2
        emoindexes.Add(0);//Player3
        emoindexes.Add(2);//3
        emoindexes.Add(0);//Player4
        emoindexes.Add(3);//4
        emoindexes.Add(0);//Player5
        emoindexes.Add(3);//5
    }
}