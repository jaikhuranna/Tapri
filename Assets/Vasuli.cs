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
        dialogs.Add("Man man i am vasuli man");
        dialogs.Add("I am NOT relatively handsome");
        dialogs.Add("Parso panvel nikalni h");
        dialogs.Add("NOT WOW");
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
