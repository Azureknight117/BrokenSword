using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health;
    public int damageAmount;
    SpriteRenderer sRenderer;
    Color spriteColor;
    Material mat;
    public float timeInvincible = 0.15f;

    bool isInvincible = false;
    


    private void Start()
    {
        sRenderer = gameObject.GetComponent<SpriteRenderer>();
        mat = gameObject.GetComponent<SpriteRenderer>().material;
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Sword" && !isInvincible)
        {
            Debug.Log("hit");
            isInvincible = true;
            StartCoroutine("Flash");
        }
    }

    IEnumerator Flash()
    {
        bool isFlashing = false;
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
}
