using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement: MonoBehaviour
{
    public Camera camera;
    public GameObject finalTransform;

    private bool GameStarted = false;
    private float cameraVelocity = 5.0f;

    void Start()
    {
        
    }
    
    void Update()
    {
        //if (!GameStarted)
        //    StartCameraMovement();
    }

    void StartCameraMovement()
    {
        //Vector3 positionIncrease = finalTransform.transform.position - camera.transform.position;
        //camera.transform.position += (finalTransform.transform.position - camera.transform.position).Normalize * cameraVelocity;
    }
}
