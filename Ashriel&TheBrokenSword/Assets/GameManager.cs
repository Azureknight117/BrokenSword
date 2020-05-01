using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public PlayerManager player;
    public SwordManager sword;
    public GameObject invenUI;
    public InventoryManager inventory;


    public GameObject pauseMenu;

    public bool paused = false;
    public bool menuUp = false;



    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(!paused)
            {
                PauseGame();
            }
            else
            {
                ResumeGame();
            }
        }

        OpenMenu();

    }

    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        paused = true;
    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        paused = false;
    }

    void OpenMenu()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (!menuUp)
            {
                invenUI.SetActive(true);
                player.PauseGame();
                menuUp = true;
            }
            else
            {
                if(inventory.GetComponent<InventoryManager>().inventorySlots[10].item != null)
                {
                    SetNewSwordPieces();                  
                }
                else
                {
                    RemoveSwordPieces();
                }
                invenUI.SetActive(false);
                player.ResumeGame();
                menuUp = false;
            }
        }
    }

    void SetNewSwordPieces()
    {
        SwordPiece newMid = inventory.GetComponent<InventoryManager>().inventorySlots[10].item as SwordPiece;
        sword.midPiece.GetComponent<SwordPieceManager>().SetSwordPiece(newMid);
        if (inventory.GetComponent<InventoryManager>().inventorySlots[9].item != null)
        {
            SwordPiece newTip = inventory.GetComponent<InventoryManager>().inventorySlots[9].item as SwordPiece;
            sword.tipPiece.GetComponent<SwordPieceManager>().SetSwordPiece(newTip);
        }
    }
    void RemoveSwordPieces()
    {
        sword.midPiece.GetComponent<SwordPieceManager>().SetSwordPiece(null);
        sword.tipPiece.GetComponent<SwordPieceManager>().SetSwordPiece(null);
    }

    public void QuitGame()
    {
        UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }
}
