using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    private Touch touch;
    private Vector2 touchPosition;
    private Quaternion rotationZ;
    private float rotateSpeed = 0.1f;

    void Update()
    {
        if(Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);
            if(touch.phase == TouchPhase.Moved)
            {
                rotationZ = Quaternion.Euler(0f, 0f, -touch.deltaPosition.x * rotateSpeed);
                transform.rotation = rotationZ * transform.rotation;
            }
        }
    }
}
