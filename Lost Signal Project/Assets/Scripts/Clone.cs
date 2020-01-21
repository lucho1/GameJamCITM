using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clone : MonoBehaviour
{
    PlayerDataController player_data;

    PathNode goal;
    GameManager gm;

    // Start is called before the first frame update
    void Start()
    {
        gm = FindObjectOfType<GameManager>();

        player_data = gm.GetPlayerOne().GetComponent<PlayerDataController>();
        StartCoroutine(GoToGoal());
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
            Debug.Log("Started Coroutine at timestamp : " + Time.time);

            //yield on a new YieldInstruction that waits for 5 seconds.
            yield return new WaitForSeconds(3);
            //PathNode node = player_data.saved_data_temp.GetNode(0);

            gameObject.transform.position = player_data.saved_data_temp.GetNode(1).position;
            //if (player_data.saved_data_temp.GetNode(next_goal_index).position != null)
            //{
            //    gameObject.transform.position = player_data.saved_data_temp.GetNode(next_goal_index).position;
            //    next_goal_index++;
            //}

            //Ves al goal


        }
    }
}
