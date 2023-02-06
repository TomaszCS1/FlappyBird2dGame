using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameplayManager : Singleton<GameplayManager> 
{

    float TerrainWidth = 42.0f;
    float obstacleDistance = 20.0f;


    public GameObject TerrainPrefab;
    public GameObject obstaclePrefab;

    public BirdController m_bird;

    private List<GameObject> SpawnedTerrain;
    private List<GameObject> SpawnedObstacle;

    private float terrainSpawnXLocation;

    GameObject prefabTerrainInstance;
    GameObject prefabObstacleInstance;

    private float birdPosition;
    private float birdLastObstacleDistance;


    // Start is called before the first frame update
    void Start()
    {
        SpawnedTerrain = new List<GameObject>();
        if (SpawnedTerrain.Count == 0)
        {

            prefabTerrainInstance = GameObject.Instantiate(TerrainPrefab, new Vector3(TerrainWidth, 0, 0), Quaternion.identity);
           
            SpawnedTerrain.Add(prefabTerrainInstance);
        }

        SpawnedObstacle = new List<GameObject>();
        if (SpawnedObstacle.Count == 0)
        {
            obstacleDistance = Random.Range( obstacleDistance-2f, obstacleDistance+2f);
            prefabObstacleInstance = GameObject.Instantiate(obstaclePrefab, new Vector3(obstacleDistance, 0, 0), Quaternion.identity);
           
            SpawnedObstacle.Add(prefabObstacleInstance);
        }
      
       

    }

    // Update is called once per frame
    void Update()
    {
        birdPosition = m_bird.transform.position.x;
        //______________________________________________________TERRAIN_________________________________________________________________________

        var lastTerrrainPosition = SpawnedTerrain[SpawnedTerrain.Count - 1].transform.position.x;
        var newTerrainPosition = (lastTerrrainPosition + (TerrainWidth* 0.5f));
           
          if ((birdPosition - lastTerrrainPosition ) > 0 && birdPosition > TerrainWidth)
          {

            //instantiates prefab: Terrain positioned on the end of previous prefab 
            prefabTerrainInstance = GameObject.Instantiate(TerrainPrefab, new Vector3(newTerrainPosition, 0, 0), Quaternion.identity);
            SpawnedTerrain.Add(prefabTerrainInstance);


            if (SpawnedTerrain.Count > 0 && birdPosition - SpawnedTerrain[0].transform.position.x - TerrainWidth*0.5> 0)
            {
                GameObject.Destroy(SpawnedTerrain[0]);

                SpawnedTerrain.RemoveAt(0);

            }

          }
        
        //______________________________________________________OBSTACLE_________________________________________________________________________

        var lastObstaclePosition = SpawnedObstacle[SpawnedObstacle.Count- 1].transform.position.x;
        var newObstaclePosition = lastObstaclePosition + obstacleDistance;

        if (birdPosition + 2*obstacleDistance >lastObstaclePosition )
        {
            
            //instantiates prefab: Terrain positioned on the end of previous prefab 
             prefabObstacleInstance = GameObject.Instantiate(obstaclePrefab, new Vector3(newObstaclePosition , 0, 0), Quaternion.identity);

            SpawnedObstacle.Add(prefabObstacleInstance);


            if (SpawnedObstacle.Count > 0 && birdPosition - SpawnedObstacle[0].transform.position.x - TerrainWidth*0.5> 0)
            {
                GameObject.Destroy(SpawnedObstacle[0]);

                SpawnedObstacle.RemoveAt(0);

            }

        }

    }
}
