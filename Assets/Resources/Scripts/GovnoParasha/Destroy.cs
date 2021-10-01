using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Destroy : MonoBehaviour
{
    // private SpriteRenderer Renderer;
       public static float x;
       public static float y;
       private GameObject player;

    //
    void Start()
    {
          player = GameObject.FindWithTag("Player");
         
    }
void Update()
{
    Item item = Player.GetHandItem();
  
     if(ObjectManipulation.ObjectBuild)
      {
        Destroy(gameObject);
      }
        this.transform.localScale = new Vector3(1, 1, 1);
        RoundCoordinate();

}
     float RoundToFraction(float value, float fraction)
    {
       return Convert.ToSingle(Math.Round(value / fraction) * fraction);
    }
    
     void RoundCoordinate(float xfr = 0.5f, float yfr = 0.25f)
    {   Vector2 screenPosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
    Vector2 worldPosition = Camera.main.ScreenToWorldPoint(screenPosition);
        x=RoundToFraction(/*player.transform.position.x*/worldPosition.x,xfr);
        y=RoundToFraction( /*player.transform.position.y*/worldPosition.y,yfr);
        this.transform.position=new Vector2(x,y);
       
    }
}
