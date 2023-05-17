using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class towerSpawn : MonoBehaviour
{
    [SerializeField] private GameObject tower1;
    [SerializeField] private GameObject tower2;
    [SerializeField] private GameObject tower3;
    [SerializeField] private int tower1cost = 150;
    [SerializeField] private int tower2cost = 355;
    [SerializeField] private int tower3cost = 750;
    private GameObject recentTower;
    [SerializeField] private healthMoney healthMoney;
    // Start is called before the first frame update
    void Start()
    {

    }

    public void Tower1()
    {
        if (healthMoney.money >= tower1cost)
        {
            healthMoney.money -= tower1cost;
            Instantiate(tower1, transform.position, Quaternion.identity);
        }
    }
    public void Tower2()
    {
        if(healthMoney.money >= tower2cost)
        {
            healthMoney.money -= tower2cost;
            Instantiate(tower2, transform.position, Quaternion.identity);
        }
    }
    public void Tower3()
    {
        if(healthMoney.money >= tower3cost)
        {
            healthMoney.money -= tower3cost;
            Instantiate(tower3, transform.position, Quaternion.identity);
        }
    }
}
