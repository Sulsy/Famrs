using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class ObjectManipulation : MonoBehaviour
{
   static public bool ObjectBuild;
     private GameObject Object;
     public GameObject build;
     public GameObject destroy;
     private GameObject BuildAndDestroy;
    void Start()
    {
         Build();
    }
    void Update()
    {
      Item item = Player.GetHandItem();
     BuildAndDestroy = GameObject.FindWithTag("BuildDestroyMenu");
     if(MainMenu.ShovelOk)
     {

     
     if(item.type == Item.TYPESHOVEl)
          {
           BuildAndDestroy.transform.localScale=new Vector2(1,1);
          }
          else
          {
          BuildAndDestroy.transform.localScale=new Vector2(0,0);
          }
     }
    }
   public void Build()
    {
        Item item = Player.GetHandItem();
        if(item.type == Item.TYPESHOVEl)
          {
 
            if(!ObjectBuild)
            {
                ObjectBuild=true;

               // Object.sprite = 
                Instantiate(build);
             
            }
            else
            {
                ObjectBuild=false;
                
              //  Object.sprite = Resources.Load<Image>("Canvas/Destroy");
                Instantiate(destroy);
              
            }
          }

        
    }
 
}
