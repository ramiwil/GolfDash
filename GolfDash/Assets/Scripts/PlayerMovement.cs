using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Touch touch;
    public float speedModifier;
    public Rigidbody ball;

    private Vector3 originTouch;
    private Vector3 endTouch;


    // Start is called before the first frame update
    void Start()
    {
        speedModifier = 0.005f;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0) {
            touch = Input.GetTouch(0);

            //if (touch.phase == TouchPhase.Moved) {
            //    transform.position = new Vector3(
            //        transform.position.x + -touch.deltaPosition.y * speedModifier,
            //        transform.position.y,
            //        transform.position.z + touch.deltaPosition.x * speedModifier);
            //    Debug.Log("MOVING");
            //}

            if (touch.phase == TouchPhase.Began) {
                originTouch = touch.position;             
            }


            if (touch.phase == TouchPhase.Ended) {
                endTouch = touch.position;
                originTouch -= endTouch;
                ball.AddForce(transform.position.x + -originTouch.y * speedModifier * 2000,
                    0,
                    transform.position.z + originTouch.x * speedModifier * 2000);
                
            }
        }
    }
}