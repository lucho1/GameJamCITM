using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clone : MonoBehaviour
{
    PlayerDataController player_data;

    PathNode goal;
    
    // Start is called before the first frame update
    void Start()
    {
        GameManager gm = FindObjectOfType<GameManager>();

        player_data = gm.GetPlayerOne().GetComponent<PlayerDataController>();
    }

    // Update is called once per frame
    void Update()
    {
        //if(player.saved_data_temp.GetNode(2).transform != null)
        //{
        //    gameObject.transform.position(player.saved_data_temp.GetNode(2).transform);
        //}
        //if (player_data.saved_data_temp.GetNode(1).transform != null){
        //    gameObject.transform.position = player_data.saved_data_temp.GetNode(1).transform.position;
        //}

        
    }

    IEnumerator GoToGoal()
    {
        float start_time = Time.time;
        int next_goal_index = 0;
        while (true)
        {
            //Print the time of when the function is first called.
            //Debug.Log("Started Coroutine at timestamp : " + Time.time);

            //yield on a new YieldInstruction that waits for 5 seconds.
            yield return new WaitForSeconds(1);

            //Ves al goal


        }
    }
}
