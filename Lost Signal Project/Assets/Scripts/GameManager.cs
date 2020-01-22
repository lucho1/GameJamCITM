using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject player_1;
    public GameObject player_2;
    public GameObject StartingMusic;

    // Start is called before the first frame update
    void Start()
    {
        if(StartingMusic)
            StartingMusic.GetComponent<MusicManager>().ActivateMusic();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public GameObject GetPlayerOne() { return player_1; }
    public GameObject GetPlayerTwo() { return player_2; }
}

