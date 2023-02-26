using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class enemySpawn : MonoBehaviour
{
    public bool roundOver = true;
    private string[] round1 = {"green", "green", "green"};
    private string[] round2 = {"green", "green", "green", "green", "green", "green", "green", "green", "green", "green"};
    private string[] round3 = {"blue", "green", "green", "green", "green", "green", "green", "green", "green", "green"};
    private string[] round4 = {"blue", "blue", "blue", "blue", "blue", "blue", "blue", "blue", "blue", "blue"};
    [SerializeField] private roundManager roundManager;
    private int spawnCount = -1;
    public bool spawning = false;
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
        //Debug.Log(roundManager.round);
        if (spawning)
        {
            spawnCount += 1;
            if (roundManager.round == 1)
            {
                if (spawnCount > round1.Length - 1)
                {
                    spawning = false;
                    spawnCount = -1;
                }
                else if (round1[spawnCount] == "green")
                {
                    recentEnemy = Instantiate(green, spawnPosition, Quaternion.identity);
                    recentEnemy.GetComponent<move>().healthMoney = FindObjectOfType<healthMoney>();
                    recentEnemy.GetComponent<move>().roundManager = FindObjectOfType<roundManager>();
                }
                else if (round1[spawnCount] == "blue")
                {
                    recentEnemy = Instantiate(blue, spawnPosition, Quaternion.identity);
                    recentEnemy.GetComponent<move>().healthMoney = FindObjectOfType<healthMoney>();
                    recentEnemy.GetComponent<move>().roundManager = FindObjectOfType<roundManager>();
                }
                else if (round1[spawnCount] == "red")
                {
                    recentEnemy = Instantiate(red, spawnPosition, Quaternion.identity);
                    recentEnemy.GetComponent<move>().healthMoney = FindObjectOfType<healthMoney>();
                    recentEnemy.GetComponent<move>().roundManager = FindObjectOfType<roundManager>();
                }
                else
                {
                    Debug.Log("Enemy type is not configured in enemySpawn.cs");
                }
            }
            else if (roundManager.round == 2)
            {
                if (spawnCount > round2.Length - 1)
                {
                    spawning = false;
                    spawnCount = -1;
                }
                else if (round2[spawnCount] == "green")
                {
                    recentEnemy = Instantiate(green, spawnPosition, Quaternion.identity);
                    recentEnemy.GetComponent<move>().healthMoney = FindObjectOfType<healthMoney>();
                    recentEnemy.GetComponent<move>().roundManager = FindObjectOfType<roundManager>();
                }
                else if (round2[spawnCount] == "blue")
                {
                    recentEnemy = Instantiate(blue, spawnPosition, Quaternion.identity);
                    recentEnemy.GetComponent<move>().healthMoney = FindObjectOfType<healthMoney>();
                    recentEnemy.GetComponent<move>().roundManager = FindObjectOfType<roundManager>();
                }
                else if (round2[spawnCount] == "red")
                {
                    recentEnemy = Instantiate(red, spawnPosition, Quaternion.identity);
                    recentEnemy.GetComponent<move>().healthMoney = FindObjectOfType<healthMoney>();
                    recentEnemy.GetComponent<move>().roundManager = FindObjectOfType<roundManager>();
                }
                else
                {
                    Debug.Log("enemy type is not configured in enemySpawn.cs");
                }
            }
            else if (roundManager.round == 3)
            {
                if (spawnCount > round3.Length - 1)
                {
                    spawning = false;
                    spawnCount = -1;
                }
                else if (round3[spawnCount] == "green")
                {
                    recentEnemy = Instantiate(green, spawnPosition, Quaternion.identity);
                    recentEnemy.GetComponent<move>().healthMoney = FindObjectOfType<healthMoney>();
                    recentEnemy.GetComponent<move>().roundManager = FindObjectOfType<roundManager>();
                }
                else if (round3[spawnCount] == "blue")
                {
                    recentEnemy = Instantiate(blue, spawnPosition, Quaternion.identity);
                    recentEnemy.GetComponent<move>().healthMoney = FindObjectOfType<healthMoney>();
                    recentEnemy.GetComponent<move>().roundManager = FindObjectOfType<roundManager>();
                }
                else if (round3[spawnCount] == "red")
                {
                    recentEnemy = Instantiate(red, spawnPosition, Quaternion.identity);
                    recentEnemy.GetComponent<move>().healthMoney = FindObjectOfType<healthMoney>();
                    recentEnemy.GetComponent<move>().roundManager = FindObjectOfType<roundManager>();
                }
                else
                {
                    Debug.Log("enemy type is not configured in enemySpawn.cs");
                }
            }
        }
    }
    public void currentlySpawning()
    {
        if (roundOver)
        {
            roundOver = false;
            spawning = true;
        }
        else if (!roundOver)
        {
            if (Time.timeScale == 1f)
            {
                Time.timeScale = 2f;
            }
            else if (Time.timeScale == 2f)
            {
                Time.timeScale = 1f;
            }
        }
        /*
        if (!spawning)
        {
            spawning = true;
        }
        else if (spawning)
        {
            if (Time.timeScale == 1f)
            {
                Time.timeScale = 2f;
            }
            else if (Time.timeScale == 2f)
            {
            Time.timeScale = 1f;
            }
        }
        */
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
