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

    int next_goal_index = -1; //La corrutina comença sumant i aixi comença amb 0

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



        while (true)
        {
            //Print the time of when the function is first called.
            //Debug.Log("Started Coroutine at timestamp : " + Time.time);


            next_goal_index++;

            Vector3 nextNode;

            if (next_goal_index < data.path.Count)
            {
                nextNode = data.GetNode(next_goal_index).position;


                //float fracComplete = (Time.time - startTime) / 1;

                gameObject.transform.position = nextNode; //Vector3.Slerp(lastNode, nextNode, fracComplete);
            }
            else
                break;


            
            yield return new WaitForSeconds(0.1f);  //Should be equal to player safe frequency

        }

        yield return null;
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
