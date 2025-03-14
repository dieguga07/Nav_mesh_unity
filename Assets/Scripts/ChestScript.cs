using System;
using UnityEngine;

public class ChestScript : MonoBehaviour
{
    [SerializeField] private ItemList itemList;
    [SerializeField] private RaretyList raretyList;
    
    
    private bool onRange = false;
    
    
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
     
        
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
       Debug.Log("Opening Chest" + itemList.items[0].name);
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
