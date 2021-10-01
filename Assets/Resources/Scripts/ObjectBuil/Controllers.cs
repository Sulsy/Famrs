using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controllers : MonoBehaviour
{
    public static bool ObjectBuild=true;
    public static bool Delet;
    public  GameObject BuildPrefab;
    public  GameObject RemovePrefab;
    private  GameObject Build;
    private  GameObject Remove;
    public static string  itemsObject;
   public  void Button()
    {
     
      if(ObjectBuild)
        {
            ObjectBuild=true;
            Delet=true;
      Remove=Instantiate(RemovePrefab);
      Remove.transform.position=  this.transform.position;
      Destroy(Build);
            
        }
        else
        {
            ObjectBuild=false;
             Delet=false;
     // Build=Instantiate(BuildPrefab);
     // Build.transform.position=  this.transform.position;
     Destroy(Remove);
      
        }
    }
    public void Check()
    {
       if(!GameObject.Find("Build")) Build=Instantiate(BuildPrefab);
        Destroy(Remove);
    }
   public void Desk()
   {
     itemsObject="Desk";
   }
   public void Crop()
   {
     itemsObject="Crop";
   }
   public void House()
   {
     itemsObject="House";
   }




  
}
