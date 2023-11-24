using System;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class move : MonoBehaviour
{
    [SerializeField] private float fireInterval = 1f;
    [SerializeField] private float projectileSpeed;
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private float minmovespeed;
    [SerializeField] private float maxmovespeed;
    private float movespeed;
    private Transform target;
    public bool dead = false;
    [SerializeField] private string[] targetTags;
    private bool speedUp = false;
    [SerializeField] private SpriteRenderer sr;
    [SerializeField] private GameObject Pinkprefab;
    private GameObject recentSpawn;
    public int health;
    public healthMoney healthMoney;
    public roundManager roundManager;
    [SerializeField] private Rigidbody2D rb;
    private bool slow = false;
    private float originalMoveSpeed;
    public float slowtime;
    [SerializeField] private GameObject Glu;
    [SerializeField] private float GluTime = 3f;
    public enum Direction
    {
        Right,
        Up,
        Down,
        Left
    }
    public Direction direction;
    // Start is called before the first frame update
    void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex == 3 || SceneManager.GetActiveScene().buildIndex == 4)
        {
            transform.localScale = transform.localScale / 1.4f;
        }
        healthMoney = FindObjectOfType<healthMoney>();
        roundManager = FindObjectOfType<roundManager>();
        StartFiring();
        movespeed = UnityEngine.Random.Range(minmovespeed, maxmovespeed);
        originalMoveSpeed = movespeed;
    }

    void pow()
    {
        float closestDistance = Mathf.Infinity;
        foreach (string tag in targetTags)
        {
            GameObject[] targets = GameObject.FindGameObjectsWithTag(tag);
            foreach (GameObject t in targets)
            {
                float distance = Vector3.Distance(transform.position, t.transform.position);
                if (distance < closestDistance)
                {
                    //Debug.Log(distance);
                    closestDistance = distance;
                    target = t.transform;
                }
            }
        }
        if (target != null)
        {
            // Calculate the angle to the target
            Vector3 targetDir = target.position - transform.position;
            float angle = Mathf.Atan2(targetDir.y, targetDir.x) * Mathf.Rad2Deg;
            // Instantiate the projectile and aim at the target
            GameObject projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
            projectile.GetComponent<Rigidbody2D>().velocity = Quaternion.AngleAxis(angle, Vector3.forward) * Vector3.right * projectileSpeed;
            projectile.GetComponent<Projectile>().target = target;
            projectile.GetComponent<Projectile>().shotby = -1;
            target = null;
        }
    }
    public void pubDie(int type)
    {
        if(type == 4)
        {
            slow = true;
            movespeed = originalMoveSpeed / 2;
            slowtime = GluTime;
        }
        else
        {
            StartCoroutine(Die());
        }
    }
    IEnumerator Die()
    {
        if (this.tag == "Green")
        {
            healthMoney.money += 15;
            Destroy(gameObject);
        }
        else if (this.tag == "Blue")
        {
            healthMoney.money += 20;
            Destroy(gameObject);
        }
        else if (this.tag == "Red")
        {
            healthMoney.money += 25;
            Destroy(gameObject);
        }
        else if (this.tag == "Yellow")
        {
            healthMoney.money += 30;
            Destroy(gameObject);
        }
        else if (this.tag == "Orange")
        {
            healthMoney.money += 40;
            Destroy(gameObject);
        }
        else if (this.tag == "Pink")
        {
            CancelInvoke("pow");
            healthMoney.money += 50;
            Destroy(gameObject);
        }
        else if (this.tag == "Glimp")
        {
            for(int i = 0; i < 3; i++)
            {
                yield return new WaitForSeconds(0.5f);
                recentSpawn = Instantiate(Pinkprefab, transform.position, Quaternion.identity);
                recentSpawn.GetComponent<move>().direction = direction;
                recentSpawn.GetComponent<move>().StartFiring();
                recentSpawn.GetComponent<move>().health = 650;
            }
            Destroy(gameObject);
        }
        else
        {
            Debug.Log("Enemy type not in move.cs die function");
        }
        roundManager.EnemyDied();
    }
    public void StartFiring()
    {
        InvokeRepeating("pow", fireInterval, fireInterval);
    }
    void Update()
    {
        if(slow)
        {
            Glu.GetComponent<SpriteRenderer>().enabled = true;
            slowtime -= Time.deltaTime;
            if(slowtime <= 0)
            {
                slow = false;
            }
        }
        else
        {
            Glu.GetComponent<SpriteRenderer>().enabled = false;
            movespeed = originalMoveSpeed;
        }
        if (direction == Direction.Right)
        {
            if (speedUp)
            {
                rb.velocity = new Vector2(movespeed*2,0);
            }
            else
            {
                rb.velocity = new Vector2(movespeed, 0);
            }
        }
        else if (direction == Direction.Left)
        {
            if (speedUp)
            {
                    rb.velocity = new Vector2(movespeed*-2,0);
            }
            else
            {
                rb.velocity = new Vector2(movespeed*-1, 0);
            }
        }
        else if (direction == Direction.Up)
        {
            if (speedUp)
            {
                rb.velocity = new Vector2(0, movespeed*2);
            }
            else
            {
                rb.velocity = new Vector2(0, movespeed);
            }
        }
        else if (direction == Direction.Down)
        {
            if (speedUp)
            {
                rb.velocity = new Vector2(0, movespeed*-2);
            }
            else
            {
                rb.velocity = new Vector2(0, movespeed*-1);
            }
        }
        if (transform.position.x > -6.5f && transform.position.y < -3 && transform.position.x < 2.5f && transform.position.y > -4)
        {
            if (SceneManager.GetActiveScene().buildIndex == 1 || SceneManager.GetActiveScene().buildIndex == 2)
            {
                speedUp = true;
            }
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
        if (collision.gameObject.tag == "End")
        {
            if (this.tag == "Green")
            {
                healthMoney.health -= 15;
            }
            else if (this.tag == "Blue")
            {
                healthMoney.health -= 20;
            }
            else if (this.tag == "Red")
            {
                healthMoney.health -= 25;
            }
            else if (this.tag == "Orange")
            {
                healthMoney.health -= 30;
            }
            else if (this.tag == "Yellow")
            {
                healthMoney.health -= 35;
            }
            else if (this.tag == "Pink")
            {
                healthMoney.health -= 40;
            }
            else if (this.tag == "Glimp")
            {
                healthMoney.health -= 65;
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
