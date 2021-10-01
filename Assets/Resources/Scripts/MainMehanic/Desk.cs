using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Desk : MonoBehaviour
{
    private GameObject player;
     private GameObject Inventory;
    private SpriteRenderer DeskRenderer;
    private bool AllowClick=false;

    void Start()
    {
        DeskRenderer = GetComponent<SpriteRenderer>();
        player = GameObject.FindWithTag("Player");
        Inventory = GameObject.FindWithTag("Inventory");
    }

    void Update()
    {
        
    }
     void  OnMouseDown()
    {
         //Inventory.GetComponent<Menu>().OpenDesk();
         
         var menu=Inventory.GetComponent<Menu>();
         if(!menu.OpenInventory && !menu.OpenDesk)
         {
             if (AllowClick)
        {
             menu.OpenDesks();
        }
         }
    }
    
    public void FixedUpdate()
    {
        
           if (Vector3.Distance(this.transform.position,player.transform.position)<0.7f )
            {
                DeskRenderer.sprite = Resources.Load<Sprite>("Object/plateSelected");
                AllowClick = true;
            }
            else
            {
                 AllowClick = false;
                DeskRenderer.sprite = Resources.Load<Sprite>("Object/plate");
               
            }
    }
}
