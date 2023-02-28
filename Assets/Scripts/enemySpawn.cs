using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class enemySpawn : MonoBehaviour
{
    public bool roundOver = true;
    private string[] round1 = {"green", "green", "green"};
    private string[] round2 = {"green", "green", "green", "none", "none", "green", "green", "green", "none", "none", "green", "green", "green"};
    private string[] round3 = {"blue", "green", "green", "green", "green", "green", "green"};
    private string[] round4 = {"blue", "green", "blue", "green", "blue", "green", "blue", "green", "blue", "green", "blue", "green", "blue", "blue", "blue", "blue"};
    private string[] round5 = {"red", "red", "red"};
    private string[] round6 = {"blue", "blue", "blue", "blue", "blue", "blue", "blue", "blue", "blue", "blue", "blue", "blue", "blue", "blue", "blue", "blue", "blue", "blue", "blue", "blue", "blue", "blue", "blue", "blue"};
    private string[] round7 = {"red", "red", "blue", "blue", "blue", "blue", "blue", "blue", "blue", "blue", "blue", "blue", "blue", "blue", "blue", "blue", "blue", "blue", "blue", "blue", "blue", "blue", "blue", "blue", "blue", "blue"};
    private string[] round8 = {"red", "red", "red", "red", "red", "red", "red", "red", "red", "red", "red", "red", "red", "red", "red", "red", "red", "red", "red", "red", "red", "red", "red", "red", "red", "red", "red", "red", "red", "red"};
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
    void Start()
    {
        spawnCountdown = spawnTime - firstSpawnOffset;
    }
    void Spawn()
    {
        //Logs what the current round is every time the Spawn function is called
        Debug.Log(roundManager.round);
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
                else if (round1[spawnCount] == "none")
                {
                    Debug.Log("No enemy spawned");
                }
                else
                {
                    Debug.Log("Enemy type is not configured in enemySpawn.cs1");
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
                else if (round2[spawnCount] == "none")
                {
                    Debug.Log("No enemy spawned");
                }
                else
                {
                    Debug.Log("enemy type is not configured in enemySpawn.cs2");
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
                else if (round3[spawnCount] == "none")
                {
                    Debug.Log("No enemy spawned");
                }
                else
                {
                    Debug.Log("enemy type is not configured in enemySpawn.cs3");
                }
            }
            else if (roundManager.round == 4)
            {
                if (spawnCount > round4.Length - 1)
                {
                    spawning = false;
                    spawnCount = -1;
                }
                else if (round4[spawnCount] == "green")
                {
                    recentEnemy = Instantiate(green, spawnPosition, Quaternion.identity);
                    recentEnemy.GetComponent<move>().healthMoney = FindObjectOfType<healthMoney>();
                    recentEnemy.GetComponent<move>().roundManager = FindObjectOfType<roundManager>();
                }
                else if (round4[spawnCount] == "blue")
                {
                    recentEnemy = Instantiate(blue, spawnPosition, Quaternion.identity);
                    recentEnemy.GetComponent<move>().healthMoney = FindObjectOfType<healthMoney>();
                    recentEnemy.GetComponent<move>().roundManager = FindObjectOfType<roundManager>();
                }
                else if (round4[spawnCount] == "red")
                {
                    recentEnemy = Instantiate(red, spawnPosition, Quaternion.identity);
                    recentEnemy.GetComponent<move>().healthMoney = FindObjectOfType<healthMoney>();
                    recentEnemy.GetComponent<move>().roundManager = FindObjectOfType<roundManager>();
                }
                else if (round4[spawnCount] == "none")
                {
                    Debug.Log("No enemy spawned");
                }
                else
                {
                    Debug.Log("enemy type is not configured in enemySpawn.cs4");
                }
            }
            else if (roundManager.round == 5)
            {
                if (spawnCount > round5.Length - 1)
                {
                    spawning = false;
                    spawnCount = -1;
                }
                else if (round5[spawnCount] == "green")
                {
                    recentEnemy = Instantiate(green, spawnPosition, Quaternion.identity);
                    recentEnemy.GetComponent<move>().healthMoney = FindObjectOfType<healthMoney>();
                    recentEnemy.GetComponent<move>().roundManager = FindObjectOfType<roundManager>();
                }
                else if (round5[spawnCount] == "blue")
                {
                    recentEnemy = Instantiate(blue, spawnPosition, Quaternion.identity);
                    recentEnemy.GetComponent<move>().healthMoney = FindObjectOfType<healthMoney>();
                    recentEnemy.GetComponent<move>().roundManager = FindObjectOfType<roundManager>();
                }
                else if (round5[spawnCount] == "red")
                {
                    recentEnemy = Instantiate(red, spawnPosition, Quaternion.identity);
                    recentEnemy.GetComponent<move>().healthMoney = FindObjectOfType<healthMoney>();
                    recentEnemy.GetComponent<move>().roundManager = FindObjectOfType<roundManager>();
                }
                else if (round5[spawnCount] == "none")
                {
                    Debug.Log("No enemy spawned");
                }
                else
                {
                    Debug.Log("enemy type is not configured in enemySpawn.cs4");
                }
            }
            else if (roundManager.round == 6)
            {
                if (spawnCount > round6.Length - 1)
                {
                    spawning = false;
                    spawnCount = -1;
                }
                else if (round6[spawnCount] == "green")
                {
                    recentEnemy = Instantiate(green, spawnPosition, Quaternion.identity);
                    recentEnemy.GetComponent<move>().healthMoney = FindObjectOfType<healthMoney>();
                    recentEnemy.GetComponent<move>().roundManager = FindObjectOfType<roundManager>();
                }
                else if (round6[spawnCount] == "blue")
                {
                    recentEnemy = Instantiate(blue, spawnPosition, Quaternion.identity);
                    recentEnemy.GetComponent<move>().healthMoney = FindObjectOfType<healthMoney>();
                    recentEnemy.GetComponent<move>().roundManager = FindObjectOfType<roundManager>();
                }
                else if (round6[spawnCount] == "red")
                {
                    recentEnemy = Instantiate(red, spawnPosition, Quaternion.identity);
                    recentEnemy.GetComponent<move>().healthMoney = FindObjectOfType<healthMoney>();
                    recentEnemy.GetComponent<move>().roundManager = FindObjectOfType<roundManager>();
                }
                else if (round6[spawnCount] == "none")
                {
                    Debug.Log("No enemy spawned");
                }
                else
                {
                    Debug.Log("enemy type is not configured in enemySpawn.cs4");
                }
            }
            else if (roundManager.round == 7)
            {
                if (spawnCount > round7.Length - 1)
                {
                    spawning = false;
                    spawnCount = -1;
                }
                else if (round7[spawnCount] == "green")
                {
                    recentEnemy = Instantiate(green, spawnPosition, Quaternion.identity);
                    recentEnemy.GetComponent<move>().healthMoney = FindObjectOfType<healthMoney>();
                    recentEnemy.GetComponent<move>().roundManager = FindObjectOfType<roundManager>();
                }
                else if (round7[spawnCount] == "blue")
                {
                    recentEnemy = Instantiate(blue, spawnPosition, Quaternion.identity);
                    recentEnemy.GetComponent<move>().healthMoney = FindObjectOfType<healthMoney>();
                    recentEnemy.GetComponent<move>().roundManager = FindObjectOfType<roundManager>();
                }
                else if (round7[spawnCount] == "red")
                {
                    recentEnemy = Instantiate(red, spawnPosition, Quaternion.identity);
                    recentEnemy.GetComponent<move>().healthMoney = FindObjectOfType<healthMoney>();
                    recentEnemy.GetComponent<move>().roundManager = FindObjectOfType<roundManager>();
                }
                else if (round7[spawnCount] == "none")
                {
                    Debug.Log("No enemy spawned");
                }
                else
                {
                    Debug.Log("enemy type is not configured in enemySpawn.cs4");
                }
            }
        }
    }
    public void currentlySpawning()
    {
        //Checks if the round is over, if it is, then it sets spawning to true
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
    }

    void Update()
    {
        //Checks if the timer has run out, if it has, then it spawns an enemy and resets the time
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
