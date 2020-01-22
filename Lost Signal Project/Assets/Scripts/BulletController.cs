using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float speed;

    public SphereCollider collider;
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

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }
}
