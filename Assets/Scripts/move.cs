using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
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
        /*rb = GetComponent<Rigidbody2D>();
        direction = Direction.Right;*/
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
                Debug.Log("No valid enemy type selected");
            }
            Destroy(gameObject);
            roundManager.EnemyDied();
        }
    }
}
