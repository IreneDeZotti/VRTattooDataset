
using UnityEngine;
using System.Collections;
 
public class CameraZoom : MonoBehaviour 
{
    void  Update ()
    {
        //Zooming Out
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
            {
                if (Camera.main.fieldOfView<=125)
                    Camera.main.fieldOfView +=2;
                if (Camera.main.orthographicSize<=20)
                    Camera.main.orthographicSize +=0.5f;
    
            }
        //Zooming In
        if (Input.GetAxis("Mouse ScrollWheel") > 0)
            {
                if (Camera.main.fieldOfView>2)
                    Camera.main.fieldOfView -=2;
                if (Camera.main.orthographicSize>=1)
                    Camera.main.orthographicSize -=0.5f;
            }
        
        //Switch camera between Perspective and Orthographic
        if (Input.GetKeyUp(KeyCode.B ))
        {
            if (Camera.main.orthographic==true)
                Camera.main.orthographic=false;
            else
                Camera.main.orthographic=true;
        }
    }
}
 

