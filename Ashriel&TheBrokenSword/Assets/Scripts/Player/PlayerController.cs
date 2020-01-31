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
    public float attackTime;
    public PlayerManager manager;

    SpriteRenderer spriteR;

    Vector2 movement;
    Vector2 lastMove;
    float xDirection;
    float yDirection;

    public bool canMove = false;

    private void Start()
    {
        spriteR = gameObject.GetComponent<SpriteRenderer>();
    }

    public void ControllerStart()
    {
        canMove = true;
    }

    public void ControllerStop()
    {
        canMove = false;
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

        if (Input.GetAxisRaw("Horizontal") > .5f || Input.GetAxisRaw("Horizontal") < -.5f) 
        {
            lastMove.x = movement.x;
            lastMove.y = 0f;
        }
        if (Input.GetAxisRaw("Vertical") > .5f || Input.GetAxisRaw("Vertical") < -.5f)
        {
            lastMove.y = movement.y;
            lastMove.x = 0f;
        }

        if (movement != Vector2.zero)
        {
            anim.SetFloat("Horizontal", movement.x);
            anim.SetFloat("Vertical", movement.y);
        }

        anim.SetFloat("Speed", movement.sqrMagnitude);
        anim.SetFloat("LastHorizontal", lastMove.x);
        anim.SetFloat("LastVertical", lastMove.y);

        if (Input.GetButtonDown("Fire1"))
        {
            Attack();
            
        }
    }

    private void Move()
    {
        if (canMove)
        {
            rb.MovePosition(rb.position + movement.normalized * moveSpeed * Time.fixedDeltaTime);
        }
    }

    void Attack()
    {
        canMove = false;
        anim.SetBool("Attack", true);
        StartCoroutine("AttackTimer");
        manager.Sword.SwordSwing();
    }

    IEnumerator AttackTimer()
    {
        yield return new WaitForSeconds(attackTime);
        canMove = true;
        anim.SetBool("Attack", false);
        manager.Sword.StopSwing();
    }
}
