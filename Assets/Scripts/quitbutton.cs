using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class quitbutton : MonoBehaviour
{
    public Camera FirstPersonCamera;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Touch myTouch = Input.GetTouch(0);
        if (Input.touchCount < 1 || (myTouch.phase != TouchPhase.Began))
        {
            return;
        }
        else
        {
            Ray touchPos = FirstPersonCamera.ScreenPointToRay(myTouch.position);
            RaycastHit Rayhit;
            if (Physics.Raycast(touchPos, out Rayhit))
            {
                if (Rayhit.collider.CompareTag("quit"))
                    Application.Quit();
            }
        }
    }
}
