using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class towerSpawn : MonoBehaviour
{
    [SerializeField] private GameObject tower1;
    [SerializeField] private GameObject tower2;
    private GameObject recentTower;
    [SerializeField] private healthMoney healthMoney;
    // Start is called before the first frame update
    void Start()
    {

    }

    public void Tower1()
    {
        if (healthMoney.money >= 85)
        {
            healthMoney.money -= 85;
            Instantiate(tower1, transform.position, Quaternion.identity);
        }
    }
    public void Tower2()
    {
        if(healthMoney.money >= 125)
        {
            healthMoney.money -= 125;
            Instantiate(tower2, transform.position, Quaternion.identity);
        }
    }
    // Update is called once per frame
    void Update()
    {

    }
}
