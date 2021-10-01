using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using System.Linq;

public class DataBase 
{
 public static string inventoryPath = Application.persistentDataPath+"/inventory.path";
 public static string playerInfoPath = Application.persistentDataPath+"/playerData.path";
 public static string ObjectInfoPath = Application.persistentDataPath+"/objectInfo.path";
 public static string ObjectInasfoPath = Application.persistentDataPath+"/objecasdtInfo.path";
 private static BinaryFormatter BinaryFormatter=new BinaryFormatter();
 public  static bool conservation_exists;
 private static  GameObject player;
 public static long difference;
 public static bool Clear;
 



 public static void Save()
 {
     SavePlayerInfo();
     SaveInventory();
     SaveObjectInfo();

 }
 
 public static void SaveObjectInfo()
 {
    FileStream stream =new FileStream(ObjectInfoPath,FileMode.Create); 
    BinaryFormatter.Serialize(stream,Builder.ObjectSave);
    stream.Close();
 }
 public static void SaveInventory()
 {
    FileStream stream =new FileStream(inventoryPath,FileMode.Create); 
    BinaryFormatter.Serialize(stream,Player.ListItems);
    stream.Close();
 }
 
 public static void SavePlayerInfo()
 {
     player = GameObject.FindWithTag("Player");
    FileStream stream =new FileStream(playerInfoPath,FileMode.Create); 
    string currentTime =System.DateTime.Now.ToBinary().ToString();
    PlayerInfo playerInfo =new PlayerInfo(Player.Money,Player.lvl,Player.ProgresLvl,true,player.transform.position.x,player.transform.position.y,currentTime);
    BinaryFormatter.Serialize(stream,playerInfo);
    stream.Close();
    currentTime=null;
 }
 
 public static List<Item> LoadInventory()
 {
    if(File.Exists(inventoryPath))
    {
        FileStream stream = new FileStream(inventoryPath,FileMode.Open);
        List<Item> ListItems=(List<Item>)BinaryFormatter.Deserialize(stream);
        stream.Close();
        return ListItems;
    }
    else
    {
        List<Item> startItems=new List<Item>();
      startItems.Add(new Item("Plow","Item/Tools/Plow",Item.TYPEPLOW,0,10,0,0.0f,1f));
      startItems.Add(new Item("Shovel","Item/Tools/Shovel",Item.TYPESHOVEl,0,10,0,0.0f));
      startItems.Add(Player.GetEmptyItem());
      startItems.Add(Player.GetEmptyItem());
      startItems.Add(Player.GetEmptyItem());
      startItems.Add(Player.GetEmptyItem());
      startItems.Add(Player.GetEmptyItem());
      startItems.Add(Player.GetEmptyItem());
      startItems.Add(Player.GetEmptyItem());
      startItems.Add(Player.GetEmptyItem());
      startItems.Add(Player.GetEmptyItem());
      startItems.Add(Player.GetEmptyItem());
      startItems.Add(Player.GetEmptyItem());
      return startItems;
    }
 }
  public static PlayerInfo LoadPlayerInfo()
 {
     if(File.Exists(playerInfoPath))
    {
       
        FileStream stream = new FileStream(playerInfoPath,FileMode.Open);
       PlayerInfo playerInfo=(PlayerInfo)BinaryFormatter.Deserialize(stream);
        stream.Close();
    //    playerInfo.timeOffline=getOfflineTime(playerInfo.lastSaveTime);
    difference=getOfflineTime(playerInfo.lastSaveTime);
       Debug.Log("Time"+$"{difference=getOfflineTime(playerInfo.lastSaveTime)}");
        return playerInfo;
    }
    else return new PlayerInfo(100,1,0f,false,1f,1f,"");
   

 }
 public static List<ObjectInfo> LoadObjectInfo()
 {
      Builder.ObjectSave.Clear();
     if(File.Exists(ObjectInfoPath))
    {
       
        FileStream stream = new FileStream(ObjectInfoPath,FileMode.Open);
       List<ObjectInfo> ObjectListLoad=(List<ObjectInfo>)BinaryFormatter.Deserialize(stream);
        stream.Close();
        return ObjectListLoad;
    }
    else 
    {
         List<ObjectInfo> ObjectListLoad=new List<ObjectInfo>();
        return ObjectListLoad;
    }
   

 }
 public static void ClearDataBase()
 {  
      Builder.ObjectSave.Clear();
      Builder.Id=0; 
      Builder.IndexOut.Clear();
      if(File.Exists(ObjectInfoPath)){File.Delete(ObjectInfoPath);}
     if(File.Exists(inventoryPath)){File.Delete(inventoryPath);}
     if(File.Exists(playerInfoPath)){File.Delete(playerInfoPath);}
     Clear=true;
     Builder.olds=0;
 }
 private static long  getOfflineTime(string lastSaveTime)
 {
     var currentTime=System.DateTime.Now;
     var lastSaveTimeConvert=System.Convert.ToInt64(lastSaveTime);
    System.DateTime oldTime= System.DateTime.FromBinary(lastSaveTimeConvert);
    System.TimeSpan difference=currentTime.Subtract(oldTime);
    Debug.Log("Старое"+$"{oldTime}");
      Debug.Log("РАЗНИЦА"+$"{difference}");
       Debug.Log("щяс"+$"{currentTime}");
    return (long)difference.TotalSeconds;
 }

 
}
