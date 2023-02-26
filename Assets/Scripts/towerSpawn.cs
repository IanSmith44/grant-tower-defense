using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class towerSpawn : MonoBehaviour
{
    [SerializeField] private GameObject tower1;
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
            recentTower = Instantiate(tower1, transform.position, Quaternion.identity);
        }
    }
    // Update is called once per frame
    void Update()
    {

    }
}
