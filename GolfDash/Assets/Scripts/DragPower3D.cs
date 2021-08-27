using System;
using UnityEngine;
using UnityEngine.SceneManagement;

//these are required for the script to work.
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(LineRenderer))]


public class DragPower3D : MonoBehaviour
{
    //privates
    private float currentDistance; //the distance from the mouse and ball
    private float goodSpace; //the right amount of space between 0 - max distance
    private float shootPower; //the power when release mouse click
    private Vector3 shootDirection; //derection to shoot
    private LineRenderer line; //use to generate line
    private Transform MainCam; //use to make camera follow ball
    private RaycastHit hitInfo; //for raycasting. enable mouse position to be 3D and not 2D
    private Vector3 currentMousePosition; //the current mouse position
    private Vector3 temp;
    private Touch touch;

    //publics
    [Header("The Layer/layers the floors are on")]
    public LayerMask groundLayers;
    [Header("Max pull distance")]
    public float maxDistance = 3f;
    [Header("Power")]
    public float power;
    [Header("The colors for your Line Renderer")]
    public Color StartColor;
    public Color EndColor;
    [Header("Custom camera offset")]
    public Vector3 CamOffset = new Vector3(0,7,-15);
    [Header("Should the camera follow the ball?")]
    public bool CameraFollowBall;
    [Header("Camera follow speed")]
    public float smoothSpeed = 10.0f;
    private Rigidbody player;

    private float thres = GameManager.shootThreshold;


    private void Awake()
    {
        player = GetComponent<Rigidbody>();
        //lets find what we need in the game and components
        line = GetComponent<LineRenderer>(); //set line renderer

        //get the main camera with tag if follow ball 
        MainCam = GameObject.FindGameObjectWithTag("MainCamera").transform; 
    }


    private void OnMouseDown()
    {
        if (SceneManager.GetActiveScene() != SceneManager.GetSceneByName("LevelEndScreen")) {
            if (player.velocity.magnitude < thres) {
                //enable toe first point of the line
                //line.enabled = true;
                //the line begins at this target position
                line.SetPosition(0, transform.position);
            }
        }
        
     }

     private void OnMouseDrag()
     {
        if (SceneManager.GetActiveScene() != SceneManager.GetSceneByName("LevelEndScreen")) {
            if (player.velocity.magnitude < thres) {
                line.enabled = true;
                currentDistance = Vector3.Distance(currentMousePosition, transform.position); //update the current distcance
                //lets make sure we dont go pass max distance
                if (currentDistance <= maxDistance)
                {
                    temp = currentMousePosition; //saving the current possion while dragin is allowed
                    goodSpace = currentDistance;
                    line.startColor = StartColor; //set the starting color of the line
                }
                else
                {
                    temp = new Vector3(currentMousePosition.x, currentMousePosition.y, temp.z); // dont go any further
                    goodSpace = maxDistance;
                }
                //assign the shoot power and times it by your desired power
                shootPower = Mathf.Abs(goodSpace) * power;

                //get mouse position over the floor - when we drag the mouse position will be allow the x y and Z in 3D :) Yay!
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out hitInfo, Mathf.Infinity, groundLayers))
                {
                    currentMousePosition = new Vector3(hitInfo.point.x, transform.position.y, hitInfo.point.z);
                }
        
                //calculate the shoot Direction
                shootDirection = Vector3.Normalize(currentMousePosition - transform.position);
                //handle line drawing and colors
        
                ///update the line while we drag
                line.SetPosition(1, temp);
            }
        }
                
     }

     private void OnMouseUp()
     {
         if (SceneManager.GetActiveScene() != SceneManager.GetSceneByName("LevelEndScreen")) {
            if (player.velocity.magnitude < thres) {
                Vector3 push = shootDirection * shootPower * -1; //force in the correct direction
                GetComponent<Rigidbody>().AddForce(push, ForceMode.Impulse);
                line.enabled = false; //remove the line
            }
        }
                
     }

     private void LateUpdate()
     {
         if (CameraFollowBall)
         {
             //position for camera to follow with offset.
             Vector3 desiredPosition = transform.position + CamOffset;
             // camera follow balll
             MainCam.position = desiredPosition;
         }
         //change color gradualy base of how far you drag
         line.endColor = Color.Lerp(StartColor, EndColor, currentDistance / maxDistance);
     }


}
