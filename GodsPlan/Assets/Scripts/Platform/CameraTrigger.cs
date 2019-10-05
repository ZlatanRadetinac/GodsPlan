using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTrigger : MonoBehaviour
{
    CameraController cameraControler;
    Collider2D drake;

    public Transform newCamerPosition;

    // Start is called before the first frame update
    void Awake()
    {
        cameraControler = FindObjectOfType<CameraController>();
        drake = FindObjectOfType<PlayerController>().GetComponent<Collider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision == drake)
        {
            cameraControler.MoveCameraToNewPlace(newCamerPosition);
            print("Sent new position");
        }
    }
}
