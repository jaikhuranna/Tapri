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
        dialogs.Add("Where's your boss?");//1
        dialogs.Add("He's probably in the back.");//P1
        dialogs.Add("Call him.");//2
        

        charintexes.Add(1);//1
        charintexes.Add(0);//P1
        charintexes.Add(1);//2
        

        emoindexes.Add(0);//1
        emoindexes.Add(0);//P1
        emoindexes.Add(0);//2
        
    }

}
