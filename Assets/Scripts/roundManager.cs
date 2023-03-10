using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class roundManager : MonoBehaviour
{
    [SerializeField] public enemySpawn enemySpawn;
    private bool checkNextFrame = false;
    [SerializeField] private GameObject diePanel;
    public int round = 1;
    [SerializeField] private int enemiesCount = 0;
    private GameObject[] greenEnemies;
    private GameObject[] redEnemies;
    private GameObject[] blueEnemies;
    public GameObject[] enemiesList;
    void Start()
    {

    }

    public void EnemyDied()
    {
        /*if (enemiesCount == 0)
        {*/
            checkNextFrame = true;
        //}
    }

    public void Die()
    {
        diePanel.SetActive(true);
    }

    void Update()
    {
        /*
        var z = new int[x.Length + y.Length];
        x.CopyTo(z, 0);
        y.CopyTo(z, x.Length);
        */
        greenEnemies = GameObject.FindGameObjectsWithTag("Green");
        redEnemies = GameObject.FindGameObjectsWithTag("Red");
        blueEnemies = GameObject.FindGameObjectsWithTag("Blue");
        enemiesList = new GameObject[greenEnemies.Length + redEnemies.Length + blueEnemies.Length];
        greenEnemies.CopyTo(enemiesList, 0);
        redEnemies.CopyTo(enemiesList, greenEnemies.Length);
        blueEnemies.CopyTo(enemiesList, greenEnemies.Length + redEnemies.Length);
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
    }
}
