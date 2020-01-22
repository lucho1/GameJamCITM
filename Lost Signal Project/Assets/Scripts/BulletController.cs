using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float speed;

    public SphereCollider collider;

    GameObject GameController;


    // Start is called before the first frame update
    void Start()
    {
        GameController = GameObject.Find("GameController");
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


        if(other.tag == "Clone")
        {
            int a = 212;
            a++;
            Destroy(other.gameObject);
        }
        if(other.gameObject.tag == "Player")
        {
            if(other.gameObject.name == "Player1")
            {
                int a=0;
                a++;
                //TODO 
            }
            else
            {
                int b=0;
                b++;
                //stuff
            }

            GameController.GetComponent<RoundManager>().GoToNextRound();
        }

        if(gameObject.tag == "clone")
        {

        }

        Destroy(gameObject);
    }
}
