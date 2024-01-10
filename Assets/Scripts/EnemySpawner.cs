using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
   public GameObject enemies;
   public float spawnarea = 10;
   public int enemyCount;
   public int WaveNumber = 1; 
   public GameObject powerupPrefab;
 
   
    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemyWave(3);
        
    }

    // Update is called once per frame
    private Vector3 GenerateSpawnArea()
    {
        float rsax = Random.Range(spawnarea, -spawnarea);
        float rsaz = Random.Range(spawnarea, -spawnarea); 
        Vector3 randomPos =  new Vector3( rsax, 0, rsaz);
        return randomPos;
    }

    void SpawnEnemyWave(int enemiesSpawnNumber)
    {
       for (int i = 0; i < enemiesSpawnNumber; i++)
       {
          Instantiate(enemies, GenerateSpawnArea(), enemies.transform.rotation);
          Instantiate(powerupPrefab, GenerateSpawnArea(), powerupPrefab.transform.rotation);
       }
    }

    void Update()
    {
       enemyCount = FindObjectsOfType<EnemyController>().Length;
        if (enemyCount == 0) 
        {
            SpawnEnemyWave(WaveNumber);
           
        }
    }

}
