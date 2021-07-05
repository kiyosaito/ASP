using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraViewSize : MonoBehaviour
{

    private float height;
    private float width;

    private float playerXBorder;
    private float playerYBorder;


    // Start is called before the first frame update
    void Start()
    {
        Camera cam = transform.GetComponent<Camera>();
        height = 2f * cam.orthographicSize;
        width = height * cam.aspect;

        playerYBorder = cam.orthographicSize - height / 20f;
        playerXBorder = width / 2.15f;
    }

    public float GetPlayerXBorder()
    {
        return playerXBorder;
    }

    public float GetPlayerYBorder()
    {
        return playerYBorder;
    }

    public float GetHeight()
    {
        return height;
    }

    public float GetWidth()
    {
        return width;
    }
}
