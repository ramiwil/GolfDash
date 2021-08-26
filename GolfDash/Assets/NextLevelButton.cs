using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevelButton : MonoBehaviour
{
    public void LoadScene()
    {

        //Debug.Log(GameManager.curScene + " in level end screen");
        SceneManager.LoadScene(NextScene(GameManager.curScene));
    }


    public string NextScene(string prevScene) {
        string nextScene = "";
        string temp = prevScene;

        temp = temp.Substring(5);
        
        int levelNum = Int16.Parse(temp);


        if (levelNum < 10) {
            nextScene = "Level0" + (levelNum + 1).ToString();
        } else if (levelNum >= 10 && levelNum < 20) {
            nextScene = "Level1" + (levelNum + 1).ToString();
        } else if (levelNum >= 20 && levelNum < 30) {
            nextScene = "Level2" + (levelNum + 1).ToString();
        }

        return nextScene;
    }
}
