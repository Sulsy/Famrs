 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public class Builder : MonoBehaviour
{
   
public static bool ReadyBuild;
private GameObject player;
private GameObject target;
 public GameObject CropPrefab;
 public GameObject DeskPrefab;
 public GameObject HousePrefab;
 private GameObject Crop;
 public static int Id;
 public static float x;
 public static float y;
  public static List<ObjectInfo> ObjectSave=new  List<ObjectInfo>();
  public static List<Int32> IndexOut=new List<Int32>();
  public static int olds;

    public static ObjectInfo ReturnElement(int id)
    {
      return new ObjectInfo(ObjectSave[id].id,ObjectSave[id].step,ObjectSave[id]._positionx,ObjectSave[id]._positiony,ObjectSave[id].types);
    }
    public void Swith()
    {
        switch(Controllers.itemsObject)
        {
          case "Desk":Crop=Instantiate(DeskPrefab);
          break;
          case "Crop": Crop=Instantiate(CropPrefab);
          break;
          case "House": Crop=Instantiate(HousePrefab);
          break;
        }
    }

    void Start()
    {
        player = GameObject.FindWithTag("Player");
        
      //  if(ObjectGeneric.id>=Id){Id=(ObjectGeneric.id)+1;}
    }

    // Update is called once per frame
    void Update()
    {   
      switch(Controllers.itemsObject)
        {
          case "Desk":
            this.GetComponent<BoxCollider2D>().size=DeskPrefab.GetComponent<BoxCollider2D>().size;
          break;
          case "Crop":
            this.GetComponent<BoxCollider2D>().size=CropPrefab.GetComponent<BoxCollider2D>().size;
          break;
          case "House": 
            this.GetComponent<BoxCollider2D>().size=HousePrefab.GetComponent<BoxCollider2D>().size;
          break;
        }
       target=gameObject;
        RaycastHit hit;
   var p = Camera.main.ScreenToWorldPoint(Input.mousePosition);
var hit2D = Physics2D.Raycast(p, Vector2.zero); 
        if (hit2D.transform != null&&(hit2D.transform.name !="ObjectBuild 1(Clone)"||hit2D.transform.gameObject.tag=="Object"))
        {
          Destroy(gameObject);
         Debug.Log(hit2D.transform.name);
        }
        this.transform.localScale = new Vector3(1, 1, 1);
          RoundCoordinate();
    }
    void OnMouseDown()
    {      
       foreach(var anus in ObjectSave)
        {
          if(new Vector3(anus._positionx,anus._positiony,0)== this.transform.position)
          {
                  Debug.Log($"as{anus._positionx},{anus._positiony}");
                        Debug.Log($"sa{this.transform.position.x}{this.transform.position.y}");
                        ReadyBuild=true;
          }
          else ReadyBuild=false;
        }
       if(Vector3.Distance(new Vector3(x,y),player.transform.position)<2f&&!ReadyBuild)
      {
        Swith();
        
        if(olds>0)
        {
         for (int i = 0; i < IndexOut.Count; i++)
         {
           if( IndexOut[i]!=-1)
           {
                ObjectSave.Add(new ObjectInfo(IndexOut[i],0,x,y,Controllers.itemsObject));
             IndexOut[i]=-1;
             olds--;
             break;
           }
         }
        }
        else
        {
       
        ObjectSave.Add(new ObjectInfo(Id,0,x,y,Controllers.itemsObject));
        Id++;
        }
      Crop.transform.position=  this.transform.position;
      //Destroy(transform.GetChild(0).gameObject);
      }
     
    }
    float RoundToFraction(float value, float fraction)
    {
       return Convert.ToSingle(Math.Round(value / fraction) * fraction);
    }
    
    void RoundCoordinate(float xfr = 0.5f, float yfr = 0.25f)
    {   
      Vector2 screenPosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
    Vector2 worldPosition = Camera.main.ScreenToWorldPoint(screenPosition);
        x=RoundToFraction(/*player.transform.position.x*/worldPosition.x,xfr);
        y=RoundToFraction( /*player.transform.position.y*/worldPosition.y,yfr);
        this.transform.position=new Vector2(x,y);
        
       
    }
}


