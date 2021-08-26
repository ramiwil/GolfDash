using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelFlagData : MonoBehaviour
{
    public static IDictionary<string, int> levelFlagData = new Dictionary<string, int>();
    public Text totalFlags;
    public static int totalFlagsInt;
    void Start() {
        totalFlagsInt = 0;

        foreach(KeyValuePair<string, int> entry in levelFlagData)
        {
            totalFlagsInt += entry.Value;
        }

        totalFlags.text = totalFlagsInt.ToString();

        Debug.Log(levelFlagData["Level01"]);
    }
    

}
