using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NGO : MonoBehaviour
{
    public int i = -1;
    
    public List<string> dialogs = new List<string>();
    public List<int> charintexes = new List<int>();
    public List<int> emoindexes = new List<int>();
    void Start()
    {
        //Level 1
        dialogs.Add("Could you take my order please?");
        

        charintexes.Add(2);


        emoindexes.Add(0);
    }
}
