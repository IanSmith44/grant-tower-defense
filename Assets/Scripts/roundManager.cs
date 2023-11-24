using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class roundManager : MonoBehaviour
{
    [SerializeField] private Slider speed;
    public enemySpawn enemySpawn;
    private bool checkNextFrame = false;
    [SerializeField] private GameObject diePanel;
    public int round = 1;
    [SerializeField] private int enemiesCount = 0;
    private GameObject[] greenEnemies;
    private GameObject[] redEnemies;
    private GameObject[] blueEnemies;
    private GameObject[] orangeEnemies;
    private GameObject[] pinkEnemies;
    private GameObject[] yellowEnemies;
    private GameObject[] glimps;
    public GameObject[] enemiesList;
    void Start()
    {

    }

    public void EnemyDied()
    {
        checkNextFrame = true;
    }

    public void Die()
    {
        diePanel.SetActive(true);
    }

    void Update()
    {
        greenEnemies = GameObject.FindGameObjectsWithTag("Green");
        redEnemies = GameObject.FindGameObjectsWithTag("Red");
        blueEnemies = GameObject.FindGameObjectsWithTag("Blue");
        orangeEnemies = GameObject.FindGameObjectsWithTag("Orange");
        pinkEnemies = GameObject.FindGameObjectsWithTag("Pink");
        yellowEnemies = GameObject.FindGameObjectsWithTag("Yellow");
        glimps = GameObject.FindGameObjectsWithTag("Glimp");
        enemiesList = new GameObject[greenEnemies.Length + redEnemies.Length + blueEnemies.Length + orangeEnemies.Length + pinkEnemies.Length + yellowEnemies.Length + glimps.Length];
        greenEnemies.CopyTo(enemiesList, 0);
        redEnemies.CopyTo(enemiesList, greenEnemies.Length);
        blueEnemies.CopyTo(enemiesList, greenEnemies.Length + redEnemies.Length);
        orangeEnemies.CopyTo(enemiesList, greenEnemies.Length + redEnemies.Length + blueEnemies.Length);
        pinkEnemies.CopyTo(enemiesList, greenEnemies.Length + redEnemies.Length + blueEnemies.Length + orangeEnemies.Length);
        yellowEnemies.CopyTo(enemiesList, greenEnemies.Length + redEnemies.Length + blueEnemies.Length + orangeEnemies.Length + pinkEnemies.Length);
        glimps.CopyTo(enemiesList, greenEnemies.Length + redEnemies.Length + blueEnemies.Length + orangeEnemies.Length + pinkEnemies.Length + yellowEnemies.Length);
        enemiesCount = enemiesList.Length;
        if (checkNextFrame)
        {
            checkNextFrame = false;
            if (enemiesCount == 0)
            {
                round++;
                enemySpawn.roundOver = true;
            }
        }
        Time.timeScale = speed.value;
    }
}
