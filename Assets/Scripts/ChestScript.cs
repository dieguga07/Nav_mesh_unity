using System.Collections.Generic;
using UnityEngine;
public class ChestScript : MonoBehaviour
{
    [SerializeField] private ItemList itemList;
    [SerializeField] private RaretyList raretyList;
    
    
    private bool onRange = false;
    
    
    
    
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

    void OpenChest()
    {
        
        float probability_num = Random.Range(1, 101);
        Debug.Log(probability_num);
        
        Rarety rarety_selected = null;
        float accumulatedProbability = 0f;
        
        foreach (var rarety in raretyList.rarety)
        {
            accumulatedProbability += rarety.baseProbability;
            
            if (probability_num <= accumulatedProbability)
            { 
                rarety_selected = rarety;
                break; 
            }
        }
        
        List<Items> filteredItems = new List<Items>();
        // List<Item> itemsFiltrados = new List<Item>();

        foreach (var item in itemList.items)
        {
            if(item.rarety == rarety_selected)
            { 
                filteredItems.Add(item);
            }
        }

        Items selectedItem = filteredItems[Random.Range(0, filteredItems.Count)];
        
        
        Debug.Log("Opening Chest... " + selectedItem.name);
        
        Vector3 spawnPosition = new Vector3(-0.455f, 1, 0.728f);
        Instantiate(selectedItem.weaponPrefab, spawnPosition, Quaternion.identity);

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
