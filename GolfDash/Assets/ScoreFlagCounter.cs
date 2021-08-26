using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreFlagCounter : MonoBehaviour
{
    public  Image oneFlag;
    public  Image twoFlags;
    public  Image threeFlags;
    public  string levelName;
    // Start is called before the first frame update
    void Start()
    {
        oneFlag.enabled = false;
        twoFlags.enabled = false;
        threeFlags.enabled = false;

        if (LevelFlagData.levelFlagData[levelName] == 3) {
            threeFlags.enabled = true;
        } else if (LevelFlagData.levelFlagData[levelName] == 2) {
            twoFlags.enabled = true;
        } else if (LevelFlagData.levelFlagData[levelName] == 1) {
            oneFlag.enabled = true;
        }
        
    }

}
