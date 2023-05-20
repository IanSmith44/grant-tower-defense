using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileLauncher : MonoBehaviour
{
    [SerializeField] private tower tower;
    [SerializeField] private float fireInterval = 1f;
    private GameObject projectile;
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private string[] targetTags;
    [SerializeField] private float projectileSpeed = 10f;
    [SerializeField] private float range;

    private Transform target;

    void Start()
    {
        InvokeRepeating("FireProjectile", fireInterval, fireInterval);
    }

    void FireProjectile()
    {
        // Find the nearest target object within range
        float closestDistance = Mathf.Infinity;
        foreach (string tag in targetTags)
        {
            GameObject[] targets = GameObject.FindGameObjectsWithTag(tag);
            foreach (GameObject t in targets)
            {
                float distance = Vector3.Distance(transform.position, t.transform.position);
                if (distance < closestDistance)
                {
                    closestDistance = distance;
                    target = t.transform;
                }
            }
        }

        if (target != null && tower.placed == true && closestDistance <= range)
        {
            // Calculate the angle to the target
            Vector3 targetDir = target.position - transform.position;
            float angle = Mathf.Atan2(targetDir.y, targetDir.x) * Mathf.Rad2Deg;
            // Instantiate the projectile and aim at the target
            projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
            projectile.GetComponent<Rigidbody2D>().velocity = Quaternion.AngleAxis(angle, Vector3.forward) * Vector3.right * projectileSpeed;
            projectile.GetComponent<Projectile>().target = target;
            projectile.GetComponent<Projectile>().shotby = tower.type;
            target = null;
        }
    }
}
