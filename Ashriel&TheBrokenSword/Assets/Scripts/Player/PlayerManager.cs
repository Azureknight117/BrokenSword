using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    /* Manages the player character as a whole, hp, i-frames and such
     * 
     * */


    bool isInvincible;
    Material mat;
    float timeInvincible = 0.15f;

    public BoxCollider2D coll;
    public SwordManager Sword;

    public Image healthBar;
    public float maxHealth;
    float currentHealth;

    public PlayerController controlScript;
    bool gameStarted = false;

    void Start()
    {
        mat = gameObject.GetComponent<SpriteRenderer>().material;
        currentHealth = maxHealth;
    }

    public void StartGame()
    {
        gameStarted = true;
        controlScript.ControllerStart();
    }

    private void Update()
    {
        HealthManager();
    }

    public void TakeDamage(int damage)
    {
        if (!isInvincible && currentHealth - damage > 0)
        {
            currentHealth -= damage;
            isInvincible = true;
            //controlScript.ControllerStop();
            StartCoroutine("Flash");

        }
        else
        {
            currentHealth = 0;
            Die();
        }
    }

    void HealthManager()
    {
        healthBar.fillAmount = currentHealth / maxHealth;
    }

    void Die()
    {
        EndGame();
    }

    IEnumerator Flash()
    {

        float flash = 1f;
        mat.SetFloat("_FlashAmount", flash);
        yield return new WaitForSeconds(timeInvincible);
        mat.SetFloat("_FlashAmount", 0);
        isInvincible = false;
        //controlScript.ControllerStart();
    }

    public void EndGame()
    {
        gameStarted = false;
        controlScript.ControllerStop();
        SceneManager.LoadScene("DefeatScreen");
    }

    public void PauseGame()
    {
        controlScript.ControllerStop();
    }

    public void ResumeGame()
    {
        controlScript.ControllerStart();
    }
}
