using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private GameObject InventoryInc;
    private GameObject MenuInc;
    private GameObject BuildAndDestroy;
    public static bool ShovelOk;
 void Start()
    {
       InventoryInc = GameObject.FindWithTag("InventoryInc");
       MenuInc = GameObject.FindWithTag("MenuInc");
       BuildAndDestroy = GameObject.FindWithTag("BuildDestroyMenu");
       InventoryInc.transform.localScale=new Vector2(0,0);
       MenuInc.transform.localScale=new Vector2(0,0);
       BuildAndDestroy.transform.localScale=new Vector2(0,0);
       ShovelOk=false;
    }
    
   public void  Play()
   {
       SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
        InventoryInc.transform.localScale=new Vector2(1,1);
         MenuInc.transform.localScale=new Vector2(1,1);
         BuildAndDestroy.transform.localScale=new Vector2(1,1);
         ShovelOk=true;
   }
     public void  NewPlay()
   {
       DataBase.ClearDataBase();
       SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
        InventoryInc.transform.localScale=new Vector2(1,1);
         MenuInc.transform.localScale=new Vector2(1,1);
         BuildAndDestroy.transform.localScale=new Vector2(1,1);
   }
   public void Exit()
   {
       Application.Quit();
   }
}
