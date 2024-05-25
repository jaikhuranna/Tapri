using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Owner : MonoBehaviour
{
    public List<string> dialogs = new List<string>();
    public List<int> charintexes = new List<int>();
    public List<int> emoindexes = new List<int>();
    void Start()
    {
        dialogs.Add("Make");
        dialogs.Add("How");
        dialogs.Add("W");
        dialogs.Add("idk");
        dialogs.Add("");

        charintexes.Add(0);
        charintexes.Add(0);
        charintexes.Add(0);
        charintexes.Add(0);
        charintexes.Add(0);

        emoindexes.Add(2);
        emoindexes.Add(0);
        emoindexes.Add(1);
        emoindexes.Add(1);
        emoindexes.Add(1);
    }
}
