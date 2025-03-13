using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour
{
    private NavMeshAgent agent; 

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
  
        if (Input.GetMouseButtonDown(0))  // 0 es el bot�n izquierdo del rat�n
        {
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

