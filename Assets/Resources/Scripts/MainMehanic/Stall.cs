using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stall : MonoBehaviour
{
    private GameObject player;
    private GameObject Inventory;
    private SpriteRenderer ShopRenderer;
    private bool AllowClick=false;

    void Start()
    {
        ShopRenderer = GetComponent<SpriteRenderer>();
        player = GameObject.FindWithTag("Player");
        Inventory = GameObject.FindWithTag("Inventory");
    }

    void  OnMouseDown()
    {
        if (AllowClick)
        {
            var menu=Inventory.GetComponent<Menu>();
        menu.OpenShops();
        }
        
    }
    
    public void FixedUpdate()
    {
        
           if (Vector3.Distance(this.transform.position,player.transform.position)<0.7f )
            {
                ShopRenderer.sprite = Resources.Load<Sprite>("Object/plateSelected");
                AllowClick = true;
            }
            else
            {
                 AllowClick = false;
                ShopRenderer.sprite = Resources.Load<Sprite>("Object/plate");
               
            }
    }
    void Update()
    {
        
    }
}