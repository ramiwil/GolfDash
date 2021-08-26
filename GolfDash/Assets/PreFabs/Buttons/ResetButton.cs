using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetButton : MonoBehaviour
{

    public void LoadScene()
    {
        //Debug.Log(GameManager.curScene + " in level end screen");
        SceneManager.LoadScene(GameManager.curScene);
    }
}
