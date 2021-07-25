using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleScreenBallMovement : MonoBehaviour
{
    public Rigidbody player;
    public float speed = 10.0f;
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Rigidbody>();
        player.AddForce(0,-1000,0);
    }

    // Update is called once per frame
    void Update()
    {
        
        Vector3 force = Vector3.zero;

        force.x = -Input.acceleration.y;
        force.z = Input.acceleration.x;

        force *= Time.deltaTime;


        player.AddForce(force*speed);

    }
}
