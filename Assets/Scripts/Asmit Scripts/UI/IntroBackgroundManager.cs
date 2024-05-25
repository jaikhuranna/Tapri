using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroBackgroundManager : MonoBehaviour
{
    // Update is called once per frame
    public GameObject curtains;
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
        yield return new WaitForSeconds(2.2f);
        gameObject.transform.position = new Vector3(gameObject.transform.position.x,
            gameObject.transform.position.y + 0.5f, gameObject.transform.position.z);
    }

    IEnumerator IntroEndingSlide()
    {
        yield return new WaitForSeconds(3f);
        curtains.SetActive(true);
        SceneManager.LoadScene(2);
    }

    private void MoveIntroBackGround()
    {
        if (gameObject.transform.position.y == 3.5 || gameObject.transform.position.y == 1086 || gameObject.transform.position.y == 2161 )
        {
            StartCoroutine(IntroPause());
        }
        else if(gameObject.transform.position.y == 3242)
        {
            StartCoroutine(IntroEndingSlide());
        }
        else
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x,
                gameObject.transform.position.y + 0.5f, gameObject.transform.position.z);
        }
    }
}
