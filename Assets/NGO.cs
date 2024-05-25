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
        dialogs.Add("Could you take my order please?");//1
        dialogs.Add("I walk over to take his order. One cup of chai with extra ginger and sugar, and some rusk. I feel him slip a note into my pocket.");//P1
        

        charintexes.Add(2);//1
        charintexes.Add(0);//P1

        emoindexes.Add(0);//1
        emoindexes.Add(0);//P1
    }
}
