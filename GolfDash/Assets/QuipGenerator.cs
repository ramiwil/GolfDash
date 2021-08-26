using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuipGenerator : MonoBehaviour
{
    // Start is called before the first frame update
    IDictionary<int, string> one_flag_quip = new Dictionary<int, string>();
    IDictionary<int, string> two_flag_quip = new Dictionary<int, string>();
    IDictionary<int, string> three_flag_quip = new Dictionary<int, string>();

    public Text quip;

    void Start()
    {
        int randomInt = Random.Range(0,4);
        // one flag quips
        one_flag_quip.Add(0, "Oh brother, this guy STINKS!");
        one_flag_quip.Add(1, "Tiger Woods is bored.");
        one_flag_quip.Add(2, "It's ok big guy, you'll get 'em next time.");
        one_flag_quip.Add(3, ":(");
        one_flag_quip.Add(4, "Do better.");

        // two flag quips
        two_flag_quip.Add(0, "Tiger Woods is unfazed.");
        two_flag_quip.Add(1, "So close");
        two_flag_quip.Add(2, "No one's perfect, anyway.");
        two_flag_quip.Add(3, "I raised you better than this.");
        two_flag_quip.Add(4, "Mediocre.");

        // three flag quips
        three_flag_quip.Add(0, "ok legend");
        three_flag_quip.Add(1, "Tiger Woods is shaking.");
        three_flag_quip.Add(2, "We got a pro on our hands");
        three_flag_quip.Add(3, "Why not 4 flags?");
        three_flag_quip.Add(4, "ok showoff");


        if (GameManager.finalPlayerMoves > 8) {
            quip.text = one_flag_quip[randomInt];
        } else if (GameManager.finalPlayerMoves <= 8 && GameManager.finalPlayerMoves > 6) {
            quip.text = two_flag_quip[randomInt];
        } else {
            quip.text = three_flag_quip[randomInt];
        }

    }


}
