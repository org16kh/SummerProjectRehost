using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathBehavior : MonoBehaviour
{
    /// <summary>
    ///  All available paths to the AI
    /// </summary>
    public List<Path> paths;

    /// <summary>
    /// AI's starting path.
    /// </summary>
    public int currPath = 0;

    public float turnSpeed = 0.5f;

    public float patrolSpeed = 5f;

    // ===== PRIVATE VARIABLES ==== //
    /// <summary>
    /// 
    /// </summary>
    private GameObject currNode;

    /// <summary>
    /// 
    /// </summary>
    private Quaternion tarQuat;

    /// <summary>
    /// 
    /// </summary>
    private bool aimedAtTarget = false;

    private int currPosInPath = 0;

    private void Start()
    {
        // Temporary for us
        Path path = new Path
        {
            path = new GameObject[paths[currPath].path.Length]
        };

        // Get our initial node
        currNode = paths[currPath].path[0];
        
        // Go find the nearest node to go to
        for(int i = 0; i < paths[currPath].path.Length; i++)
        {
            if (Vector3.Distance(paths[currPath].path[i].transform.position, transform.position) <
                Vector3.Distance(currNode.transform.position, transform.position))
            {
                currNode = paths[currPath].path[i];
                currPosInPath = 0;
            }
        }
    }

    // Update is called once per frame
    private void Update()
    {
        if(aimedAtTarget == false)
        {
            // Look at the target
            if(transform.rotation.eulerAngles.y < 80f)
            {
                RotateToTarget();
            }
            else
            {
                transform.rotation = tarQuat;
                aimedAtTarget = true;
            }
        }
        else
        {
            // Go ahead and move
            transform.position = Vector3.MoveTowards(transform.position, currNode.transform.position,
                patrolSpeed * Time.deltaTime);
        }

        // Check if our pos == currNode pos
        if(currNode.transform.position == transform.position)
        {
            Debug.Log("here!");
        }

    }

    private void RotateToTarget()
    {
        tarQuat = Quaternion.LookRotation(currNode.transform.position - transform.position);
        float str = Mathf.Min(turnSpeed * Time.deltaTime, 1f);
        transform.rotation = Quaternion.Lerp(transform.rotation, tarQuat, str);
    }

}
