using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class towerSpawn : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI tower1txt;
    [SerializeField] private TextMeshProUGUI tower2txt;
    [SerializeField] private TextMeshProUGUI tower3txt;
    [SerializeField] private TextMeshProUGUI tower4txt;
    [SerializeField] private GameObject tower1;
    [SerializeField] private GameObject tower2;
    [SerializeField] private GameObject tower3;
    [SerializeField] private GameObject tower4;
    [SerializeField] private int tower1cost = 110;
    [SerializeField] private int tower2cost = 350;
    [SerializeField] private int tower3cost = 250;
    [SerializeField] private int tower4cost = 50;
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
        if (healthMoney.money < tower2cost)
        {
            tower2txt.color = new Color(1f, 0f, 0f);
        }
        else
        {
            tower2txt.color = new Color(1f, 1f, 1f);
        }
        if (healthMoney.money < tower3cost)
        {
            tower3txt.color = new Color(1f, 0f, 0f);
        }
        else
        {
            tower3txt.color = new Color(1f, 1f, 1f);
        }
        if (healthMoney.money < tower4cost)
        {
            tower4txt.color = new Color(1f, 0f, 0f);
        }
        else
        {
            tower4txt.color = new Color(1f, 1f, 1f);
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
    public void Tower4()
    {
        if (healthMoney.money >= tower4cost)
        {
            healthMoney.money -= tower4cost;
            Instantiate(tower4, transform.position, Quaternion.identity);
        }
    }
}
