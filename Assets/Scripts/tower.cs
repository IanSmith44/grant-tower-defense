using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class tower : MonoBehaviour
{
    private bool OnPath = false;
    [SerializeField] private Rigidbody2D rb;
    public bool mouseover;
    public int type;
    [SerializeField] private SpriteRenderer circleSprite;
    private Vector3 mousePosition;
    public bool placed = false;
    private int health = 100;
    private void OnMouseEnter()
    {
        mouseover = true;
    }
    private void OnMouseExit()
    {
        mouseover = false;
    }
    public void Place(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            placed = true;
        }
    }
    public void PlaceTouch(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            placed = true;
        }
    }
    void Update()
    {
        if(health <= 0)
        {
            Destroy(gameObject);
        }
        if(OnPath)
        {
            placed = false;
        }
        if (!placed)
        {
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
            circleSprite.enabled = true;
            transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) + new Vector3(0f, 0f, 1f);
        }
        else if(mouseover == true)
        {
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
            circleSprite.enabled = true;
        }
        else
        {
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
            circleSprite.enabled = false;
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Grojectile")
        {
            health-=25;
        }
        else if(collision.gameObject.tag == "Path")
        {
            OnPath = true;
        }
    }
    void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Path")
        {
            OnPath = false;
        }
    }
}
