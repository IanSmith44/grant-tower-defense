using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    public int health = 100;
    public healthMoney healthMoney;
    public roundManager roundManager;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private enum Direction
    {
        Right,
        Up,
        Down,
        Left

    }
    [SerializeField] private Direction direction;
    // Start is called before the first frame update
    void Start()
    {
        if (this.tag == "Green")
        {
            health = 100;
        }
        else if (this.tag == "Blue")
        {
            health = 200;
        }
        else if (this.tag == "Red")
        {
            health = 400;
        }
        else
        {
            Debug.Log("Cannot Apply health because no valid enemy type detected");
        }
    }

    void Die()
    {
        if (this.tag == "Green")
        {
            Destroy(gameObject);
            healthMoney.money += 15;
        }
        else if (this.tag == "Blue")
        {
            this.tag = "Green";
            healthMoney.money += 25;
        }
        else if (this.tag == "Red")
        {
            this.tag = "Blue";
            healthMoney.money += 45;
        }
        else
        {
            Debug.Log("Enemy type not in move.cs die function");
        }
        roundManager.EnemyDied();
    }
    // Update is called once per frame
    void Update()
    {
        if (direction == Direction.Right)
        {
            rb.velocity = new Vector2(1, 0);
        }
        else if (direction == Direction.Left)
        {
            rb.velocity = new Vector2(-1, 0);
        }
        else if (direction == Direction.Up)
        {
            rb.velocity = new Vector2(0, 1);
        }
        else if (direction == Direction.Down)
        {
            rb.velocity = new Vector2(0, -1);
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Right")
        {
            direction = Direction.Right;
        }
        else if (collision.gameObject.tag == "Left")
        {
            direction = Direction.Left;
        }
        else if (collision.gameObject.tag == "Up")
        {
            direction = Direction.Up;
        }
        else if (collision.gameObject.tag == "Down")
        {
            direction = Direction.Down;
        }
        else if (collision.gameObject.tag == "projectile")
        {
            if (health <= 0)
            {
                Die();
            }
            else
            {
                health -= 25;
            }
        }
        if (collision.gameObject.tag == "End")
        {
            if (this.tag == "Green")
            {
                healthMoney.health -= 1;
            }
            else if (this.tag == "Blue")
            {
                healthMoney.health -= 2;
            }
            else if (this.tag == "Red")
            {
                healthMoney.health -= 3;
            }
            else
            {
                Debug.Log("cannot remove health because enemy type is not recognized by move.cs");
            }
            Destroy(gameObject);
            roundManager.EnemyDied();
        }
    }
}
