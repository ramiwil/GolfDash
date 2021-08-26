using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneReloader : MonoBehaviour
{   
    public Rigidbody player;

    // Update is called once per frame
    void Update()
    {
        if(player.position.y < 0) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
