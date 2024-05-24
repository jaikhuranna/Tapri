using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonBehaviour : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }
    
}
