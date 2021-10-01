using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class Inventory : MonoBehaviour
{
   private List<Slot> ListSlot=new List<Slot>();
   public static Slot selectedSlot=null;

   private Text lvlText;
   private Text Money;
   private RectTransform BarProgres;

    void Start()
    {
    
    lvlText=GetComponentsInChildren<Text>()[0];
    Money=GetComponentsInChildren<Text>()[1];
    Money.text+=Player.Money+"$";
    BarProgres=GetComponentsInChildren<Image>()[3].GetComponent<RectTransform>();

    BarProgres.localScale=new Vector3(Player.ProgresLvl,1,1);
    lvlText.text="LVL"+Player.lvl;

    ListSlot = GetComponentsInChildren<Slot>().ToList();
    int i=0;
    foreach(Slot SlotForeach in ListSlot)
    {
        SlotForeach.fillSlot(i);
        i++;
    }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
