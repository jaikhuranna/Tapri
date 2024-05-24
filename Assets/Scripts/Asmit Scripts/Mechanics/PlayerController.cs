using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject teaCup;
    public GameObject teaSlot;
    public GameObject parleG;
    
    public Rigidbody playerRb;

    public int speed = 50;
    public int[] itemsInHand;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            playerRb.AddForce(speed *  Time.deltaTime * Vector3.left, ForceMode.Acceleration);
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Entered Collider");
    }
}
