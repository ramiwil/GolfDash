using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineTrajectory : MonoBehaviour
{
    public LineRenderer lr;
    public Rigidbody player;
    public Vector3 startPoint;
    public Vector3 playerPos;
    public Vector3 lineEndPos;

    public Touch touch;
    
    void Start() {
        lr = GetComponent<LineRenderer>();
        
    }

    void Update() {
        if (Input.touchCount > 0) {
            touch = Input.GetTouch(0);

            lr.positionCount = 2;
            Vector3[] points = new Vector3[2];


            if (touch.phase == TouchPhase.Began) {
                startPoint = touch.position;
            }


            startPoint.z = startPoint.y;
            startPoint.y = 2;

            points[0] = startPoint;
            


            if (touch.phase == TouchPhase.Ended) {
                lineEndPos = touch.position;
            }

            lineEndPos.z = lineEndPos.y;
            lineEndPos.y = 2;

            lineEndPos.x = lineEndPos.z * (float)0.1;
            lineEndPos.z = lineEndPos.x * (float)0.1;

            points[1] = lineEndPos;

            lr.SetPositions(points);
        }
    }

}
