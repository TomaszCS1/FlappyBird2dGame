using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameplayManager : Singleton<GameplayManager> 
{

    public float TerrainWidth = 100.0f;


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
        Debug.Log("terrainSpawnXLocation:  " + terrainSpawnXLocation + " modulo:  " + terrainSpawnXLocation % TerrainWidth);
                    terrainSpawnXLocation = (m_bird.transform.position.x + (TerrainWidth * 0.5f));


        //current pos. bird             // center of last spawned terrain 
        if (m_bird.transform.position.x - SpawnedTerrain[SpawnedTerrain.Count - 1].transform.position.x >= 0.0f && ((terrainSpawnXLocation % TerrainWidth > 97.0f) || terrainSpawnXLocation % TerrainWidth==0))
        {

            //instantiates prefab: Terrain positioned on the end of previous prefab 
            GameObject.Instantiate(TerrainPrefab, new Vector3(terrainSpawnXLocation, 0, 0), Quaternion.identity);

            SpawnedTerrain.Add(TerrainPrefab);

        }

        if()
    }
}
