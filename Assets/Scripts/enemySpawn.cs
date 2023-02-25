using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class enemySpawn : MonoBehaviour
{
    private bool spawning = false;
    public enum enemy { green, blue, red, none}
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
    public void R()
    {
        enemyType = enemy.red;
    }
    public void G()
    {
        enemyType = enemy.green;
    }
    public void B()
    {
        enemyType = enemy.blue;
    }
    public void N()
    {
        enemyType = enemy.none;
    }
    void Spawn()
    {
        if (spawning)
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
                Debug.Log("No enemy was spawned");
            }
            recentEnemy.GetComponent<move>().healthMoney = FindObjectOfType<healthMoney>();
            recentEnemy.GetComponent<move>().roundManager = FindObjectOfType<roundManager>();
        }
    }
    public void currentlySpawning()
    {
        spawning = true;
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
