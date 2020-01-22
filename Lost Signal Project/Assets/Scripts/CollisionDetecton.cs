using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetecton : MonoBehaviour
{
    GameManager gm;

    private void Start()
    {
        gm = GameObject.Find("GameController").GetComponent<GameManager>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("HIT");
       
    }

    //// Start is called before the first frame update
    //void Start()
    //{
        
    //}

    //// Update is called once per frame
    //void Update()
    //{
        
    //}
}
