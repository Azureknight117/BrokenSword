using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float maxHealth;
    public float currentHealth;
    public int damageAmount;
    SpriteRenderer sRenderer;
    Color spriteColor;
    Material mat;
    public float timeInvincible = 0.15f;

    [HideInInspector]
    public bool isInvincible = false;

    private void Awake()
    {
        currentHealth = maxHealth;
        sRenderer = gameObject.GetComponent<SpriteRenderer>();
        mat = gameObject.GetComponent<SpriteRenderer>().material;
    }


    public void TakeDamage (float damage)
    {
        if (currentHealth - damage > 0)
        {
            currentHealth -= damage;
            isInvincible = true;
            StartCoroutine("Flash");
            Debug.Log(currentHealth);
        }
        else
        {
            currentHealth = 0;
            Die();
        }
    }

    IEnumerator Flash()
    {
        //bool isFlashing = false;
        float flash = 1f;
        mat.SetFloat("_FlashAmount", flash);
        yield return new WaitForSeconds(timeInvincible);
        /*isFlashing = true;
        float flash = 1f;
        while (isFlashing && flash >= 0)
        {
            flash -= Time.deltaTime * timeInvincible;
            mat.SetFloat("_FlashAmount", flash);
            yield return null;
        }
        isFlashing = false;*/
        mat.SetFloat("_FlashAmount", 0);
        isInvincible = false;
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
