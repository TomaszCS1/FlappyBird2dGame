using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class ObstacleController : MonoBehaviour
{
    // the gap between UpColumns and DownColumn
    public float GapHeight;

    // the height of the center of the gap from the ground level (.y=-9f)
    public float GapMidpoint;
    private float TotalHeight;

    public SpriteRenderer UpColumn;
    public SpriteRenderer DownColumn;
    

    

    // Start is called before the first frame update
    void Start()
    {
        TotalHeight = GetComponent<BoxCollider2D>().size.y;
        UpColumn = transform.Find("UpColumn").gameObject.GetComponent<SpriteRenderer>();
        DownColumn = transform.Find("DownColumn").gameObject.GetComponent<SpriteRenderer>();
      
        UpColumn.size= new Vector2(5, 22);
        DownColumn.size= new Vector2(5, 22);

        UpdateObstacleParams();
    }

    // Update is called once per frame
    void Update()
    {
        
                
    }

    void UpdateObstacleParams()
    {
        GapHeight = Mathf.Clamp(GapHeight, 5f, 10F);
        GapMidpoint = Mathf.Clamp(GapMidpoint, -3f, 4F);

        GapMidpoint = UnityEngine.Random.Range(-3f, 4f);
        GapHeight = UnityEngine.Random.Range(5f, 9f);

        var YPositionUpperColumn = UpColumn.transform.position;
        var YPositionLowerColumn = DownColumn.transform.position;
       


        YPositionUpperColumn = new Vector3(0, 1, 0) * (UpColumn.size.y / 2 + GapMidpoint + GapHeight / 2);

        YPositionLowerColumn = new Vector3(0, 1, 0) * (GapMidpoint - GapHeight / 2 - DownColumn.size.y / 2);

        //Position of hole Prefab (parent in Hierarchy):
         transform.position = new Vector3(transform.position.x, GapMidpoint, 0) ;
    }


}
