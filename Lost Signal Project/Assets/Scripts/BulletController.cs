﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float speed;

    public SphereCollider collider;

    GameObject GameController;
    GameManager gm;

    // Start is called before the first frame update
    void Start()
    {
        GameController = GameObject.Find("GameController");
        gm = FindObjectOfType<GameManager>();
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
            Destroy(other.gameObject);
        }
        if(other.gameObject.tag == "Player")
        {
            if(other.gameObject.name == "Player1")
            {
                gm.Player1Kills++;
            }
            else
            {
                gm.Player2Kills++;
            }

            GameController.GetComponent<RoundManager>().GoToNextRound();
        }

        if(gameObject.tag == "clone")
        {

        }

        Destroy(gameObject);
    }
}
