using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class cup_instantiater : MonoBehaviour
{
    public GameObject cup;

    private void Start()
    {
        cup.transform.position = gameObject.transform.position;
    }

    private void Update()
    {
        if (cup.transform.position != gameObject.transform.position)
        {
            GameObject new_cup = Instantiate(cup, gameObject.transform);
            cup.tag = "no";
        }
    }
}
