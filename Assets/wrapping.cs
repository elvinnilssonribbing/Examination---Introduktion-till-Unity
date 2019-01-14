using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wrapping : MonoBehaviour
{
    Renderer renderer;   // Här döps variabeln för renderern (det som gör alla objekt synliga) till "renderer".     

    // Use this for initialization
    void Start()
    {
        var cam = Camera.main;

        var viewportPosition = cam.WorldToViewportPoint(transform.position);

        var newPosition = transform.position;

        transform.position = new Vector3(Random.Range(-11, 11), Random.Range(-4.5f, 4.5f), 0);

        renderer = GetComponent<Renderer>();
    }

    bool isWrappingX = false;
    bool isWrappingY = false;

    bool CheckRenderers = false;

    // Update is called once per frame
    void Update()
    {
        var cam = Camera.main;

        var viewportPosition = cam.WorldToViewportPoint(transform.position);

        var newPosition = transform.position;

        var isVisible = CheckRenderers;

        if (renderer.isVisible)
        {
            CheckRenderers = true;
        }
        else
        {
            CheckRenderers = false;
        }

        if (isVisible)
        {
            isWrappingX = false;
            isWrappingY = false;
        }



        if (!isWrappingX & (viewportPosition.x > 1 || viewportPosition.x < 0))
        {
            newPosition.x = -(newPosition.x);
            isWrappingX = true;
        }

        if (!isWrappingY & (viewportPosition.y > 1 || viewportPosition.y < 0))
        {
            newPosition.y = -(newPosition.y);
            isWrappingY = true;
        }

        transform.position = newPosition;
    }
}
