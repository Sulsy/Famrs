using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class Build : MonoBehaviour
{private GameObject player;
 public GameObject CropPrefab;
 private GameObject Crop;
 private int Id=0;
 public static float x;
 public static float y;
 private bool colis;
  public static List<ObjectInfo> ObjectSave=new  List<ObjectInfo>();
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        
    }
void OnCollisionEnter2D(Collision2D myCollision){
  // определение столкновения с двумя разноименными объектами
  if (myCollision.gameObject.name == ("Desk")) {  
      // Обращаемся к имени объекта с которым столкнулись  
      Debug.Log("Hit the floor");
      colis=true;
    }
}
    
  

    // Update is called once per frame
    void Update()
    {   
    
       Item item = Player.GetHandItem();
 
      if(!ObjectManipulation.ObjectBuild)
      {
        Destroy(gameObject);
      }
  
        if(item.type == Item.TYPESHOVEl)
        {
        this.transform.localScale = new Vector3(1, 1, 1);
          RoundCoordinate();
        }
        else
        {
            this.transform.localScale = new Vector3(0, 0, 1);
        }
     
        
    }
    void OnMouseDown()
    {      
       if(!colis)
     {  
       if(Vector3.Distance(new Vector3(x,y),player.transform.position)<2f)
      {
      Crop=Instantiate(CropPrefab);
      Crop.transform.position=  this.transform.position;
                                                                                                                                                                                         Debug.Log($"{x}xd"+$"{y}yd");
                                                                                                                                                                                
     // ObjectSave.Add(new ObjectInfo(Id,0,x,y));
      //Destroy(transform.GetChild(0).gameObject);
      }
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
        Id++;
       
    }
}
