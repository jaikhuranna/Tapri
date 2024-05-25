using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vasuli : MonoBehaviour
{
    public int i = -1;
    
    public List<string> dialogs = new List<string>();
    public List<int> charintexes = new List<int>();
    public List<int> emoindexes = new List<int>();
    void Start()
    {
        //Level 1
        dialogs.Add("Where's your boss?");
        dialogs.Add("Maa chudvane gaya h");
        dialogs.Add("Call him.");
        dialogs.Add("");
        

        charintexes.Add(1);
        charintexes.Add(0);
        charintexes.Add(1);
        charintexes.Add(1);
        

        emoindexes.Add(0);
        emoindexes.Add(0);
        emoindexes.Add(0);
        emoindexes.Add(0);
    }

}
