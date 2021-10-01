using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{
   public void Start()
   {
        RaycastHit hit;
  var p = Camera.main.ScreenToWorldPoint(Input.mousePosition);
var hit2D = Physics2D.Raycast(p, Vector2.zero);
  if (hit2D.transform != null&&hit2D.transform.gameObject.tag=="Object")
        {
          Destroy(gameObject);
        }
   }
       
}

