using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour
{
    private NavMeshAgent agent; 
    private Animator animator;
    
    [SerializeField] private Transform playerHand ;
    
    private bool hasWeapon = false;
    private GameObject playerWeapon;
    private GameObject handWeapon;
    private ChestScript chestScript;
    
    
    
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        
    }

    void Update()
    {
        float speed = agent.velocity.magnitude;
        
        if (Input.GetKeyDown(KeyCode.F))
        {
            DestroyWeapon();
        }

        if (Input.GetKey(KeyCode.R))
        {
            
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
            animator.SetBool("stopped", true);
        }
        else
        {
            animator.SetBool("stopped", false);
        }
        
        
        
    }
    
    // private void GetWeapon()
    // {
    //     chestScript.chestWeapon = playerWeapon;
    //     if (!hasWeapon)
    //     {
    //         
    //         handWeapon = Instantiate(playerWeapon, playerHand.position, playerHand.rotation);
    //         handWeapon.transform.SetParent(playerHand);
    //         hasWeapon  = true;
    //     }
    //     else
    //     {
    //         Destroy(handWeapon);
    //         handWeapon = Instantiate(newWeapon, playerHand.position, playerHand.rotation);
    //         handWeapon.transform.SetParent(playerHand);
    //     }
    //
    //     chestScript.DestroyChestWeapon();
    // }
    private void DestroyWeapon()
    {
        hasWeapon  = false;
        Destroy(handWeapon);
    }
    
}

