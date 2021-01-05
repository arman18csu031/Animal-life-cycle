using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using GoogleARCore;

public class SceneLoader : MonoBehaviour
{
    public Camera FirstPersonCamera;
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
                if (Rayhit.collider.CompareTag("Butterfly"))
                {
                    SceneManager.LoadScene(1);
                }

                if (Rayhit.collider.CompareTag("Cockroach"))
                {
                    SceneManager.LoadScene(2);
                }

                if (Rayhit.collider.CompareTag("Frog"))
                {
                    SceneManager.LoadScene(3);
                }

                if (Rayhit.collider.CompareTag("Ladybug"))
                {
                    SceneManager.LoadScene(4);
                }

                if (Rayhit.collider.CompareTag("Mosquito"))
                {
                    SceneManager.LoadScene(5);
                }
            }
        }
    }
}
