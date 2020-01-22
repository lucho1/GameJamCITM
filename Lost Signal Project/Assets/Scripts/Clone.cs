using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class Clone : MonoBehaviour
{
    public GameObject bullet_prefav; 
    PathNode goal;
    GameManager gm;

    public CloneData data;

    bool first_update = true;

    int next_goal_index = 0; //La corrutina comença sumant i aixi comença amb 0

    private float startTime;

    private float last_goal_change;

    int shots_fired = 0;

    PathNode last_node;

    public  int player_to_copy = 0;

    public AudioClip shootFX;
    private AudioSource Audiosrc;

    // Start is called before the first frame update
    void Start()
    {
        gm = FindObjectOfType<GameManager>();

        startTime = Time.time;

        last_node.position = data.GetNode(next_goal_index).position;
        last_node.rotation = Quaternion.identity;

        Audiosrc = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {   if (first_update)
        {
            first_update = false;

            StartCoroutine(GoToGoal());

            startTime = Time.time;
        }

        //Manage shots
        for (int i = 0; i < data.shot_time_stamps.Count; i++)
        {
            if (Time.time - startTime >= data.shot_time_stamps[i].shot_time_stamp)
            {
                if (shots_fired <= i) {
                    Transform fire_position_transform = null;

                    foreach (Transform t in gameObject.transform)
                    {
                        if (t.tag == "FirePosition")
                        {
                            fire_position_transform = t;
                        }
                    }

                    Vector3 fire_position = new Vector3(fire_position_transform.position.x, fire_position_transform.position.y, fire_position_transform.position.z);



                    if (player_to_copy == 1)
                    {
                        Instantiate(bullet_prefav, fire_position, data.shot_time_stamps[i].rotation).layer = gm.GetPlayerOne().layer;
                    }
                    if (player_to_copy == 2)
                    {
                        Instantiate(bullet_prefav, fire_position, data.shot_time_stamps[i].rotation).layer = gm.GetPlayerTwo().layer;
                    }
                    Audiosrc.clip = shootFX;
                    Audiosrc.Play();
                    shots_fired++;
                }
            }
        }
       

         float fraction_of_time_passed = (Time.time - last_goal_change) / 0.3f;

         gameObject.transform.position = /*nextNode;*/ Vector3.Slerp(last_node.position, goal.position, fraction_of_time_passed);
         gameObject.transform.rotation = Quaternion.Slerp(last_node.rotation, goal.rotation, fraction_of_time_passed);
        //Debug.Log("pos:" + gameObject.transform.position);


    }

    IEnumerator GoToGoal()
    {


        while (true)
        {
            //Print the time of when the function is first called.
            //Debug.Log("Started Coroutine at timestamp : " + Time.time);


            next_goal_index++;

            if (next_goal_index < data.path.Count)
            {
                Debug.Log("SwitchGoal");
                goal = data.GetNode(next_goal_index);
                last_goal_change = Time.time;
            }
            else
                break;


            
            yield return new WaitForSeconds(0.3f);  //Should be equal to player safe frequency

            last_node = goal;

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
