using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawn : MonoBehaviour
{
    public enum enemy { green, blue, red}
    public enemy enemyType;
    [SerializeField] private float spawnTime = 1f;
    [SerializeField] private float firstSpawnOffset = 0.2f;
    private float spawnCountdown = 1f;
    [SerializeField] private Vector3 spawnPosition = new Vector3(-12.09f, 4, -0.138f);
    [SerializeField] private GameObject green;
    [SerializeField] private GameObject blue;
    [SerializeField] private GameObject red;
    private GameObject recentEnemy;
    // Start is called before the first frame update
    void Start()
    {
        spawnCountdown = spawnTime - firstSpawnOffset;
    }
    void Spawn()
    {
        if (enemyType == enemy.green)
        {
            recentEnemy = Instantiate(green, spawnPosition, Quaternion.identity);
        }
        else if (enemyType == enemy.blue)
        {
            recentEnemy = Instantiate(blue, spawnPosition, Quaternion.identity);
        }
        else if (enemyType == enemy.red)
        {
            recentEnemy = Instantiate(red, spawnPosition, Quaternion.identity);
        }
        else
        {
            Debug.Log("No valid enemy type selected");
        }
        recentEnemy.GetComponent<move>().healthMoney = FindObjectOfType<healthMoney>();
        recentEnemy.GetComponent<move>().roundManager = FindObjectOfType<roundManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (spawnCountdown <= 0)
        {
            Spawn();
            spawnCountdown = spawnTime;
        }
        else
        {
            spawnCountdown -= Time.deltaTime;
        }
    }
}
