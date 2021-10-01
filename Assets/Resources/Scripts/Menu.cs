using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public GameObject inventoryPrefab;
    public GameObject DeskPrefab;
    public GameObject ShopPrefab;
    public GameObject MenuPrefab;
    public GameObject BuildPrefab;

    public bool OpenInventory;
    public bool OpenDesk;
    public bool OpenShop;
    public bool OpenMenu;
    public bool OpenBuild;
     

    private GameObject Inventory;
    private GameObject Desk;
    private GameObject Shop;
    private GameObject MenuWindow;
    private GameObject Build;

    

    public void OpenInventorys()
    {
      if (OpenMenu)
      {
        OpenMenu=false;
        Destroy(MenuWindow);
      }
      else
      {
         if (OpenBuild)
         {
          if(!Controllers.Delet){Destroy(GameObject.FindWithTag("Build"));}
           else {Destroy(GameObject.FindWithTag("Destroy"));}
           Destroy(Build);
            Controllers.Delet=false;
           OpenBuild=false;
         }
         else
         {
             if(OpenDesk)
             {  
              Destroy(Desk);
              OpenDesk=false;
             }
            else
             {
               if(OpenShop)
               {
                Destroy(Shop);
                OpenShop=false;

               }
               else
               {
                 if(OpenInventory)
                 {
                  Destroy(Inventory);
                  OpenInventory = false;
                 }
                 else
                 {
                     Inventory = Instantiate(inventoryPrefab);
        Inventory.transform.SetParent(gameObject.transform);
        Inventory.GetComponent<RectTransform>().offsetMin = new Vector2(20, 40);
        Inventory.GetComponent<RectTransform>().offsetMax = new Vector2(-20, -70);
        Inventory.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
        OpenInventory = true; 
                 }
               }
             }
         }
      }                     
       
         
    }
     public void OpenDesks()
    {
      if (OpenMenu)
      {
        OpenMenu=false;
        Destroy(MenuWindow);
      }
      else
      {
         if (OpenBuild)
         {
           if(!Controllers.Delet){Destroy(GameObject.FindWithTag("Build"));}
           else {Destroy(GameObject.FindWithTag("Destroy"));}
           Destroy(Build);
            Controllers.Delet=false;
           OpenBuild=false;
         }
         else
         {
             if(OpenDesk)
             {  
              Destroy(Desk);
              OpenDesk=false;
             }
            else
             {
               if(OpenShop)
               {
                Destroy(Shop);
                OpenShop=false;

               }
               else
               {
                 if(OpenInventory)
                 {
                  Destroy(Inventory);
                  OpenInventory = false;
                 }
                 else
                 {
                   Desk = Instantiate(DeskPrefab);
      Desk.transform.SetParent(gameObject.transform);
      Desk.GetComponent<RectTransform>().offsetMin = new Vector2(60, 60);
      Desk.GetComponent<RectTransform>().offsetMax = new Vector2(-20, -70);
      Desk.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
      OpenDesk=true;
                 }
               }
             }
         }
      }                     
      
      
    }
    public void OpenShops()
    {
          if (OpenMenu)
      {
        OpenMenu=false;
        Destroy(MenuWindow);
      }
      else
      {
         if (OpenBuild)
         {
          if(!Controllers.Delet){Destroy(GameObject.FindWithTag("Build"));}
           else {Destroy(GameObject.FindWithTag("Destroy"));}
           Destroy(Build);
            Controllers.Delet=false;
           OpenBuild=false;
         }
         else
         {
             if(OpenDesk)
             {  
              Destroy(Desk);
              OpenDesk=false;
             }
            else
             {
               if(OpenShop)
               {
                Destroy(Shop);
                OpenShop=false;

               }
               else
               {
                 if(OpenInventory)
                 {
                  Destroy(Inventory);
                  OpenInventory = false;
                 }
                 else
                 {
                    Shop = Instantiate(ShopPrefab);
      Shop.transform.SetParent(gameObject.transform);
      Shop.GetComponent<RectTransform>().offsetMin = new Vector2(60, 60);
      Shop.GetComponent<RectTransform>().offsetMax = new Vector2(-20, -70);
      Shop.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
      OpenShop=true;
                 }
               }
             }
         }
      }                     
     
      
    }
    public void OpenMenus()
    {
      if (OpenMenu)
      {
        OpenMenu=false;
        Destroy(MenuWindow);
      }
      else
      {
         if (OpenBuild)
         {
          if(!Controllers.Delet){Destroy(GameObject.FindWithTag("Build"));}
           else {Destroy(GameObject.FindWithTag("Destroy"));}
           Destroy(Build);
            Controllers.Delet=false;
           OpenBuild=false;
         }
         else
         {
             if(OpenDesk)
             {  
              Destroy(Desk);
              OpenDesk=false;
             }
            else
             {
               if(OpenShop)
               {
                Destroy(Shop);
                OpenShop=false;

               }
               else
               {
                 if(OpenInventory)
                 {
                  Destroy(Inventory);
                  OpenInventory = false;
                 }
                 else
                 {
                    MenuWindow = Instantiate(MenuPrefab);
                    MenuWindow.transform.SetParent(gameObject.transform);
                    MenuWindow.GetComponent<RectTransform>().offsetMin = new Vector2(60, 60);
                    MenuWindow.GetComponent<RectTransform>().offsetMax = new Vector2(-20, -70);
                    MenuWindow.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
                    OpenMenu=true;  
                 }
               }
             }
         }
      }                     
    }
   void OpenBuilds()
    {
        if (OpenMenu)
      {
        OpenMenu=false;
        Destroy(MenuWindow);
      }
      else
      {
         if (OpenBuild)
         {
           if(!Controllers.Delet){Destroy(GameObject.FindWithTag("Build"));}
           else {Destroy(GameObject.FindWithTag("Destroy"));}
           Controllers.Delet=false;
           Destroy(Build);
           OpenBuild=false;
         }
         else
         {
             if(OpenDesk)
             {  
              Destroy(Desk);
              OpenDesk=false;
             }
            else
             {
               if(OpenShop)
               {
                Destroy(Shop);
                OpenShop=false;

               }
               else
               {
                 if(OpenInventory)
                 {
                  Destroy(Inventory);
                  OpenInventory = false;
                 }
                 else
                 {
                    Build = Instantiate(BuildPrefab);
                    Build.transform.SetParent(gameObject.transform);
                    Build.GetComponent<RectTransform>().offsetMin = new Vector2(60, 60);
                    Build.GetComponent<RectTransform>().offsetMax = new Vector2(-20, -70);
                    Build.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
                    OpenBuild=true; 
                 }
               }
             }
         }
      }                     
                   
                   
               
    
    }
}

  /* public void generateMission(int id)
    {// {1}15{2}310{3}600 -9
     //350 250
     int x=295;
     int Xreal=15;
     switch(id)
     {
         case 2:
         Xreal+=x;
         break;
         case 3:
         Xreal+=(2*x);
         break;
         default:
         break;
     }
      Mission = Instantiate(MiisionPrefab);
      Mission.transform.SetParent(gameObject.transform);
      Mission.GetComponent<RectTransform>().offsetMin = new Vector2(Xreal, 60);
      Mission.GetComponent<RectTransform>().offsetMax = new Vector2(-20, -70);
      Mission.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
      OpenShop=true;
    }*/

