using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    /* Controls player's movement and basic attacks and stuff
     * 
     * */
    public float moveSpeed = 5f;

    public Rigidbody2D rb;
    public Animator anim;

    SpriteRenderer spriteR;

    Vector2 movement;

    private void Start()
    {
        spriteR = gameObject.GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        GetInput();
    }
    void FixedUpdate()
    {
        Move();
    }

    void GetInput()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        if (movement != Vector2.zero)
        {
            anim.SetFloat("Horizontal", movement.x);
            anim.SetFloat("Vertical", movement.y);
        }
        anim.SetFloat("Speed", movement.sqrMagnitude);
    }

    private void Move()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
/*
 * 
 * if (movement != Vector2.zero) {
      animator.SetFloat("Horizontal", movement.x);
      animator.SetFloat("Vertical", movement.y);
}
*/