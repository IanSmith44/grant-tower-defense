using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class healthMoney : MonoBehaviour
{
    [SerializeField] private roundManager roundManager;
    [SerializeField] private TextMeshProUGUI healthObject;
    [SerializeField] private TextMeshProUGUI moneyObject;
    public int health = 150;
    public int money = 100;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            health = 0;
            roundManager.Die();
        }
        healthObject.text = "Health: " + health;
        moneyObject.SetText("Money: " + money);
    }
}
