using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public Transform target;
    [SerializeField] private float trackingSpeed = 5f;

    private bool isTracking = true;

    void Update()
    {
        if (isTracking && target != null)
        {
            // Update the velocity to track the target
            Vector3 targetDir = target.position - transform.position;
            float angle = Mathf.Atan2(targetDir.y, targetDir.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            GetComponent<Rigidbody2D>().velocity = transform.right * trackingSpeed;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
