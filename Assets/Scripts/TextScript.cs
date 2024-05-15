using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 
using UnityEngine.UI; 
public class TextScript : MonoBehaviour
{
    public TextMeshProUGUI textScore; 
    public TextMeshProUGUI textLives;
    private PlayerController PC;
    private EnemySpawner ES;  
    // Start is called before the first frame update
    void Start()
    {
        PC = GameObject.Find("Player").GetComponent<PlayerController>();
        ES = GameObject.Find("enemyspawner").GetComponent<EnemySpawner>();
        textLives.text = "Lives:" + PC.Health;
        textScore.text = "Wave" + ES.WaveNumber;
    }

    // Update is called once per frame
    void Update()
    {
      textLives.text = "Lives: " + PC.Health;
      textScore.text = "Wave " + ES.WaveNumber;
    }
}
