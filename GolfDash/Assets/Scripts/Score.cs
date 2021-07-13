using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour
{
    public GameManager gameManager;
    // Update is called once per frame
    void Update()
    {
        gameManager.UpdateMoves();           
    }
}
