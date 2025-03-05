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
        //if (!agent.pathPending && agent.remainingDistance < 1.5f)

            if (Input.GetMouseButtonDown(0))  // 0 es el bot�n izquierdo del rat�n
        {


            //currentPointIndex = (currentPointIndex + 1) % points.Length;

            //agent.SetDestination(points[currentPointIndex].position);

            // Hacer un rayo desde la c�mara hacia el punto donde se hizo clic
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // Si el rayo toca el terreno u objeto con un collider (lo que sea en el escenario)
            if (Physics.Raycast(ray, out hit))
            {
                // Establecer la nueva posici�n de destino para el agente de navegaci�n
                agent.SetDestination(hit.point);
            }
        }
    }
}

