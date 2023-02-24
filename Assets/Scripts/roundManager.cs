using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class roundManager : MonoBehaviour
{
    [SerializeField] private GameObject diePanel;
    [SerializeField] private int round = 1;
    private int enemiesCount = 0;
    public GameObject[] enemiesList;
    void Start()
    {

    }

    public void EnemyDied()
    {
        if (enemiesCount == 0)
        {
            round++;
        }
    }

    public void Die()
    {
        diePanel.SetActive(true);
    }

    void Update()
    {
        enemiesList = GameObject.FindGameObjectsWithTag("Green");
        enemiesCount = enemiesList.Length;
    }
}
