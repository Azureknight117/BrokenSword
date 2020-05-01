using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterEnemy : Enemy
{
    public int moveSpeed;
    public float fireRate;
    public float range;
    float fireCountdown;
    bool isStunned = false;

    public GameObject bullet;
    Transform target;
    public bool isAttacking = true;

    Vector3 distance;
    float distanceFrom;
    

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }


    private void Update()
    {
        if (inRoom)
        {
            distance = (gameObject.transform.position - target.position);
            distanceFrom = distance.magnitude;
            distance /= distanceFrom;

            if (!isStunned)
            {
                if (distanceFrom < range)
                {
                    isAttacking = true;
                }
                else
                {
                    isAttacking = false;
                }
            }

            Attack();
        }
    }

    void Attack()
    {
        if (isAttacking)
        {
            if (fireCountdown <= 0)
            {
                Shoot();
                fireCountdown = 1f / fireRate;
            }
            fireCountdown -= Time.deltaTime;
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
        }
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

    IEnumerator Stun()
    {
        isStunned = true;
        yield return new WaitForSeconds(timeInvincible);
        isStunned = false;
    }

    void Shoot()
    {
        Instantiate(bullet, gameObject.transform.position, Quaternion.identity);
        
    }
}
