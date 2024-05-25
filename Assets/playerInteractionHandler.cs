using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHandler : MonoBehaviour
{
    public int i = 0;
    public DialogHandler dialogHandler;
    public Owner owner;
    void Start()
    {
        owner = (Owner)FindObjectsOfType(typeof(Owner))[0];
        owner = owner.GetComponent<Owner>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(Input.GetKeyDown(KeyCode.Space));
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log(owner.dialogs[i]);
            Debug.Log(owner.charintexes[i]);
            Debug.Log(owner.emoindexes[i]);
            dialogHandler.Dialog(owner.dialogs[i], owner.charintexes[i], owner.emoindexes[i]);
            i = i + 1;
        }
        else if (i == 4)
        {
            dialogHandler.CloseDialog();        
        }
    }
}