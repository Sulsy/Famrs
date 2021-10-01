using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ObjectGeneric : MonoBehaviour
{
    public GameObject ObjectCropPrefab;
    private GameObject ObjectCrop;
    public GameObject ObjectDeskPrefab;
    public  List<ObjectInfo> CropData=new  List<ObjectInfo>();
    private GameObject ObjectDesk;
    private List<ObjectInfo> ObjectLoad;
     private List<Item> CropStats;
    private ObjectInfo Loads;
    public static int id;
    public static long timeOffline;
    private Crop crop;
    
    void Start()
    {
          if(File.Exists(DataBase.ObjectInfoPath))
    {
         ObjectLoad=DataBase.LoadObjectInfo();
         foreach(ObjectInfo coord in ObjectLoad )
         {
             Debug.Log($"{coord._positionx}"+$"{coord._positiony}");
            // Crop.step=coord.step;
              
              Creat(coord);
           
         }
     //   CropLoaded();
          
    }
    }
    void Creat(ObjectInfo coord)
    {
        
           switch(coord.types)
        {
          case "Desk": ObjectDesk=Instantiate(ObjectDeskPrefab);
           ObjectDesk.transform.position=new Vector2(coord._positionx,coord._positiony);
          break;
          case "Crop":  ObjectCrop=Instantiate(ObjectCropPrefab);
             //Crop crop =new Crop();
            // crop.objectInfo=coord;
            // Player.CropList.Add(crop);
         
           ObjectCrop.transform.position=new Vector2(coord._positionx,coord._positiony);
          break;
        }
       
            Builder.ObjectSave.Add(coord);
            Builder.Id=coord.id+1;
          //  if(coord.id>Builder.Id){Builder.Id=coord.id+2;}
    }

   void CropLoaded()
   {
  //  var CropList=DataBase.LoadCrop();
       // for (int i = 0; i < CropList.Count; i++)
        //{
         //    CropList[i].CropProgress(timeOffline,CropList[i].objectInfo.CropStats);
       // }
    }
   
}
