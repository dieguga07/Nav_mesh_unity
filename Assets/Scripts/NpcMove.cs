using UnityEngine;
using UnityEngine.AI;

public class NpcMove : MonoBehaviour
{
    public Transform[] points;
    private int currentPointIndex = 0;
    private NavMeshAgent agent;
    
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        
        if (!agent.pathPending && agent.remainingDistance < 1.5f)
        {
            currentPointIndex = (currentPointIndex + 1) % points.Length;
            agent.SetDestination(points[currentPointIndex].position);
        }
    }
}
