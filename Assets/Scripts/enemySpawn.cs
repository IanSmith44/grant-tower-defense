using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

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
    private string[] round8 = {"red", "blue", "red", "blue", "red", "blue", "red", "blue", "red", "blue", "red", "blue", "red", "blue", "red", "blue", "red", "blue", "red", "blue", "red", "blue", "red", "blue", "red", "blue", };
    private string[] round9 = {"red", "red", "red", "red", "red", "red", "red", "red", "red", "red", "red", "red", "red", "red", "red", "red", "red", "red", "red", "red", "red", "red", "red", "red", "red", "red", "red", "red", "red", "red"};
    private string[] round10 = {"yellow", "yellow", "yellow", "yellow", "yellow"};
    private string[] round11 = {"yellow", "yellow", "yellow", "yellow", "yellow", "yellow", "yellow", "yellow", "yellow", "yellow", "yellow", "yellow", "yellow", "yellow", "yellow", "yellow", "yellow", "yellow", "yellow", "yellow", "yellow", "yellow", "yellow", "yellow"};
    private string[] round12 = {"orange", "yellow", "yellow", "orange", "yellow", "yellow", "orange", "yellow", "yellow", "orange", "yellow", "yellow", "orange", "yellow", "yellow", "orange", "yellow", "yellow", "orange", "yellow", "yellow", "orange", "yellow", "yellow", "orange", "yellow", "yellow"};
    private string[] round13 = {"pink", "pink", "pink", "pink", "pink", "pink"};
    private string[] round14 = {"glimp", "none", "none", "none", "glimp"};
    private string[] round15 = {"glimp", "glimp", "glimp", "glimp", "glimp" };
    private string[] round16 = {"fighterget", "none", "none", "none", "fighterget"};
    private string[] round17 = { "fighterget", "fighterget", "fighterget", "fighterget", "fighterget"};
    private string[] round18 = { "fighterget", "fighterget", "fighterget", "fighterget", "fighterget", "fighterget", "fighterget", "fighterget", "fighterget", "fighterget", "fighterget", "fighterget", "fighterget"};
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
    [SerializeField] private GameObject yellow;
    [SerializeField] private GameObject orange;
    [SerializeField] private GameObject pink;
    [SerializeField] private GameObject glimp;
    [SerializeField] private GameObject fighterget;
    private GameObject recentEnemy;
    void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            spawnPosition = new Vector3(-12.09f, 4, -0.138f);
        }
        else if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            spawnPosition = new Vector3(-12.09f, -3.5f, -0.138f);
        }
        else if (SceneManager.GetActiveScene().buildIndex == 3)
        {
            spawnPosition = new Vector3(-12.09f, 1.126f, -0.138f);
        }
        else if (SceneManager.GetActiveScene().buildIndex == 4)
        {
            spawnPosition = new Vector3(-7.825f, 5.92f, -0.138f);
        }
        spawnCountdown = spawnTime - firstSpawnOffset;
    }
    void Inst(string val)
    {
        GameObject type;
        if(val == "green")
        {
            type = green;
        }
        else if(val == "blue")
        {
            type = blue;
        }
        else if(val == "red")
        {
            type = red;
        }
        else if(val == "yellow")
        {
            type = yellow;
        }
        else if(val == "orange")
        {
            type = orange;
        }
        else if(val == "pink")
        {
            type = pink;
        }
        else if(val == "glimp")
        {
            type = glimp;
        }
        else if(val == "fighterget")
        {
            type = fighterget;
        }
        else
        {
            return;
        }
        recentEnemy = Instantiate(type, spawnPosition, Quaternion.identity);
        recentEnemy.GetComponent<move>().healthMoney = FindObjectOfType<healthMoney>();
        recentEnemy.GetComponent<move>().roundManager = FindObjectOfType<roundManager>();
    }
    void Spawn()
    {
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
                else
                {
                    Inst(round1[spawnCount]);
                }
            }
            else if (roundManager.round == 2)
            {
                if (spawnCount > round2.Length - 1)
                {
                    spawning = false;
                    spawnCount = -1;
                }
                else
                {
                    Inst(round2[spawnCount]);
                }
            }
            else if (roundManager.round == 3)
            {
                if (spawnCount > round3.Length - 1)
                {
                    spawning = false;
                    spawnCount = -1;
                }
                else
                {
                    Inst(round3[spawnCount]);
                }
            }
            else if (roundManager.round == 4)
            {
                if (spawnCount > round4.Length - 1)
                {
                    spawning = false;
                    spawnCount = -1;
                }
                else
                {
                    Inst(round4[spawnCount]);
                }
            }
            else if (roundManager.round == 5)
            {
                if (spawnCount > round5.Length - 1)
                {
                    spawning = false;
                    spawnCount = -1;
                }
                else
                {
                    Inst(round5[spawnCount]);
                }
            }
            else if (roundManager.round == 6)
            {
                if (spawnCount > round6.Length - 1)
                {
                    spawning = false;
                    spawnCount = -1;
                }
                else
                {
                    Inst(round6[spawnCount]);
                }
            }
            else if (roundManager.round == 7)
            {
                if (spawnCount > round7.Length - 1)
                {
                    spawning = false;
                    spawnCount = -1;
                }
                else
                {
                    Inst(round7[spawnCount]);
                }
            }
            else if (roundManager.round == 8)
            {
                if (spawnCount > round8.Length - 1)
                {
                    spawning = false;
                    spawnCount = -1;
                }
                else
                {
                    Inst(round8[spawnCount]);
                }
            }
            else if (roundManager.round == 9)
            {
                if (spawnCount > round9.Length - 1)
                {
                    spawning = false;
                    spawnCount = -1;
                }
                else
                {
                    Inst(round9[spawnCount]);
                }
            }
            else if (roundManager.round == 10)
            {
                if (spawnCount > round10.Length - 1)
                {
                    spawning = false;
                    spawnCount = -1;
                }
                else
                {
                    Inst(round10[spawnCount]);
                }
            }
            else if (roundManager.round == 11)
            {
                if (spawnCount > round11.Length - 1)
                {
                    spawning = false;
                    spawnCount = -1;
                }
                else
                {
                    Inst(round11[spawnCount]);
                }
            }
            else if (roundManager.round == 12)
            {
                if (spawnCount > round12.Length - 1)
                {
                    spawning = false;
                    spawnCount = -1;
                }
                else
                {
                    Inst(round12[spawnCount]);
                }
            }
            else if ( roundManager.round == 13)
            {
                if(spawnCount > round13.Length - 1)
                {
                    spawning = false;
                    spawnCount = -1;
                }
                else
                {
                    Inst(round13[spawnCount]);
                }
            }
            else if (roundManager.round == 14)
            {
                if(spawnCount > round14.Length - 1)
                {
                    spawning = false;
                    spawnCount = -1;
                }
                else{
                    Inst(round14[spawnCount]);
                }
            }
            else if (roundManager.round == 15)
            {
                if (spawnCount > round15.Length - 1)
                {
                    spawning = false;
                    spawnCount = -1;
                }
                else
                {
                    Inst(round15[spawnCount]);
                }
            }
            else if (roundManager.round == 16)
            {
                if (spawnCount > round16.Length - 1)
                {
                    spawning = false;
                    spawnCount = -1;
                }
                else
                {
                    Inst(round16[spawnCount]);
                }
            }
            else if (roundManager.round == 17)
            {
                if (spawnCount > round17.Length - 1)
                {
                    spawning = false;
                    spawnCount = -1;
                }
                else
                {
                    Inst(round17[spawnCount]);
                }
            }
            else if (roundManager.round == 18)
            {
                if (spawnCount > round18.Length - 1)
                {
                    spawning = false;
                    spawnCount = -1;
                }
                else
                {
                    Inst(round18[spawnCount]);
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