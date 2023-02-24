using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawn : MonoBehaviour
{
    [SerializeField] private float spawnTime = 1f;
    [SerializeField] private Vector3 spawnPosition = new Vector3(-12.09f, 4, -0.138f);
    [SerializeField] GameObject enemy;
    private GameObject recentEnemy;
    // Start is called before the first frame update
    void Start()
    {

    }
    void Spawn()
    {
        recentEnemy = Instantiate(enemy, spawnPosition, Quaternion.identity);
        recentEnemy.GetComponent<move>().healthMoney = FindObjectOfType<healthMoney>();
        recentEnemy.GetComponent<move>().roundManager = FindObjectOfType<roundManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (spawnTime <= 0)
        {
            Spawn();
            spawnTime = 2.1f;
        }
        else
        {
            spawnTime -= Time.deltaTime;
        }
    }
}
