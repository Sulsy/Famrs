using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotBuild : MonoBehaviour
{
   public static int  i;
   public GameObject Builder;
   
  public void Desk()
   {i=1;
       if(!GameObject.Find("Build"));
   }
   public void Crop()
   {
     if(GameObject.Find("Build"))i=0;
       else Controllers.ObjectBuild=true;
   }
}
