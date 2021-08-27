using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneReloader : MonoBehaviour
{   
    public Rigidbody player;

    public int bottomLimit;

    // Update is called once per frame
    void Update()
    {
        if(player.position.y < bottomLimit) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
