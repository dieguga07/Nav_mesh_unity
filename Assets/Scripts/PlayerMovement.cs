using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour
{
    private NavMeshAgent agent; 
    private Animator animator;
    
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        float speed = agent.velocity.magnitude;
        
        if (Input.GetMouseButtonDown(0))
        {
            
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            animator.SetFloat("speed", speed);
            if (Physics.Raycast(ray, out hit))
            {
               
                agent.SetDestination(hit.point);
            }
        }
        
        if (speed <= 0f)
        {
            animator.SetFloat("speed", 0f);
        }
    }
}

