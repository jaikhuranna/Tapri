using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int i = -1;
    
    public List<string> dialogs = new List<string>();
    public List<int> charintexes = new List<int>();
    public List<int> emoindexes = new List<int>();
    void Start()
    {
        dialogs.Add("How long have I been working here?");
        dialogs.Add("A year...?");
        dialogs.Add("...two years?");
        dialogs.Add("Papa passed away so long ago...");
        dialogs.Add("Hurry up! Shop's opening soon! Those debts won't pay themselves!");
        dialogs.Add("");
        
        charintexes.Add(0);
        charintexes.Add(0);
        charintexes.Add(0);
        charintexes.Add(0);
        charintexes.Add(3);
        charintexes.Add(0);
        
        emoindexes.Add(0);
        emoindexes.Add(0);
        emoindexes.Add(0);
        emoindexes.Add(0);
        emoindexes.Add(3);
        emoindexes.Add(0);
    }
}
