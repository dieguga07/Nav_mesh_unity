using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour
{
    private NavMeshAgent agent; 
    private Animator animator;
    
    [SerializeField] private GameObject playerHand ;
    
    private bool hasWeapon = false;
    private Items playerWeapon;
    private GameObject handWeapon;
    
    public ChestScript chestScript;
    
    
    
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        //chestScript = FindObjectOfType<ChestScript>();   
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
            GetWeapon();
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
    
    private void GetWeapon()
    {
         playerWeapon = chestScript.selectedItem;
         Debug.Log(playerWeapon);
         
         if (!hasWeapon)
         {
             handWeapon = Instantiate(playerWeapon.weaponPrefab, playerHand.transform.position, playerHand.transform.rotation);
             handWeapon.transform.SetParent(playerHand.transform);
             hasWeapon  = true;
         }
         else
         {
             Destroy(handWeapon);
             handWeapon = Instantiate(playerWeapon.weaponPrefab, playerHand.transform.position, playerHand.transform.rotation);
             handWeapon.transform.SetParent(playerHand.transform);
         }
    
         chestScript.DestroyChestWeapon();
    }
    private void DestroyWeapon()
    {
        hasWeapon  = false;
        Destroy(handWeapon);
    }
    
}

