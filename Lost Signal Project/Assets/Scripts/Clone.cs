using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class Clone : MonoBehaviour
{

    PathNode goal;
    GameManager gm;

    public CloneData data;

    bool first_update = true;

    private float startTime;

    // Start is called before the first frame update
    void Start()
    {
        gm = FindObjectOfType<GameManager>();

        startTime = Time.time;

    }

    // Update is called once per frame
    void Update()
    {   if (first_update)
        {
            first_update = false;

            StartCoroutine(GoToGoal());
        }
    }

    IEnumerator GoToGoal()
    {
        float start_time = Time.time;
        int next_goal_index = 0;

       

        while (true)
        {
            //Print the time of when the function is first called.

            //Debug.Log("Started Coroutine at timestamp : " + Time.time);



            ////PathNode node = player_data.saved_data_temp.GetNode(0);
            //Vector3 lastNode = player_data.saved_data_temp.GetNode(next_goal_index).position;
            ////Vector3 nextNode = player_data.saved_data_temp.GetNode(next_goal_index).position; ;
            ////if (player_data.saved_data_temp.GetNode(next_goal_index+1).position!=null)
            ////    nextNode = player_data.saved_data_temp.GetNode(next_goal_index+1).position;


            //float fracComplete = (Time.time - startTime) / 1;

            //gameObject.transform.position = lastNode; //Vector3.Slerp(lastNode, nextNode, fracComplete);


            ////gameObject.transform.position = player_data.saved_data_temp.GetNode(next_goal_index).position;
            //next_goal_index++;

            //yield on a new YieldInstruction that waits for 5 seconds.

            transform.position += transform.forward * 3;
            yield return new WaitForSeconds(1);  //Should be equal to player safe frequency

        }
    }
}


/*calculamos velocidad necesitada (v=x/t)=spacebetweennodes/savefrequency
             calculamos el vector direction q es la resta entre next node y curr pos
             movement = direction.normalized;
            */


//float distance = (player_data.saved_data_temp.GetNode(next_goal_index).position - gameObject.transform.position).magnitude;
//float needed_speed = distance / 1/*player_data.save_frequency*/;

//Vector3 direction = player_data.saved_data_temp.GetNode(next_goal_index).position - gameObject.transform.position;

//Vector3 movement = direction.normalized;

//movement *= needed_speed;

//movement.y = 0;
//gameObject.transform.position = movement * Time.deltaTime;
