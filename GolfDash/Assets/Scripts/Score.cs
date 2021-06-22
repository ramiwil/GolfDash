using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{

    public Text scoreText;
    public Touch touch;
    private int score = 0;
    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0) {
            touch = Input.GetTouch(0);
            
            if (touch.phase == TouchPhase.Ended) {
                score++;
            }

            scoreText.text = score.ToString();
        }      
    }
}
