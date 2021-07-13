using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinalScore : MonoBehaviour
{
    public Text finalScoreText;
    public Image first;
    public Image second;
    public Image third;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(GameManager.playerMoves);
        if (GameManager.playerMoves > 8) {
            third.enabled = false;
            second.enabled = false;
        } else if (GameManager.playerMoves <= 8 && GameManager.playerMoves > 6) {
            third.enabled = false;
        }
        finalScoreText.text = GameManager.playerMoves.ToString();
    }


}
