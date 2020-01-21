using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed = 10.0f;
    public float rotationSpeed = 100.0f;
    
    void Update()
    {
        //Position 
        Vector3 translation = new Vector3(Input.GetAxis("Horizontal") * movementSpeed, 0,Input.GetAxis("Vertical") * movementSpeed);
        translation *= Time.deltaTime;

        transform.position += translation;

        float inputX = Input.GetAxis("RightStickVertical");
        float inputY = Input.GetAxis("RightStickHorizontal");

        if (inputY == 0 && inputX == 0)
            return;

        float finalAngle = Mathf.Atan(inputY/inputX);


        //Adjust angle depending on its quadrant
        if (inputX < 0 || inputY < 0)
            finalAngle += Mathf.PI;

        if (inputX >= 0 && inputY < 0)
            finalAngle += Mathf.PI;
        

        //Debug.Log(finalAngle * 180/Mathf.PI);


        //Vector3 rotation = new Vector3(0, Input.GetAxis("Fire1") * rotationSpeed,0);

        //rotation *= Time.deltaTime;
        //transform.Rotate(rotation);

        //Update position & 
        if (finalAngle !=0 )
            transform.rotation = Quaternion.Euler(0, finalAngle*180/Mathf.PI, 0);
    }
}
