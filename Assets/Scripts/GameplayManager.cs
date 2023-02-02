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

    GameObject prefabInstance;


    // Start is called before the first frame update
    void Start()
    {
        SpawnedTerrain = new List<GameObject>();

        if (SpawnedTerrain.Count == 0)
        {

            prefabInstance = GameObject.Instantiate(TerrainPrefab, new Vector3(TerrainWidth*1.0f, 0, 0), Quaternion.identity);
           
            SpawnedTerrain.Add(prefabInstance);
        }



    }

    // Update is called once per frame
    void Update()
    {
       
        
        var birdPosition = m_bird.transform.position.x;
        var lastTerrrainPosition = SpawnedTerrain[SpawnedTerrain.Count - 1].transform.position.x;
        var newTerrainPosition = (lastTerrrainPosition + (TerrainWidth* 0.5f));

        Debug.Log("birdPostion: " + birdPosition + " newTerrainPosition: " + newTerrainPosition );

           
        if ((birdPosition - lastTerrrainPosition ) > 0 && birdPosition > TerrainWidth)
        {

            //instantiates prefab: Terrain positioned on the end of previous prefab 
            prefabInstance = GameObject.Instantiate(TerrainPrefab, new Vector3(newTerrainPosition, 0, 0), Quaternion.identity);

            Debug.Log(" Prefab generated ");
            SpawnedTerrain.Add(prefabInstance);


            if (SpawnedTerrain.Count > 0 && birdPosition - SpawnedTerrain[0].transform.position.x - TerrainWidth*0.5> 0)
            {
                GameObject.Destroy(SpawnedTerrain[0]);

                SpawnedTerrain.RemoveAt(0);

            }

        }
                                                    
        

    }
}
