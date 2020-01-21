using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    /* Manages the player character as a whole, hp, i-frames and such
     * 
     * */

    public int health;
    bool isInvincible;
    public BoxCollider2D coll;
   

    PlayerController controlScript;
    bool gameStarted = false;
    void Start()
    {
        
    }

    public void StartGame()
    {
        gameStarted = true;
        controlScript.ControllerStart();
    }
}
