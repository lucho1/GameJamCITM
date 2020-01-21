using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject player_1;
    public GameObject player_2;

    //Ignore the collisions between the players and their own bullets
    
    // Start is called before the first frame update
    void Start()
    {
        Physics.IgnoreLayerCollision(8,10);
        Physics.IgnoreLayerCollision(9, 11);
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public GameObject GetPlayerOne() { return player_1; }
    public GameObject GetPlayerTwo() { return player_2; }
}

