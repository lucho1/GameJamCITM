﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct PathNode
{

    public Vector3 position;
    public Quaternion rotation;
    public float time;
}

public struct ShotInfo
{
    public float shot_time_stamp;
    public Quaternion rotation;
}

public struct CloneData
{
    public List<PathNode> path;

    public List<ShotInfo> shot_time_stamps;

    public int round_to_reproduce;

    public void AddNodeToPath(PathNode n)
    {
        if (path == null)
            path = new List<PathNode>();

        path.Add(n);
    }

    public void AddShotTimeStamp(float new_timestamp,GameObject emmiter)
    {
        if (shot_time_stamps == null)
            shot_time_stamps = new List<ShotInfo>();

        ShotInfo new_shot_info = new ShotInfo();
        new_shot_info.shot_time_stamp = new_timestamp;
        new_shot_info.rotation = emmiter.transform.rotation;

        shot_time_stamps.Add(new_shot_info);
    }

    public PathNode GetNode(int i)
    {
        if (i < path.Count)
            return path[i];
        else
        {
            Debug.LogError("Estas intentant agafar un nodo amb index fora del path");
            return new PathNode();
        }
    }

    public void ResetPathList()
    {
        path.Clear();
    }

    public void ResetShotTimesList()
    {
        if (shot_time_stamps != null)
        shot_time_stamps.Clear();
    }

    public CloneData GetCopy()
    {
        CloneData copy = new CloneData();
        copy.path = new List<PathNode>();

        foreach(PathNode node in path)
        {
            copy.path.Add(node);
        }

        copy.shot_time_stamps = new List<ShotInfo>();

        if (shot_time_stamps != null)
        {
            foreach (ShotInfo shot_info in shot_time_stamps)
            {
                copy.shot_time_stamps.Add(shot_info);
            }
        }


        copy.round_to_reproduce = round_to_reproduce;
        return copy;
    }
}

public class PlayerDataController : MonoBehaviour
{
    float save_frequency = 0.3f;

    public CloneData saved_data_temp;


    RoundManager rm;

    // Start is called before the first frame update
    void Start()
    {
        saved_data_temp = new CloneData();

        rm = FindObjectOfType<RoundManager>();
        rm.OnRoundEndEvent.AddListener(OnRoundEnd);
        rm.OnRoundStartEvent.AddListener(OnRoundStart);

        StartCoroutine(UpdateSavedDataPath());
    }

    // Update is called once per frame
    void Update()
    {
    }

    IEnumerator UpdateSavedDataPath()
    {
        float start_time = Time.time;
        while (true)
        {
           // Print the time of when the function is first called.

            //Debug.Log("Started Coroutine at timestamp : " + Time.time);

        
           

            PathNode current_node = new PathNode();


            //Vector3 pos = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);

            current_node.position = gameObject.transform.position;
            current_node.rotation = gameObject.transform.rotation;

            //public static Object Instantiate(Object original, Vector3 position, Quaternion rotation);

           

            current_node.time = Time.time - start_time;

            saved_data_temp.AddNodeToPath(current_node);

            //yield on a new YieldInstruction that waits for 5 seconds.
            yield return new WaitForSeconds(save_frequency);


        }
    }

    void OnRoundEnd()
    {

    }

    public CloneData GetCloneData()
    {
        saved_data_temp.round_to_reproduce = rm.GetCurrentRound();
        return saved_data_temp;
    }

    void OnRoundStart()
    {
        saved_data_temp.ResetPathList();
        saved_data_temp.ResetShotTimesList();
    }

}
