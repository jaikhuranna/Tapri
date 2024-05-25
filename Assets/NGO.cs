using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NGO : MonoBehaviour
{
    public List<string> dialogs = new List<string>();
    public List<int> charintexes = new List<int>();
    public List<int> emoindexes = new List<int>();
    void Start()
    {
        dialogs.Add("Man man i am NGO man");
        dialogs.Add("I am relatively handsome");
        dialogs.Add("mughe relatively ki spelling nahi ati h");
        dialogs.Add("wow");
        dialogs.Add("");

        charintexes.Add(0);
        charintexes.Add(0);
        charintexes.Add(0);
        charintexes.Add(0);
        charintexes.Add(0);

        emoindexes.Add(1);
        emoindexes.Add(2);
        emoindexes.Add(1);
        emoindexes.Add(2);
        emoindexes.Add(1);
    }
}
