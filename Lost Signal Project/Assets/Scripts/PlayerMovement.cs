using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float maxMovementSpeed = 10.0f;

    [Range(0.0f,1.0f)]public float movementAcceleration=0.10f;

    private Vector3 currMovementSpeed;
    private float currRotationSpeed=0.0f;

    [Range(1, 2)] public int controllerNumber;

    private string leftInputX, leftInputY;
    private string rightInputX, rightInputY;

    void Start()
    {
        leftInputX = "LeftStickHorizontal"+ controllerNumber.ToString();
        leftInputY = "LeftStickVertical" + controllerNumber.ToString();

        rightInputX = "RightStickVertical" + controllerNumber.ToString();
        rightInputY = "RightStickHorizontal" + controllerNumber.ToString();

        currMovementSpeed = new Vector3(0.0f, 0.0f, 0.0f);
    }

    void Update()
    {
        if (Time.timeScale == 0.0f)
            return;
        //Calculate new position 
        Vector3 desiredSpeed = new Vector3(Input.GetAxis(leftInputX) * maxMovementSpeed, 0,Input.GetAxis(leftInputY) * maxMovementSpeed);
        currMovementSpeed += (desiredSpeed - currMovementSpeed) * movementAcceleration;

        float inputX = Input.GetAxis(rightInputX);
        float inputY = Input.GetAxis(rightInputY);
        
        //Update rotations
        if (inputY != 0 && inputX != 0)
        {
            //Angle we want
            float finalAngle = Mathf.Atan(inputY / inputX);

            //Adjust angle depending on its quadrant
            if (inputX < 0 || inputY < 0)
                finalAngle += Mathf.PI;

            if (inputX >= 0 && inputY < 0)
                finalAngle += Mathf.PI;

            float currentAngle = transform.rotation.y;

            float newAngle = currentAngle + (currRotationSpeed * Time.deltaTime);

            //Update position &
            transform.rotation = Quaternion.Euler(0, -finalAngle * 180 / Mathf.PI, 0);
        }

        transform.position += currMovementSpeed*Time.deltaTime;
    }
    
}
