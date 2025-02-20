using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour
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
            // Verificar si el agente ha llegado al destino
        if (!agent.pathPending && agent.remainingDistance < 1.5f)
        {
            // Avanzar al siguiente punto
            currentPointIndex = (currentPointIndex + 1) % points.Length;

            // Establecer el destino al siguiente punto
            agent.SetDestination(points[currentPointIndex].position);
        }
    }
}
