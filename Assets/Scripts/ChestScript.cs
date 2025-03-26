using System.Collections.Generic;
using UnityEngine;
public class ChestScript : MonoBehaviour
{
    [SerializeField] private ItemList itemList;
    [SerializeField] private RaretyList raretyList;
    
    
    private bool onRange = false;
    public GameObject chestWeapon;
    public Items selectedItem;
  
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        raretyList.rarety.Sort((a, b) => b.baseProbability.CompareTo(a.baseProbability));
        
    }

    // Update is called once per frame
    void Update()
    {
        if ( onRange && Input.GetKeyDown(KeyCode.E) )
        {
            OpenChest();
        }
        
        
        
    }

    private void OpenChest()
    {
        
        float probabilityNum = Random.Range(1, 101);
        
        Rarety raretySelected = null;
        float accumulatedProbability = 0f;
        
        foreach (var rarety in raretyList.rarety)
        {
            accumulatedProbability += rarety.baseProbability;
            
            if (probabilityNum <= accumulatedProbability)
            { 
                raretySelected = rarety;
                break; 
            }
        }
        
        List<Items> filteredItems = new List<Items>();
        
        foreach (var item in itemList.items)
        {
            if(item.rarety == raretySelected)
            { 
                filteredItems.Add(item);
            }
        }
       
        selectedItem = filteredItems[Random.Range(0, filteredItems.Count)];
        
        Vector3 spawnPosition = new Vector3(1.843f, 1f, -0.594f);

        DestroyChestWeapon();
        
        chestWeapon = Instantiate(selectedItem.weaponPrefab, spawnPosition, Quaternion.identity);
        
        Debug.Log(chestWeapon.gameObject);
    }


    public void DestroyChestWeapon()
    {
        Destroy(chestWeapon);
    }
    
    private void OnTriggerEnter(Collider other)
    {
        onRange = true;
        Debug.Log(other.gameObject.name + " can open chest");
        var playerScript = other.gameObject.GetComponent<PlayerMovement>();
        if (playerScript != null)
        {
            playerScript.chestScript = this;
            Debug.Log("player opens: " + playerScript.chestScript.gameObject.name);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        onRange = false;
        Debug.Log(other.gameObject.name + " can't open chest");
    }
}
