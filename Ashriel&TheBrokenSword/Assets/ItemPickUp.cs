using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickUp : MonoBehaviour
{
    public Item pickup;
    public GameObject player;
    public SpriteRenderer sprite;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        sprite = gameObject.GetComponent<SpriteRenderer>();
        sprite.sprite = pickup.sprite;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            player.GetComponent<InventoryManager>().AddToList(pickup);
            Destroy(gameObject);
        }
    }
}
