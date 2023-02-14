using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangePlayer : MonoBehaviour
{
    public GameObject skinsPanel;
    private bool inDoor;
    public GameObject player;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            skinsPanel.gameObject.SetActive(true);
            inDoor = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            skinsPanel.gameObject.SetActive(false);
            inDoor = false;
        }
    }

    public void SetPlayerFrog()
    {
        PlayerPrefs.SetString("PlayerSelecter", "Frog");
        ResetPlayerSkin();
    }

    public void SetPlayerMask()
    {
        PlayerPrefs.SetString("PlayerSelecter", "Mask");
        ResetPlayerSkin();
    }

    public void SetPlayerVirtual()
    {
        PlayerPrefs.SetString("PlayerSelecter", "Virtual");
        ResetPlayerSkin();
    }

    public void SetPlayerPink()
    {
        PlayerPrefs.SetString("PlayerSelecter", "Pink");
        ResetPlayerSkin();
    }

    void ResetPlayerSkin()
    {
        skinsPanel.gameObject.SetActive(false);
        player.GetComponent<PlayerSelect>().ChangePlayerInMenu();
    }
}
