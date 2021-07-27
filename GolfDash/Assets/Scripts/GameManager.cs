using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Rigidbody player;
    public static int playerMoves;
    public Text playerMovesText;
    public Text shootStatus;
    public Touch touch;
    Vector3 reset;

    public void Start() {
        playerMoves = 0;
    }
    public void EndGame() {
        Debug.Log("LEVEL WON");

        player.velocity = reset;
        player.isKinematic = true;

        SceneManager.LoadScene("LevelEnd");
        
    }

    public void UpdateMoves() {
        Debug.Log(player.velocity.magnitude);
        if (SceneManager.GetActiveScene() != SceneManager.GetSceneByName("LevelEndScreen")) {
            if (player.velocity.magnitude < 0.02) {
                shootStatus.text = "Shoot!";
            } else {
                shootStatus.text = "Wait...";
            }
        }
        if(SceneManager.GetActiveScene() != SceneManager.GetSceneByName("LevelEndScreen")) {
            if (Input.touchCount > 0) {
                touch = Input.GetTouch(0);
                
                if (touch.phase == TouchPhase.Ended && player.velocity.magnitude < 0.02) {
                    playerMoves++;
                }
                
                playerMovesText.text = playerMoves.ToString();
            }
        }   
    }
}
