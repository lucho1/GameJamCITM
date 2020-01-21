using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct PathNode
{

    public Vector3 position;
    public Quaternion rotation;
    public float time;
}

public class CloneData
{
    public List<PathNode> path;

    public int round_to_reproduce;

    public CloneData()
    {
        path = new List<PathNode>();
    }

    public void AddNodeToPath(PathNode n)
    {
        path.Add(n);
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
}

public class PlayerDataController : MonoBehaviour
{
    public float save_frequency;

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

            Debug.Log("Started Coroutine at timestamp : " + Time.time);

        
           

            PathNode current_node = new PathNode();


            //Vector3 pos = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);

            current_node.position = gameObject.transform.position;
            current_node.rotation = gameObject.transform.rotation;

            current_node.time = Time.time - start_time;

            saved_data_temp.AddNodeToPath(current_node);

            //yield on a new YieldInstruction that waits for 5 seconds.
            yield return new WaitForSeconds(save_frequency);

            saved_data_temp.AddNodeToPath(current_node);


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
    }

}
