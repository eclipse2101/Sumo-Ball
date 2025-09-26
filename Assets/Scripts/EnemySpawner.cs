using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
   public GameObject[] enemies;
   public float spawnarea = 10;
   public int enemyCount;
   public int itemCount; 
   public int WaveNumber = 1; 
   public int BossWave = 5;
   public GameObject[] powerupPrefabs;
   private PlayerController PC;
   
    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemyWave(1);
        SpawnPowerUp(3); 
        PC = GameObject.Find("Player").GetComponent<PlayerController>();
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
          if(WaveNumber >= 5)
          {
            int randomEnemy = Random.Range(0, 1);
            Instantiate(enemies[randomEnemy], GenerateSpawnArea(), enemies[randomEnemy].transform.rotation);
          }
          else
          {
            Instantiate(enemies[0], GenerateSpawnArea(),enemies[0].transform.rotation);
          }
       }
    }

    void SpawnPowerUp(int powerupSpawnNumber)
    {
       for (int i = 0; i < powerupSpawnNumber; i++)
       {
            int randomPoweup = Random.Range(0, powerupPrefabs.Length);
            Instantiate(powerupPrefabs[randomPoweup], GenerateSpawnArea(), powerupPrefabs[randomPoweup].transform.rotation);
          
       }
    }

    void Update()
    {
       enemyCount = FindObjectsOfType<EnemyController>().Length;
       itemCount = FindObjectsOfType<itemDespawner>().Length;
       
        if (enemyCount == 0 && PC.gameOver == false) //checks if the game is still running 
        {
            //does a check if the next wave is a boss wave
            WaveNumber = WaveNumber + 1;

            if (WaveNumber == BossWave)
            {
                //Adds a boss as part of the number of enenmies in the wave if true 
                Instantiate(enemies[2], GenerateSpawnArea(), enemies[2].transform.rotation);
                SpawnEnemyWave(WaveNumber - 1);
                
                BossWave = BossWave + 5;
                
            }
            else
            {
                SpawnEnemyWave(WaveNumber);
                //WaveNumber = WaveNumber + 1; 
            }
            
        }
         
         if (itemCount == 0) 
        {
            SpawnPowerUp(3);  
        }

         
    }

}
