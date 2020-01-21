using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Vector3 spawn_position;
    // Start is called before the first frame update
    void Start()
    {
        spawn_position = new Vector3(0, 0, 0); //Es pot canviar

        //Afegir un event
        RoundManager rm = FindObjectOfType<RoundManager>();
        rm.OnRoundEndEvent.AddListener(OnRoundEnd);
        rm.OnRoundStartEvent.AddListener(OnRoundStart);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnRoundStart()
    {

    }

    public void OnRoundEnd()
    {
        Debug.Log("End round from player");

        this.transform.position = spawn_position;
    }
}
