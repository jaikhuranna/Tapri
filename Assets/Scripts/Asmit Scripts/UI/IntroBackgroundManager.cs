using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroBackgroundManager : MonoBehaviour
{
    // Update is called once per frame
    // -536.5  546   
    private void Start()
    {
        StartCoroutine(IntroPause());
    }

    void Update()
    {
        MoveIntroBackGround();
    }

    IEnumerator IntroPause()
    {
        yield return new WaitForSeconds(1.5f);
        gameObject.transform.position = new Vector3(gameObject.transform.position.x,
            gameObject.transform.position.y + 0.5f, gameObject.transform.position.z);
    }

    private void MoveIntroBackGround()
    {
        if (gameObject.transform.position.y == 3.5 || gameObject.transform.position.y == 1086 || gameObject.transform.position.y == 2161 )
        {
            StartCoroutine(IntroPause());
        }
        else if(gameObject.transform.position.y == 3242)
        {
            SceneManager.GetSceneByBuildIndex(2);
        }
        else
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x,
                gameObject.transform.position.y + 0.5f, gameObject.transform.position.z);
        }
    }
}
