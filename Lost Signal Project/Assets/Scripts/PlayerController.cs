using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Vector3 spawn_position;
    public AudioClip deadFX;
    private AudioSource Audiosrc;

    // Start is called before the first frame update
    void Start()
    {
        spawn_position = transform.position; //Es pot canviar

        //Afegir un event
        RoundManager rm = FindObjectOfType<RoundManager>();
        rm.OnRoundEndEvent.AddListener(OnRoundEnd);
        rm.OnRoundStartEvent.AddListener(OnRoundStart);

      //  Audiosrc = GetComponent<AudioSource>();
        Audiosrc = GetComponentInChildren<AudioSource>();
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
        Audiosrc.clip = deadFX;
        Audiosrc.Play();
        Debug.Log("End round from player");

        this.transform.position = spawn_position;
    }
}
