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
        dialogs.Add("Hurry up! Shop's opening soon! Those debts won't pay themselves!");

        //NGO path after Level 1
        dialogs.Add("Why aren't you cleaning? I'm not paying you to laze around!");
        dialogs.Add("What did you say?");

        //Vasooli Path after Level 1
        dialogs.Add("What did you tell him?");
        dialogs.Add("You idiot!");
        dialogs.Add("Get back to work! And tell him I'm not here!");

        charintexes.Add(3);
        charintexes.Add(3);
        charintexes.Add(3);
        charintexes.Add(3);
        charintexes.Add(3);
        charintexes.Add(3);

        emoindexes.Add(3);
        emoindexes.Add(1);
        emoindexes.Add(3);
        emoindexes.Add(2);
        emoindexes.Add(3);
        emoindexes.Add(3);
    }
}