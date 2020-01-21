using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clone : MonoBehaviour
{
    public PlayerDataController player_data;
    
    // Start is called before the first frame update
    void Start()
    {
        player_data = new PlayerDataController();
    }

    // Update is called once per frame
    void Update()
    {
        //if(player.saved_data_temp.GetNode(2).transform != null)
        //{
        //    gameObject.transform.position(player.saved_data_temp.GetNode(2).transform);
        //}
        if (player_data.saved_data_temp.GetNode(1).transform != null){
            gameObject.transform.position = player_data.saved_data_temp.GetNode(1).transform.position;
        }
    }
}
