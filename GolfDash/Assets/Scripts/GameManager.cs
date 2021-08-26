using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Rigidbody player;
    public static int playerMoves;
    public static int finalPlayerMoves;
    public Text playerMovesText;
    public Text shootStatus;
    public Touch touch;
    Vector3 reset; 


    //Shared data between levels
    public static string curScene;


    public void Start() {
        playerMoves = 0;
        //Debug.Log(curScene);
    }
    public void EndGame() {
        curScene = SceneManager.GetActiveScene().name;

        //LevelData.sceneForReset.name = curScene;

        //Debug.Log(playerMoves);
        //Debug.Log(curScene + "in gameManager after save");
        //Debug.Log(LevelData.sceneForReset.name + "in Level data after save");

        finalPlayerMoves = playerMoves;

        player.velocity = reset;
        player.isKinematic = true;

        SceneManager.LoadScene("LevelEnd");
        
    }

    public void UpdateMoves() {
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
