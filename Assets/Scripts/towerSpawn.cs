using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class towerSpawn : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI tower1txt;
    [SerializeField] private TextMeshProUGUI tower2txt;
    [SerializeField] private GameObject tower1;
    [SerializeField] private GameObject tower2;
    [SerializeField] private GameObject tower3;
    [SerializeField] private int tower1cost = 100;
    [SerializeField] private int tower2cost = 355;
    [SerializeField] private int tower3cost = 750;
    private GameObject recentTower;
    [SerializeField] private healthMoney healthMoney;
    void Update()
    {
        if(healthMoney.money < tower1cost)
        {
            tower1txt.color = new Color(1f, 0f, 0f);
        }
        else
        {
            tower1txt.color = new Color(1f, 1f, 1f);
        }
        if(healthMoney.money < tower2cost)
        {
            tower2txt.color = new Color(1f, 0f, 0f);
        }
        else
        {
            tower2txt.color = new Color(1f, 1f, 1f);
        }
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
