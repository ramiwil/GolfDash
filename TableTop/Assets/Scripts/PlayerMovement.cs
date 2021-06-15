using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody ball;
    public float force;

    Vector3 touchPos;
    // Start is called before the first frame update
    void Start()
    {
        ball.AddForce(force,0,0);
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began) {
        //    Ray ray = Camera.main.ScreenPointToRay(Input.touches[0].position);
        //    RaycastHit hit;

        //    if (Physics.Raycast(ray, out hit)) {
        //        if (hit.collider != null) {
        //            //ball.AddForce(force,0,0);
        //        }
        //    }
        //}

        if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began) {
            if (Input.touches[0].position.x > 10) {
                touchPos.z = Input.touches[0].position.x / 90;
            } else {
                touchPos.z = Input.touches[0].position.x;
            }

            if (Input.touches[0].position.y > 10) {
                touchPos.x = 0;
            } else {
                touchPos.x = Input.touches[0].position.y;
            }

           touchPos.y = 2;
           Debug.Log(touchPos);
           ball.position = touchPos;
           
        }

    }
}
