using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanIA : MonoBehaviour
{
    public UnityEngine.AI.NavMeshAgent agent;


    private List<Transform> nodes;
    private int currentNode = 0;

    public Transform path;


    private void Awake()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    // Start is called before the first frame update
    void Start()
    {
        Transform[] pathTransforms = path.GetComponentsInChildren<Transform>();
        nodes = new List<Transform>();

        for (int i = 0; i < pathTransforms.Length; i++)
        {
            if (pathTransforms[i] != path.transform)
            {
                nodes.Add(pathTransforms[i]);
            }
        }
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        Move();
        CheckWaypointDistance();
    }

    private void Move()
    {
        agent.SetDestination(nodes[currentNode].transform.position);
    }

    private void CheckWaypointDistance()
    {
        if (Vector3.Distance(transform.position, nodes[currentNode].position) < 5f)
        {
            if (currentNode == nodes.Count - 1)
            {
                currentNode = 0;
            }

            else
            {
                currentNode++;
            }
        }

    }
}
