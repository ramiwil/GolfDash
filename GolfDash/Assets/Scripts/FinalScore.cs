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
    public int flags;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(GameManager.finalPlayerMoves);

        if (GameManager.finalPlayerMoves > 8) {
            third.enabled = false;
            second.enabled = false;
            flags = 1;
        } else if (GameManager.finalPlayerMoves <= 8 && GameManager.finalPlayerMoves > 6) {
            third.enabled = false;
            flags = 2;
        } else {
            flags = 3;
        }

        Debug.Log(flags);
        LevelFlagData.levelFlagData[GameManager.curScene] = flags;

        Debug.Log(LevelFlagData.levelFlagData[GameManager.curScene] + " in level data");
        finalScoreText.text = GameManager.finalPlayerMoves.ToString();
    }


}
