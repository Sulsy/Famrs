using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

   public static List<Item> ListItems=new List<Item>();
   public static  int lvl;
   public static float ProgresLvl;
   public const int MaxLvL=7;
   public static float [] ExpHardGive=new  float[MaxLvL];
   public static List<List<Item>> CurentOrders=new  List<List<Item>>();
   public static List<Crop> CropList=new  List<Crop>();
   public static int Money;
   public static int lvlstep;
   public static int NevLvl;
   public static float positionx;
   public static float positiony;
 public static PlayerInfo playerInfo;

  
    void Start()
    {

        //DataBase.ClearDataBase();
        PlayerInfo playerInfo = DataBase.LoadPlayerInfo();
        Money = playerInfo.Money;
        ProgresLvl = playerInfo.LvlProgress;
        lvl = playerInfo.lvl;
        positionx= playerInfo._positionx;
        positiony= playerInfo._positiony;
        ObjectGeneric.timeOffline=playerInfo.timeOffline;

        this.transform.position=new Vector2(positionx,positiony);
        lvlstep=playerInfo.lvl;
        
        CurentOrders.Add(new List<Item>());
        CurentOrders.Add(new List<Item>());
        CurentOrders.Add(new List<Item>());
     
      ListItems=DataBase.LoadInventory();
      ExpHardGive[1]=0.04f;
      ExpHardGive[2]=0.03f;
      ExpHardGive[3]=0.03f;
      ExpHardGive[4]=0.02f;
      ExpHardGive[5]=0.02f;
      ExpHardGive[6]=0.01f;


      

    }
  void Update()
    {
    }
    public static  void addExp(int exp)
    {
        ProgresLvl+=exp*ExpHardGive[lvl];
        if(ProgresLvl>=1)
        {
            lvlstep=lvl;
            lvl++;
            ProgresLvl=0;
           
     
        }
       
        
    }
   
  public static Item GetHandItem()
  {
      return new Item(ListItems[0].name,ListItems[0].imgUrl,ListItems[0].type,ListItems[0].count,ListItems[0].price,ListItems[0].LvL,ListItems[0].timeGrow);
  }
   public static Item GetEmptyItem()
  {
      return new Item("","Canvas/empty",0,0,0,0,0);
  }
  public static void RemovItem()
  {
      if(Player.ListItems[0].count==1)
      {
       Player.ListItems[0]=GetEmptyItem();
      }
      else
      {
          Player.ListItems[0].count-=1;
      }
        DataBase.Save();
  }
   public static void CheckItem(Item item)
   {
       bool exit=false;
       for(int i=0;i<ListItems.Count;i++)
       {
           if(item.name==ListItems[i].name)
           {
           ListItems[i].count+=item.count;
           exit=true;
           break;
           }
       }
       if(!exit)
       {
        AddItemToInventory(item);
       }
         DataBase.Save();
   }

  public static void AddItemToInventory(Item item)
   {
       bool added=false;
       for(int i=0;i<ListItems.Count;i++)
       {
           if(ListItems[i].name=="")
           {
           ListItems[i]=item;
           added=true;
           break;
           }
       }
       if(!added)
       {
      ListItems.Add(item);
       }
         DataBase.Save();
   }

   public static bool MiisionItemCheck(List<Item> req)
   {
      int itemsComplete=req.Count;

        
       for(int i=0;i<req.Count;i++)
       {
           foreach(Item item in ListItems)
        {
            if(item.name==req[i].name)
           {
           if(item.count>=req[i].count)
           {
           itemsComplete--;
           }
           }
        }
       }
       if(itemsComplete==0)
       {
           return true;
       }
       else
       {
           return false;
       }
        
   }
      
   
    public static void RemovItemOrMission(string name,int count)
   {
       for (int i = 0; i < ListItems.Count; i++)
        {
            if (ListItems[i].name == name)
            {
                if (ListItems[i].count <= count)
                {
                    ListItems[i] = GetEmptyItem();
                } else
                {
                    ListItems[i].count -= count;
                }
            }
        }
       
       DataBase.Save();
   }
   void OnApplicationQuit()
   {
    //Crop crop=new Crop();
    //crop.Save();
    
        DataBase.Save();
          // DataBase.SaveCropInfo();
          DataBase.difference=0;
          Builder.Id=0; 
          Builder.ObjectSave.Clear();
          Builder.IndexOut.Clear();
          Builder.olds=0;
          Debug.Log(Builder.ObjectSave.Count);
   }
}
