using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    Camera camera;

    bool transitioning = false;
    Transform newTransform;
    Transform startTransform;
    public float transitionTimeS = 5f;
    public float remainingTransitionTime;

    public Transform firstCameraTransform;

    void Awake()
    {
        camera = FindObjectOfType<Camera>();
        camera.transform.position = firstCameraTransform.position;
        startTransform = camera.transform;
    }

    void Update()
    {
        if (transitioning)
        {
            if (remainingTransitionTime > 0.0f)
            {
                print("Lerping");
                remainingTransitionTime -= Time.deltaTime;
                print(remainingTransitionTime);
                camera.transform.position = Vector3.Lerp(startTransform.position, newTransform.position, (transitionTimeS - remainingTransitionTime)/transitionTimeS);
                return;
            }
            camera.transform.position = newTransform.position;
            transitioning = false;
        }
    }

    public void MoveCameraToNewPlace(Transform transform)
    {
        print("Called to move");
        if (newTransform == transform)
        {
            print("same position");
            return;
        }

        print("Moving to new position");

        transitioning = true;
        newTransform = transform;
        startTransform = camera.transform;
        remainingTransitionTime = transitionTimeS;
    }

}
