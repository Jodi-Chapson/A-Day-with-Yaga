using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("References")]
    public Player player;
    public InteractionManager im;
    public GameObject packUI, packButton;
    public Texture packOpen, packClosed;



    public void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
        im = this.gameObject.GetComponent<InteractionManager>();
    }


    public void Update()
    {
        if (im.dialogueActive)
        {
            packButton.SetActive(false);
        }
        else
        {
            packButton.SetActive(true);
        }

        if (Input.GetKeyDown("q") || Input.GetKeyDown("escape"))
        {
            BackpackState();
        }



    }

    public void BackpackState()
    {
        //checks what state the backpack is in
        if (packUI.activeSelf == true)
        {
            CloseBackpack();
        }
        else
        {
            OpenBackpack();
        }
    }


    public void OpenBackpack()
    {
        //open backpack UI
        player.canMove = false;
        packButton.GetComponent<RawImage>().texture = packOpen;
        packUI.SetActive(true);


    }

    public void CloseBackpack()
    {
        //close backpack UI
        player.canMove = true;
        packButton.GetComponent<RawImage>().texture = packClosed;
        packUI.SetActive(false);


    }

}
