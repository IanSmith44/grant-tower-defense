using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    private Transform target;
    [SerializeField] private float range = 3f;
    [SerializeField] private string[] targetTags;
    private bool speedUp = false;
    [SerializeField] private SpriteRenderer sr;
    [SerializeField] private enum EnemyType
    {
        Green,
        Blue,
        Red
    }
    [SerializeField] private EnemyType enemyType;
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
            enemyType = EnemyType.Green;
        }
        else if (this.tag == "Blue")
        {
            health = 200;
            enemyType = EnemyType.Blue;
        }
        else if (this.tag == "Red")
        {
            health = 400;
            enemyType = EnemyType.Red;
        }
        else
        {
            Debug.Log("Cannot Apply health because no valid enemy type detected");
        }
    }

    void pow()
    {
        float closestDistance = Mathf.Infinity;
        foreach (string tag in targetTags)
        {
            GameObject[] targets = GameObject.FindGameObjectsWithTag(tag);
            GameObject[] useableTargets;
            foreach (GameObject t in targets)
            {
                float distance = Vector3.Distance(transform.position, t.transform.position);
                if (distance < closestDistance && distance <= range)
                {
                    closestDistance = distance;
                    target = t.transform;
                }
            }
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
            enemyType = EnemyType.Green;
            healthMoney.money += 25;
        }
        else if (this.tag == "Red")
        {
            this.tag = "Blue";
            enemyType = EnemyType.Blue;
            pow();
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
            if (speedUp)
            {
                rb.velocity = new Vector2(2, 0);
            }
            else
            {
                rb.velocity = new Vector2(1, 0);
            }
        }
        else if (direction == Direction.Left)
        {
            if (speedUp)
            {
                rb.velocity = new Vector2(-2, 0);
            }
            else
            {
                rb.velocity = new Vector2(-1, 0);
            }
        }
        else if (direction == Direction.Up)
        {
            if (speedUp)
            {
                rb.velocity = new Vector2(0, 2);
            }
            else
            {
                rb.velocity = new Vector2(0, 1);
            }
        }
        else if (direction == Direction.Down)
        {
            if (speedUp)
            {
                rb.velocity = new Vector2(0, -2);
            }
            else
            {
                rb.velocity = new Vector2(0, -1);
            }
        }
        if (enemyType == EnemyType.Green)
        {
            sr.color = Color.green;
        }
        else if (enemyType == EnemyType.Blue)
        {
            sr.color = Color.blue;
        }
        else if (enemyType == EnemyType.Red)
        {
            sr.color = Color.red;
        }
        else
        {
            Debug.Log("Enemy type not in move.cs update function");
        }
        if (transform.position.x > -6.5f && transform.position.y < -3 && transform.position.x < 2.5f && transform.position.y > -4)
        {
            speedUp = true;
        }
        else
        {
            speedUp = false;
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
