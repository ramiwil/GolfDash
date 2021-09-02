using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotator : MonoBehaviour
{
    public Vector3 positionVal;
    // Start is called before the first frame update
    void OnTriggerEnter()
    {
        FollowPlayer.offset = positionVal;

    }

    // Update is called once per frame
    void OnTriggerStay()
    {
        
    }

    void OnTriggerExit()
    {
        
    }
}
