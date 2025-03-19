using System.Collections.Generic;
using UnityEngine;
public class ChestScript : MonoBehaviour
{
    [SerializeField] private ItemList itemList;
    [SerializeField] private RaretyList raretyList;
    
    
    private bool onRange = false;
    private GameObject chestWeapon;
    private Transform playerHand;
    private GameObject player;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.Find("Player");
        raretyList.rarety.Sort((a, b) => b.baseProbability.CompareTo(a.baseProbability));
        playerHand = player.transform.Find("Hand");
    }

    // Update is called once per frame
    void Update()
    {
        if ( onRange && Input.GetKeyDown(KeyCode.E) )
        {
            OpenChest();
        }
        
        if ( onRange && Input.GetKeyDown(KeyCode.F) )
        {
            // GetWeapon();
            // player.GetWeapon();
        }
        
    }

    private void OpenChest()
    {
        
        float probabilityNum = Random.Range(1, 101);
        // Debug.Log(probability_num);
        
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
        
       
        Items selectedItem = filteredItems[Random.Range(0, filteredItems.Count)];
        
        Vector3 spawnPosition = new Vector3(1.843f, 1f, -0.594f);
        
        Destroy(chestWeapon);
        
        chestWeapon = Instantiate(selectedItem.weaponPrefab, spawnPosition, Quaternion.identity);
        
        
    }
    
    private void OnTriggerEnter(Collider other)
    {
        onRange = true;
        Debug.Log(other.gameObject.name + " can open chest");
    }

    private void OnTriggerExit(Collider other)
    {
        onRange = false;
        Debug.Log(other.gameObject.name + " can't open chest");
    }
}
