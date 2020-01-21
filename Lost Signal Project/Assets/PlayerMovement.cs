using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed = 10.0f;
    public float rotationSpeed = 100.0f;

    public int controllerNumber;

    private string leftInputX, leftInputY;
    private string rightInputX, rightInputY;

    void Start()
    {
        leftInputX = "LeftStickHorizontal"+ controllerNumber.ToString();
        leftInputY = "LeftStickVertical" + controllerNumber.ToString();

        rightInputX = "RightStickVertical" + controllerNumber.ToString();
        rightInputY = "RightStickHorizontal" + controllerNumber.ToString();
    }

    void Update()
    {
        //Position 
        Vector3 translation = new Vector3(Input.GetAxis(leftInputX) * movementSpeed, 0,Input.GetAxis(leftInputY) * movementSpeed);
        translation *= Time.deltaTime;

        transform.position += translation;

        float inputX = Input.GetAxis(rightInputX);
        float inputY = Input.GetAxis(rightInputY);

        if (inputY == 0 && inputX == 0)
            return;

        float finalAngle = Mathf.Atan(inputY/inputX);

        //Adjust angle depending on its quadrant
        if (inputX < 0 || inputY < 0)
            finalAngle += Mathf.PI;

        if (inputX >= 0 && inputY < 0)
            finalAngle += Mathf.PI;

        //Update position & 
        if (finalAngle !=0 )
            transform.rotation = Quaternion.Euler(0, -finalAngle*180/Mathf.PI, 0);
    }
}
