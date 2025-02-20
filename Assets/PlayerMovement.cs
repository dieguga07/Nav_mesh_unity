using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour
{
    public Transform[] points;  // Puntos de destino
    private int currentPointIndex = 0;  // Índice del punto actual
    private NavMeshAgent agent;  // Componente NavMeshAgent

    void Start()
    {
        // Obtener el NavMeshAgent
        agent = GetComponent<NavMeshAgent>();

        // Mover al primer punto
        if (points.Length > 0)
        {
            agent.SetDestination(points[currentPointIndex].position);
        }
    }

    void Update()
    {
            // Verificar si el agente ha llegado al destino
        if (!agent.pathPending && agent.remainingDistance < 0.5f)
        {
            // Avanzar al siguiente punto
            currentPointIndex = (currentPointIndex + 1) % points.Length;

            // Establecer el destino al siguiente punto
            agent.SetDestination(points[currentPointIndex].position);
        }
    }
}
