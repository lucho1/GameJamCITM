using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    int round;

    float life_time;
    float current_lifetime;
    
    // Start is called before the first frame update
    void Start()
    {
        current_lifetime = 0;


    }

    // Update is called once per frame
    void Update()
    {
        current_lifetime += Time.deltaTime;
        
    }

    void CheckIfTimeOver()
    {
        if (current_lifetime >= life_time)
        {
            //do stuff
        }
    }
}
