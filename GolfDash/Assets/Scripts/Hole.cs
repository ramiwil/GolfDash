using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Hole : MonoBehaviour
{
    public GameManager gameManager = null;
    void OnTriggerEnter() {
        
        gameManager.EndGame();
    }
}
