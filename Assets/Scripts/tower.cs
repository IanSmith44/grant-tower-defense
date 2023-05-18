using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class tower : MonoBehaviour
{
    public int type;
    [SerializeField] private SpriteRenderer circleSprite;
    private Vector3 mousePosition;
    public bool placed = false;
    // Start is called before the first frame update
    void Start()
    {

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


    // Update is called once per frame
    void Update()
    {
        if (!placed)
        {
            circleSprite.enabled = true;
            transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) + new Vector3(0f, 0f, 1f);
        }
        if (placed)
        {
            circleSprite.enabled = false;
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Grojectile")
        {
            Destroy(gameObject);
        }
    }
}
