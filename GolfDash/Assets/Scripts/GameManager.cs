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
    
    public static float shootThreshold = 2f; 


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
            if (player.velocity.magnitude < shootThreshold) {
                shootStatus.text = "Shoot!";
            } else {
                shootStatus.text = "Wait...";
            }
        }

        if(SceneManager.GetActiveScene() != SceneManager.GetSceneByName("LevelEndScreen")) {
            if (Input.touchCount > 0) {
                touch = Input.GetTouch(0);


                Ray raycast = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit raycastHit;

                if (Physics.Raycast(raycast, out raycastHit))
                {

                    if (raycastHit.collider.CompareTag("Player") && touch.phase == TouchPhase.Ended && player.velocity.magnitude < shootThreshold)
                    {
                        Debug.Log("Ball clicked");

                        //if (touch.phase == TouchPhase.Ended && player.velocity.magnitude < shootThreshold) {
                            playerMoves++;
                        //}
                    }

                    
                }


                
                
                playerMovesText.text = playerMoves.ToString();
            }
        }   
    }

}
