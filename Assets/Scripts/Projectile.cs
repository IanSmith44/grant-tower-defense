using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private GLOBALS GLOBALS;
    [SerializeField] private string[] targetTags;
    public Transform target;
    [SerializeField] private float trackingSpeed = 5f;
    public int shotby;
    public GameObject shotbyobj;
    private bool isTracking = true;
    private float dieabletime = 0.5f;
    private void Start()
    {
        GLOBALS = FindObjectOfType<GLOBALS>();
        targetTags = GLOBALS.targetTags;
    }
    void Update()
    {
        if (isTracking && target != null)
        {
            // Update the velocity to track the target
            Vector3 targetDir = target.position - transform.position;
            float angle = Mathf.Atan2(targetDir.y, targetDir.x) * Mathf.Rad2Deg;
            angle-=90f;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            GetComponent<Rigidbody2D>().velocity = transform.up * trackingSpeed;
        }
        else
        {
            Destroy(gameObject);
        }
        if (shotby == 3)
        {
            dieabletime -= Time.deltaTime;
            if (dieabletime <= -2)
            {
                Destroy(gameObject);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == shotbyobj && dieabletime <= 0f && shotby == 3)
        {
            Destroy(gameObject);
        }
        if (targetTags.Contains(collision.gameObject.tag))
        {
            if (shotby == 1)
            {
                collision.gameObject.GetComponent<move>().health -= 25;
            }
            else if (shotby == 2)
            {
                collision.gameObject.GetComponent<move>().health -= 55;
            }
            else if (shotby == 3)
            {
                if (collision.gameObject.transform == target)
                {
                    collision.gameObject.GetComponent<move>().health -= 35;
                    target = shotbyobj.transform;
                }
                else
                {
                    collision.gameObject.GetComponent<move>().health -= 25;
                }
                if ((collision.gameObject.GetComponent<move>().health <= 0 || gameObject.tag == "Glimp") && !collision.gameObject.GetComponent<move>().dead)
                {
                    collision.gameObject.GetComponent<move>().dead = true;
                    collision.gameObject.GetComponent<move>().pubDie(shotby);
                }
                return;
            }
            if ((collision.gameObject.GetComponent<move>().health <= 0 || collision.gameObject.tag == "Glimp") && !collision.gameObject.GetComponent<move>().dead)
            {
                collision.gameObject.GetComponent<move>().dead = true;
                collision.gameObject.GetComponent<move>().pubDie(shotby);
            }
            else if (shotby == 4 && collision.gameObject.transform == target)
            {
                collision.gameObject.GetComponent<move>().pubDie(shotby);
                return;
            }
            Destroy(gameObject);
        }
        else if (collision.gameObject.tag == "Tower" && gameObject.tag == "Grojectile")
        {
            collision.gameObject.GetComponent<tower>().HitByGrojectile();
            Destroy(gameObject);
        }
        
    }
}
