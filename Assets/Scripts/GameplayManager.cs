using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameplayManager : Singleton<GameplayManager> 
{

    public float TerrainWidth = 42.0f;


    public GameObject TerrainPrefab;

    public BirdController m_bird;

    private List<GameObject> SpawnedTerrain;

    private float terrainSpawnXLocation;

    

    // Start is called before the first frame update
    void Start()
    {
        SpawnedTerrain = new List<GameObject>();

        if (SpawnedTerrain.Count == 0)
        {
            SpawnedTerrain.Add(TerrainPrefab);
        }




    }

    // Update is called once per frame
    void Update()
    {
       
        
        var birdPostion = m_bird.transform.position.x;
        var lastTerrrainPosition = SpawnedTerrain[SpawnedTerrain.Count - 1].transform.position.x;
        var newTerrainPosition = (birdPostion + (TerrainWidth * 0.50f));


        Debug.Log("(birdPostion - lastTerrrainPosition): " + (birdPostion - lastTerrrainPosition ) + " newTerrainPosition: " +   newTerrainPosition + " modulo + " + newTerrainPosition % TerrainWidth);

           
        if (birdPostion - lastTerrrainPosition > 0 && newTerrainPosition % TerrainWidth <5)
        {

            //instantiates prefab: Terrain positioned on the end of previous prefab 
            GameObject.Instantiate(TerrainPrefab, new Vector3(newTerrainPosition, 0, 0), Quaternion.identity);

            SpawnedTerrain.Add(TerrainPrefab);


            if (SpawnedTerrain.Count > 0 && birdPostion - SpawnedTerrain[0].transform.position.x > 0)
            {
                GameObject.Destroy(SpawnedTerrain[0]);

                SpawnedTerrain.RemoveAt(0);

            }

        }
                                                    
        

    }
}
