using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaserEnemy : Enemy
{
    public int moveSpeed;
    Transform target;
    public bool isChasing = true;

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }


    private void Update()
    {
        if (isChasing)
        {
            if (inRoom)
            {
                Chase();
            }
        }
    }

    void Chase()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!isInvincible)
        {
            if (collision.tag == "Sword")
            {
                StartCoroutine("Stun");
                TakeDamage(collision.GetComponent<SwordManager>().totalDamage);
            }
            else if (collision.tag == "SwordPiece")
            {
                StartCoroutine("Stun");
                TakeDamage(collision.GetComponent<SwordPieceManager>().power);
            }
        }
    }

    IEnumerator  Stun()
    {
        isChasing = false;
        yield return new WaitForSeconds(timeInvincible);
        isChasing = true;
    }
}
