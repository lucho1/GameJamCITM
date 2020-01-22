using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

//public class Round
//{
//    int index;
//    public float LifeTime;

//    void NextRound()
//    {
//        index++;
//    }
//}

public class RoundManager : MonoBehaviour
{
    int current_round;

    float life_time;
    float current_lifetime;

    public float last_round_start_timestamp;

    public UnityEvent OnRoundEndEvent;

    public UnityEvent OnRoundStartEvent;

    // Start is called before the first frame update
    void Start()
    {
        GameManager gm = FindObjectOfType<GameManager>();
        current_lifetime = 0;
        current_round = 0;

        if (OnRoundEndEvent == null)
            OnRoundEndEvent = new UnityEvent();


        if (OnRoundStartEvent == null)
            OnRoundStartEvent = new UnityEvent();

        last_round_start_timestamp = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        current_lifetime += Time.deltaTime;


        if (Input.GetKeyDown(KeyCode.R))
        {
            GoToNextRound();
        }
    }

    void CheckIfTimeOver()
    {
        if (current_lifetime >= life_time)
        {
            //do stuff
        }
    }

    public void GoToNextRound()
    {
        GameObject.Find("RewindSound").GetComponent<AudioSource>().Play();
        current_round++;
        OnRoundEndEvent.Invoke();
        last_round_start_timestamp = Time.time;
        OnRoundStartEvent.Invoke();
    }

    public int GetCurrentRound()
    {
        return current_round;
    }
}
