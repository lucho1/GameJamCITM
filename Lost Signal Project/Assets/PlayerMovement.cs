using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed = 10.0f;
    public float rotationSpeed = 100.0f;
    
    [Range (0,1.0f)]
    public float joystickSensibility;
    


    void Update()
    {
        Vector3 translation = new Vector3(Input.GetAxis("Horizontal") * movementSpeed, 0,Input.GetAxis("Vertical") * movementSpeed);
        translation *= Time.deltaTime;
        transform.position += translation;

        if (Input.GetAxis("Fire1") > joystickSensibility || Input.GetAxis("Fire1") < -joystickSensibility)
        {
            Debug.Log(Input.GetAxis("Fire1"));

            transform.rotation.SetEulerAngles(0.0f,0.0f,0.0f);
           
            //Vector3 rotation = new Vector3(0, Input.GetAxis("Fire1") * rotationSpeed,0);


            //rotation *= Time.deltaTime;
            //transform.Rotate(rotation);
        }
    }
}
