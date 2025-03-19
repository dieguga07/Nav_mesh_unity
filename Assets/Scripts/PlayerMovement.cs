using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour
{
    private NavMeshAgent agent; 
    private Animator animator;
    private bool hasWeapon = false;
    private GameObject playerWeapon;
    
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        float speed = agent.velocity.magnitude;
        
        if (Input.GetKeyDown(KeyCode.R))
        {
            DestroyWeapon(playerWeapon);
        }
        
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                agent.SetDestination(hit.point);
            }
        }
        
        if (speed <= 0f)
        {
            // animator.SetBool("stopped", agent.isStopped);
            animator.SetBool("stopped", true);
        }
        else
        {
            animator.SetBool("stopped", false);
        }
        
        
        
    }
    
    private void GetWeapon()
    {
        // if (!hasWeapon)
        // {
        //     handWeapon = Instantiate(chestWeapon, playerHand.position, playerHand.rotation);
        //     handWeapon.transform.SetParent(playerHand);
        //     hasWeapon  = true;
        // }
        // else
        // {
        //     Destroy(handWeapon);
        //     handWeapon = Instantiate(chestWeapon, playerHand.position, playerHand.rotation);
        //     handWeapon.transform.SetParent(playerHand);
        // }
        //
        // Destroy(chestWeapon);
    }
    private void DestroyWeapon(GameObject handWeapon)
    {
        hasWeapon  = false;
        Destroy(handWeapon);
    }
    
}

