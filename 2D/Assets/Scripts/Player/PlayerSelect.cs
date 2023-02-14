using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSelect : MonoBehaviour
{
    public bool enableSelectCharacter;
    public enum Player {Frog, Virtual, Pink, Mask}  //Tipo de dato para crear Objetos Enumerados
    public Player playerSelected;

    public Animator animator;
    public SpriteRenderer spriteRenderer;

    public RuntimeAnimatorController[] playerController;
    public Sprite[] playersRenderer;

    // Start is called before the first frame update
    void Start()
    {
        if (!enableSelectCharacter)
        {
            ChangePlayerInMenu();
        }
        else
        {


            switch (playerSelected)
            {
                case Player.Frog:
                    spriteRenderer.sprite = playersRenderer[0];
                    animator.runtimeAnimatorController = playerController[0];
                    break;
                case Player.Virtual:
                    spriteRenderer.sprite = playersRenderer[1];
                    animator.runtimeAnimatorController = playerController[1];
                    break;
                case Player.Pink:
                    spriteRenderer.sprite = playersRenderer[2];
                    animator.runtimeAnimatorController = playerController[2];
                    break;
                case Player.Mask:
                    spriteRenderer.sprite = playersRenderer[3];
                    animator.runtimeAnimatorController = playerController[3];
                    break;
            }
        }
    }

    public void ChangePlayerInMenu()
    {
        switch (PlayerPrefs.GetString("PlayerSelected"))
        {
            case "Frog":
                spriteRenderer.sprite = playersRenderer[0];
                animator.runtimeAnimatorController = playerController[0];
                break;
            case "Virtual":
                spriteRenderer.sprite = playersRenderer[1];
                animator.runtimeAnimatorController = playerController[1];
                break;
            case "Pink":
                spriteRenderer.sprite = playersRenderer[2];
                animator.runtimeAnimatorController = playerController[2];
                break;
            case "Mask":
                spriteRenderer.sprite = playersRenderer[3];
                animator.runtimeAnimatorController = playerController[3];
                break;
        }
    }

}
