using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class Shop : MonoBehaviour
{
    private List<ShopItem> AllShopItem= new List<ShopItem>();
    private List<Item> AllProductItem= new List<Item>();
    private Text MoneyTxt;

    void Start()
    {
       MoneyTxt = GetComponentsInChildren<Text>()[0];
       MoneyTxt.text=Player.Money+"$";
       AllShopItem =gameObject.GetComponentsInChildren<ShopItem>().ToList();
       fillAllShop();
       StartCoroutine(fillShop());
    }
    
    private void fillAllShop()
    {
      AllProductItem.Clear();
      AllProductItem.Add(new Item("Сabbage","Item/Food/Сabbage/Сabbage",Item.TYPEFOOD,1,20,1,60f));
      AllProductItem.Add(new Item("Tomato","Item/Food/Tomato/Tomato",Item.TYPEFOOD,1,30,1,5f));
      AllProductItem.Add(new Item("Salat","Item/Food/Salat/Salat",Item.TYPEFOOD,1,40,1,55f));
      AllProductItem.Add(new Item("Pumpkin","Item/Food/Pumpkin/Pumpkin",Item.TYPEFOOD,1,50,2,95f));
    }
     private IEnumerator fillShop()
    {
       yield return new WaitForSeconds(0.3f);
       for(int i=0;i<AllShopItem.Count;i++)
       {
           AllShopItem[i].UpdateItem(AllProductItem[i],MoneyTxt);
       }
    }
}
