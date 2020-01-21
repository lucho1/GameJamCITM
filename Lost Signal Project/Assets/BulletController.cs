using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float speed;

    bool destroy_when_possible = false;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.SetPositionAndRotation(
            this.transform.position + this.transform.forward * speed * Time.deltaTime, 
            transform.rotation
        );
    }

    void LateUpdate()
    {
        if (destroy_when_possible)
        {
            Destroy(gameObject);
        }
    }

    void Kill()
    {
        destroy_when_possible = true;
    }
}
