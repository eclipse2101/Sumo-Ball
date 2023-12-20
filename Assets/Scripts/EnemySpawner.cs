using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
   public GameObject enemies;
   public float spawnarea = 10;
 
   
    // Start is called before the first frame update
    void Start()
    {
        
        Instantiate(enemies, GenerateSpawnArea(), enemies.transform.rotation);
    }

    // Update is called once per frame
    private Vector3 GenerateSpawnArea()
    {
        float rsax = Random.Range(spawnarea, -spawnarea);
        float rsaz = Random.Range(spawnarea, -spawnarea); 
        Vector3 randomPos =  new Vector3( rsax, 0, rsaz);
        return randomPos;
    }
}
