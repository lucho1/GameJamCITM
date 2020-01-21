﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClonesController : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject player_one_clone_prefab;
    public GameObject player_two_clone_prefab;

    public GameObject DebugPathSphere;

    List<CloneData> player_one_clones_data;
    List<CloneData> player_two_clones_data;

    RoundManager rm;

    GameManager gm;
    void Start()
    {
        gm = gameObject.GetComponent<GameManager>();

        player_one_clones_data = new List<CloneData>();

        rm = FindObjectOfType<RoundManager>();
        rm.OnRoundEndEvent.AddListener(OnRoundEnd);
        rm.OnRoundStartEvent.AddListener(OnRoundStart);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnRoundEnd()
    {
        CloneData p1_data = gm.GetPlayerOne().GetComponent<PlayerDataController>().GetCloneData();
        // Ara p2 es null CloneData p2_data = gm.GetPlayerTwo().GetComponent<PlayerDataController>().GetCloneData();

        player_one_clones_data.Add(p1_data.GetCopy());

        Clone[] clones = FindObjectsOfType<Clone>();
        foreach (Clone clone in clones)
        {
            Destroy(clone.gameObject);
        }
    }


    void OnRoundStart() //Will be called for first time in the second round
    {
        
        foreach (CloneData clone_data in player_one_clones_data)
        {
            GameObject clone_go = Instantiate(player_one_clone_prefab, new Vector3(Random.Range(-15.0f, 15.0f), gm.GetPlayerOne().transform.position.y,0), Quaternion.identity);

            clone_go.GetComponent<Clone>().data = clone_data.GetCopy();

            for(int i = 0;i< clone_data.path.Count; i++)
            {
                GameObject sphere = Instantiate(DebugPathSphere, clone_data.path[i].position, clone_data.path[i].rotation);
               // sphere.transform.position = clone_data.path[i].position;
            }
            
            

           

            
           

        }


        Debug.Log(player_one_clones_data.Count);
    }

}
