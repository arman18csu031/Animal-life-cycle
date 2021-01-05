using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

using System.Collections;
using System.Collections.Generic;
using System.Globalization;

using GoogleARCore;

public class augmentedimagecontroller : MonoBehaviour
{
    private List<AugmentedImage> ALC = new List<AugmentedImage>();

    public Camera FirstPersonCamera;

    public GameObject prefab;

    private bool isDetected = false;

    void Update()
    {
        if (Session.Status != SessionStatus.Tracking)
        {
            return;
        }
        else
        {

            Session.GetTrackables<AugmentedImage>(ALC, TrackableQueryFilter.Updated);
            foreach (AugmentedImage img in ALC)
            {
                if (img.TrackingState == TrackingState.Tracking)
                {

                    if (img.Name == "ArCore")
                    {

                        isDetected = true;
                        Anchor anchor = img.CreateAnchor(img.CenterPose);
                        Instantiate(prefab, anchor.transform.position, Quaternion.LookRotation(-img.CenterPose.up));
                    }
                }
                else if(img.TrackingState == TrackingState.Stopped)
                {
                    GameObject.Destroy(prefab);
                }
            }

        }
    }
}

