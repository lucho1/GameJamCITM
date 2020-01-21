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
    List<PathNode> path;

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
        return path[i];
    }

    
}

public class PlayerDataController : MonoBehaviour
{
    public float save_frequency;

    public CloneData saved_data_temp;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(UpdateSavedDataPath());
        saved_data_temp = new CloneData();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            gameObject.transform.SetPositionAndRotation(gameObject.transform.position + new Vector3(0, 0, 1), gameObject.transform.rotation);
        }

    }

    IEnumerator UpdateSavedDataPath()
    {
        float start_time = Time.time;
        while (true)
        {
            //Print the time of when the function is first called.
            //Debug.Log("Started Coroutine at timestamp : " + Time.time);

            //yield on a new YieldInstruction that waits for 5 seconds.
            yield return new WaitForSeconds(save_frequency);

            PathNode current_node = new PathNode();

            Vector3 pos = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);

            current_node.position = pos;
            current_node.rotation = gameObject.transform.rotation;
            
            current_node.time = Time.time - start_time;           

            saved_data_temp.AddNodeToPath(current_node);
        }
    }
}
