using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinchScale : MonoBehaviour
{
    float initialFingersDistance;
    Vector3 initialScale;
    public GameObject objectTemp;
    void Update()
    {
        if (Input.touches.Length == 2)
        {
            Touch t1 = Input.touches[0];
            Touch t2 = Input.touches[1];

            if (t1.phase == TouchPhase.Began || t2.phase == TouchPhase.Began)
            {
                initialFingersDistance = Vector2.Distance(t1.position, t2.position);
                initialScale = objectTemp.transform.localScale;
            }
            else if (t1.phase == TouchPhase.Moved || t2.phase == TouchPhase.Moved)
            {
                var currentFingersDistance = Vector2.Distance(t1.position, t2.position);
                var scaleFactor = currentFingersDistance / initialFingersDistance;
                objectTemp.transform.localScale = initialScale * scaleFactor;
            }
        }
    }
}
