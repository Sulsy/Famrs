using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using System.Linq;
public class Crop : MonoBehaviour
{
        
    private const int STEP_EMPTY = 0;
    private const int STEP_GROWSONE = 1;
    private const int STEP_GROWSTWO = 2;
    private const int STEP_THERE = 3;
    private const int STEP_PRODUCT = 5;
    private const int STEP_PRODUCTS = 4;
    private const int STEP_PLOW = 6;

    private SpriteRenderer OneRenderer;
    private SpriteRenderer TwoRenderer;
    private SpriteRenderer ThereRenderer;
    private SpriteRenderer FourRenderer;
    private SpriteRenderer ProductRenderer;
    private SpriteRenderer CropRenderer;


    public Item cropItem;
    public float timeGrow;
    public int step = 0;
    private GameObject player;
    private GameObject destroy;
    private bool ForReadyGrow;
    private bool Search;
    private bool NameLoad;
    private bool Updates;
    private int id;
    private string name;
    private string timeGrowStarted=string.Empty;
    public ObjectInfo objectInfo;
    
    public void Clears()
    {
        if(File.Exists(DataBase.ObjectInasfoPath+this.objectInfo.id)){File.Delete(DataBase.ObjectInasfoPath+this.objectInfo.id);}
    }
    void Start()
    {
          Debug.Log("ПРОШЛОНАХУЙ"+$"{DataBase.difference}");

        CropRenderer = GetComponent<SpriteRenderer>();
        OneRenderer = GetComponentsInChildren<SpriteRenderer>()[1];
        TwoRenderer = GetComponentsInChildren<SpriteRenderer>()[2];
        ThereRenderer = GetComponentsInChildren<SpriteRenderer>()[3];
        FourRenderer = GetComponentsInChildren<SpriteRenderer>()[4];
        ProductRenderer = GetComponentsInChildren<SpriteRenderer>()[5];
        player = GameObject.FindWithTag("Player");
        for(int i=0;i<Builder.ObjectSave.Count;i++)
        {
            if(Builder.ObjectSave[i].types=="Crop"&&new Vector3(Builder.ObjectSave[i]._positionx,Builder.ObjectSave[i]._positiony)==this.transform.position)
           {
           objectInfo=   Builder.ObjectSave[i];
           id=objectInfo.id;
               //  Debug.Log(Player.CropList[i].objectInfo._positionx);
            }
        }
            timeGrow=cropItem.timeGrow;
        if(File.Exists(DataBase.ObjectInasfoPath+this.objectInfo.id))
         {
         
             LoadCropInfo();
                       Debug.Log("степ"+$"{step}");
           TimeOfflines();
               switch(step)
             {
                 case STEP_GROWSONE:
                 TwoRenderer.sprite = Resources.Load<Sprite>($"Item/Food/{cropItem.name}/{cropItem.name}"+$"{1}");
                       cropItem.count=2;
                 break;
                 case STEP_GROWSTWO:
                 ThereRenderer.sprite = Resources.Load<Sprite>($"Item/Food/{cropItem.name}/{cropItem.name}"+$"{2}");
                       cropItem.count=2;
                 break;
                 case STEP_THERE:
                 FourRenderer.sprite = Resources.Load<Sprite>($"Item/Food/{cropItem.name}/{cropItem.name}"+$"{3}");
                        cropItem.count=2;
                 break;
                 case STEP_PRODUCT:
                 ProductRenderer.sprite = Resources.Load<Sprite>($"Item/Food/{cropItem.name}/{cropItem.name}"+$"{4}");
                        cropItem.count=2;
                 break;
                 default:
                 break;
             }
              Plants(cropItem); 
    }
    }
    private void TimeOfflines()
    {
        if(DataBase.difference>cropItem.timeGrow&&step!=0&&step<4){step++;}
         if(DataBase.difference>cropItem.timeGrow*2&&step!=0&&step<4){step++;}
             if(DataBase.difference>cropItem.timeGrow*3&&step!=0&&step<4){step++;}
                 if(DataBase.difference>cropItem.timeGrow*4&&step!=0&&step<4){step++;}

    }
    void Update()
    {
        // Debug.Log(timeGrow);
     destroy = GameObject.FindWithTag("Destroy");  
     if(DataBase.Clear)Clears();
     
    }
    public void SaveCrop()
    {
       File. WriteAllText(DataBase.ObjectInasfoPath+this.objectInfo.id, $"{cropItem.name}");
       File. AppendAllText(DataBase.ObjectInasfoPath+this.objectInfo.id, $"\n{cropItem.imgUrl}");
       File. AppendAllText(DataBase.ObjectInasfoPath+this.objectInfo.id, $"\n{cropItem.type}");
       File. AppendAllText(DataBase.ObjectInasfoPath+this.objectInfo.id, $"\n{cropItem.price}");
       File. AppendAllText(DataBase.ObjectInasfoPath+this.objectInfo.id, $"\n{cropItem.LvL}");
       File. AppendAllText(DataBase.ObjectInasfoPath+this.objectInfo.id, $"\n{cropItem.timeGrow}");
       File. AppendAllText(DataBase.ObjectInasfoPath+this.objectInfo.id, $"\n{step}");
       File. AppendAllText(DataBase.ObjectInasfoPath+this.objectInfo.id, $"\n{timeGrow}");
       //Debug.Log("степ"+$"{step}");
    }
    public void LoadCropInfo()
    {
     
      FileStream file1 = new FileStream(DataBase.ObjectInasfoPath+this.objectInfo.id, FileMode.Open); //создаем файловый поток
      StreamReader reader = new StreamReader(file1); // создаем «потоковый читатель» и связываем его с файловым потоком
    
       cropItem.name=reader.ReadLine();
       cropItem.imgUrl=reader.ReadLine();
       cropItem.type=Int32.Parse(reader.ReadLine());
       cropItem.price=Int32.Parse(reader.ReadLine());
       cropItem.LvL=Int32.Parse(reader.ReadLine());
       cropItem.timeGrow=Single.Parse(reader.ReadLine());
       step=Int32.Parse(reader.ReadLine());
       timeGrow=Int32.Parse(reader.ReadLine())-DataBase.difference;
        //  Debug.Log(cropItem.name); //считываем все данные с потока и выводим на экран
        reader.Close();
         ForReadyGrow=true;
    }
    void OnMouseDown()
    {
         if(Vector3.Distance(this.transform.position,player.transform.position)<2f&& Controllers.Delet)
      {
             if(destroy.transform.position==this.transform.position)
        {
         //   foreach(ObjectInfo DestroyInSave in Build.ObjectSave)
            //{
              

           // }
           Clears();
            Destroy(gameObject);
            Builder.IndexOut.Add(objectInfo.id);
            Builder.ObjectSave.Remove(this.objectInfo);
            Builder.olds++;
        }
        
      }
       
         Item item = Player.GetHandItem();
      //if(item.type==Item.TYPEFOOD)
       Search=true;
      Plants(item);
       
    }
    private void Plants( Item item)
    {

        if (ForReadyGrow)
        {
            switch(step)
            {
                case STEP_EMPTY:
                 
                 if (item.type == Item.TYPEFOOD&& Search)
                {
                    Player.RemovItem();
                    cropItem = item;
                    cropItem.count=2;
                    OneRenderer.sprite = Resources.Load<Sprite>($"Item/Food/{cropItem.name}/{cropItem.name}"+$"{0}");
                    timeGrowStarted=System.DateTime.Now.ToBinary().ToString();
                    StartCoroutine(Grow());
                }
                break;

                case STEP_PRODUCT:
                if(Search)
                {
                CropRenderer.sprite = Resources.Load<Sprite>("Item/Food/cropBroken");
                ProductRenderer.sprite = Resources.Load<Sprite>("");
                OneRenderer.sprite = Resources.Load<Sprite>($"");
                cropItem.count=2;
                step = STEP_PLOW;
                Player.CheckItem(cropItem);
                }
                break;

                case STEP_PLOW:
                if(item.type==Item.TYPEPLOW)
                {
                    CropRenderer.sprite=Resources.Load<Sprite>("");
                    step=STEP_EMPTY;
                    Search=false;
                }
                break;

                default:
                 StartCoroutine(Grow());
                break;
            }
        }
    }
    private IEnumerator Grow()
    {
        for(int i=0;i<5;i++)
        {
       // if(Search){yield return new WaitForSeconds(timeGrow);}
        switch(step)
        {
            case STEP_EMPTY:
               yield return new WaitForSeconds(timeGrow);
        OneRenderer.sprite = Resources.Load<Sprite>("");
        TwoRenderer.sprite = Resources.Load<Sprite>($"Item/Food/{cropItem.name}/{cropItem.name}"+$"{0}");
        step = STEP_GROWSONE;
        timeGrow=cropItem.timeGrow;
                break;
            case STEP_GROWSONE:
                    yield return new WaitForSeconds(timeGrow);
        TwoRenderer.sprite = Resources.Load<Sprite>("");
        ThereRenderer.sprite = Resources.Load<Sprite>($"Item/Food/{cropItem.name}/{cropItem.name}"+$"{1}");
        step = STEP_GROWSTWO;
         timeGrow=cropItem.timeGrow;
                break;
            case STEP_GROWSTWO:
                    yield return new WaitForSeconds(timeGrow);
        ThereRenderer.sprite = Resources.Load<Sprite>("");
        FourRenderer.sprite = Resources.Load<Sprite>($"Item/Food/{cropItem.name}/{cropItem.name}"+$"{2}");
        step = STEP_THERE;
          timeGrow=cropItem.timeGrow;
                break;
            case STEP_THERE:
                    yield return new WaitForSeconds(timeGrow);
        FourRenderer.sprite = Resources.Load<Sprite>("");
        ProductRenderer.sprite = Resources.Load<Sprite>($"Item/Food/{cropItem.name}/{cropItem.name}"+$"{3}");
        step = STEP_PRODUCTS;
          timeGrow=cropItem.timeGrow;
        break;
         case STEP_PRODUCTS:
                    yield return new WaitForSeconds(timeGrow);
        FourRenderer.sprite = Resources.Load<Sprite>("");
        ProductRenderer.sprite = Resources.Load<Sprite>($"Item/Food/{cropItem.name}/{cropItem.name}"+$"{4}");
        step = STEP_PRODUCT;
        break;
        }
        }
    }
    public void FixedUpdate()
    {
        switch(step)
            {
                case STEP_EMPTY:
                case STEP_PRODUCT:
                
                if (Vector3.Distance(this.transform.position,player.transform.position)<1f)
            {
                CropRenderer.sprite = Resources.Load<Sprite>("Item/Food/cropSelected");
                ForReadyGrow = true;
            }
            else
            {
                CropRenderer.sprite = Resources.Load<Sprite>("Item/Food/crop");
                ForReadyGrow = false;
            }
                break;

                case STEP_PLOW:
               if (Vector3.Distance(this.transform.position,player.transform.position)<1f)
            {
                CropRenderer.sprite = Resources.Load<Sprite>("Item/Food/cropBrokenSekected");
                ForReadyGrow = true;
            }
            else
            {
                CropRenderer.sprite = Resources.Load<Sprite>("Item/Food/cropBroken");
                ForReadyGrow = false;
            }
                break;

                default:
                break;
            }
    }
    void OnApplicationQuit()
    {
      SaveCrop();
    }
}
