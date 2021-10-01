using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
public class Order : MonoBehaviour
{

    List<Image> ProductImage;
    List<Text> ProductText;
    List<Item> AllItemsList=new List<Item>();
    List<Item> Required=new List<Item>();

    private Text reward;
    private int MoneyToRecive;
    private int ExpToRecive;
        public int id;
    void Start()
    {
        reward=GetComponentsInChildren<Text>().ToList()[0];
        ProductImage=GetComponentsInChildren<Image>().ToList();
        ProductText=GetComponentsInChildren<Text>().ToList();

        GetComponentInChildren<Button>().onClick.AddListener(delegate { completeOrder(); });
   if(Player.lvl>0)AllItemsList.Add(new Item("Сabbage","Item/Food/Сabbage/Сabbage",Item.TYPEFOOD,1,10,1,2f));
   if(Player.lvl>0) AllItemsList.Add(new Item("Tomato","Item/Food/Tomato/Tomato",Item.TYPEFOOD,1,10,1,1f));
   if(Player.lvl>0) AllItemsList.Add(new Item("Salat","Item/Food/Salat/Salat",Item.TYPEFOOD,1,10,1,3f));
   if(Player.lvl>2) AllItemsList.Add(new Item("Pumpkin","Item/Food/Pumpkin/Pumpkin",Item.TYPEFOOD,1,50,2,1f));

        CreatOrder();
    }

    private void CreatItemOfOrder()
    {
      int productIndex=Random.Range(0,AllItemsList.Count);
      Item product = AllItemsList[productIndex];

      product.count=generateAmount();

      AllItemsList.Remove(product);
      Required.Add(product);
    }

    private void CreatOrder()
    {
      if(Player.CurentOrders[id].Count==0)
      {
          for(int i=0;i<generateCount();i++)
          {
              CreatItemOfOrder();
          }
      }
      else Required =Player.CurentOrders[id];


      for(int i=0;i<Required.Count;i++)
      {
          ProductImage[i+1].sprite=Resources.Load<Sprite>(Required[i].imgUrl);
           ProductText[i+2].text="x"+Required[i].count.ToString();
      }
      generateReward();
      Player.CurentOrders[id]=Required;
    }

    private void completeOrder()
    {
        if(Player.MiisionItemCheck(Required))
        {
            for(int i=0;i<Required.Count;i++)
            {
                Player.RemovItemOrMission(Required[i].name,Required[i].count);
            }
            Player.addExp(1);
            Player.Money += MoneyToRecive;
            Player.CurentOrders[id].Clear();
            DataBase.Save();
            Destroy(gameObject);
        }
        
    }
     private void generateReward()
    {
        switch(Player.lvl)
        {
            case 1:
            MoneyToRecive=Random.Range(6,15);
            ExpToRecive=Random.Range(1,3);

            break;
            case 2:
            MoneyToRecive=Random.Range(10,21);
            ExpToRecive=Random.Range(1,5);
            break;
            default:
            MoneyToRecive=Random.Range(20,35);
            ExpToRecive=Random.Range(4,8);
            break;
        }
        reward.text=$"You will recive {ExpToRecive} exp and {MoneyToRecive}$";
    }
     private int generateCount()
    {
        if (Player.lvl == 1) return 2;
        if (Player.lvl == 2 ) return 3;//Random.Range(2, 3);
        //if (Player.lvl == 3) return 3;

        return 3;
    }

    private int generateAmount()
    {
        if (Player.lvl < 4) return Random.Range(1, 3);
        if (Player.lvl >= 4) return Random.Range(2, 5);

        return 4;
    }

}
