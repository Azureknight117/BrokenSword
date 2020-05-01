using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Exit : MonoBehaviour
{
    public SpriteRenderer spriteR;
    public Sprite openDoor;

    private void Update()
    {
        if(gameObject.GetComponent<BoxCollider2D>().enabled == true)
        {
            spriteR.sprite = openDoor;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            SceneManager.LoadScene("EndScreen");
        }
    }
}
