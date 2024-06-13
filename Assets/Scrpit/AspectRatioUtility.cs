using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AspectRatioUtility : MonoBehaviour
{
    private void Start()
    {
        Adjust(); 
    }
    public void Adjust()
    {
        float targetaspect = 1.07f / 1f; 

        float windowaspect = (float)Screen.width / (float)Screen.height;

        float scalehight = windowaspect / targetaspect;

        Camera camera = GetComponent<Camera>();

        if(scalehight < 1.0f)
        {
            Rect rect = camera.rect;

            rect.width = 1.0f;
            rect.height = scalehight;
            rect.x = 0;
            rect.y = (1.0f - scalehight) / 2.0f;

            camera.rect = rect;
        }
        else
        {
            float scalewidth = 1.0f / scalehight;

            Rect rect = camera.rect;

            rect.width = scalewidth;
            rect.height = 1.0f;
            rect.x = (1.0f - scalewidth) / 2.0f;
            rect.y = 0;

            camera.rect = rect;
        }
    }
}
