using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyColorChanger : MonoBehaviour
{
    public Camera cam;
    public Color color1 = new Color(0.0f,0.0f,0.0f,1);
    public Color color2 = new Color(0.0f,0.0f,0.0f,1);
    public Color color3 = new Color(0.0f,0.0f,0.0f,1);
    public Color color4 = new Color(0.0f,0.0f,0.0f,1);
    public Material floor;

    public void OnTriggerEnter() {
        Color[] colors = {color1, color2, color3, color4};
        int index = (int)Random.Range(0.0f, 3.0f);
        int index2 = (int)Random.Range(0.0f, 3.0f);
        cam.backgroundColor  = colors[index];
        floor.color = colors[index2];
    }
}
