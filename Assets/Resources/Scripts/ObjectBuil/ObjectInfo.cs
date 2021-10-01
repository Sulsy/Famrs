using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class ObjectInfo 
{
   public int id;
   public int step;
   public  float _positionx;
   public  float _positiony;
   public  string types;
   public Item CropStats;
 

   public ObjectInfo (int id, int step,float positionx,float positiony,string types)
   {
       this.id=id;
       this.step=step;
       this._positionx=positionx;
       this._positiony=positiony;
       this.types=types;
      
   }
}
