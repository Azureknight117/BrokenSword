using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    public Transform target;
    public float moveSpeed;
    public int damage;
    public float closeRange = 2f;
    public float timeSpentAround = 3f;
    Vector3 distance;
    Vector3 dir;
    bool straight = false;
    private void Awake()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        dir = target.position;
        Destroy(gameObject, timeSpentAround);
    }

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, dir, moveSpeed * Time.deltaTime);
    }

     void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player")
        {
            Debug.Log("Player");
            collision.collider.GetComponent<PlayerManager>().TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
