using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUp2 : MonoBehaviour
{
    public GameObject title;
    public GameObject egg;
    public GameObject larva;
    public GameObject adult;

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
                if (Rayhit.collider.CompareTag("egg"))
                {
                    title.SetActive(false);
                    larva.SetActive(false);
                    adult.SetActive(false);
                    egg.SetActive(true);
                }

                if (Rayhit.collider.CompareTag("larva"))
                {
                    title.SetActive(false);
                    egg.SetActive(false);
                    adult.SetActive(false);
                    larva.SetActive(true);
                }

                if (Rayhit.collider.CompareTag("adult"))
                {
                    title.SetActive(false);
                    egg.SetActive(false);
                    larva.SetActive(false);
                    adult.SetActive(true);
                }
            }
        }
    }
}
