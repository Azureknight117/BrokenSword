using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int maxHealth;
    int currentHealth;
    public int damageAmount;
    SpriteRenderer sRenderer;
    Color spriteColor;
    Material mat;
    public float timeInvincible = 0.15f;

    public List<GameObject> drops;

    [HideInInspector]
    public bool isInvincible = false;
    public bool inRoom = false;

    private void Awake()
    {
        currentHealth = maxHealth;
        sRenderer = gameObject.GetComponent<SpriteRenderer>();
        mat = gameObject.GetComponent<SpriteRenderer>().material;
    }


    public void TakeDamage (int damage)
    {
        if (currentHealth - damage > 0)
        {
            currentHealth -= damage;
            isInvincible = true;
            StartCoroutine("Flash");
        }
        else
        {
            currentHealth = 0;
            Die();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Player")
        {
            Debug.Log("Player");
            collision.collider.GetComponent<PlayerManager>().TakeDamage(damageAmount);
        }
    }

    IEnumerator Flash()
    {

        float flash = 1f;
        mat.SetFloat("_FlashAmount", flash);
        yield return new WaitForSeconds(timeInvincible);
        mat.SetFloat("_FlashAmount", 0);
        isInvincible = false;
    }

    void DropItem()
    {
        int itemToDrop = Random.Range(0, drops.Count + 3);
        if(itemToDrop < drops.Count)
        {
            Instantiate(drops[itemToDrop], gameObject.transform.position, Quaternion.identity);
        }
        else
        {
            return;
        }
    }

    void Die()
    {
        DropItem();
        RoomController.instance.StartCoroutine(RoomController.instance.RoomCoroutine());
        Destroy(gameObject);
    }
}
