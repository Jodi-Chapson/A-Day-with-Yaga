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
    

    public Texture2D cursordefault;
    public Texture2D cursorpickup;
    public Texture2D cursorpickup_transparent;
    public Texture2D cursorinteract;
    public Texture2D cursorinteract_transparent;
    public int cursorstate; // 0 = default, 1 = pickup, 2 = interactable
    public CursorMode mode = CursorMode.Auto;



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

        if (cursorstate == 0)
        {
            Cursor.SetCursor(cursordefault, Vector2.zero, mode);
        }
        else if (cursorstate == 1)
        {
            Cursor.SetCursor(cursorpickup, Vector2.zero, mode);
        }
        else if (cursorstate == 2)
        {
            Cursor.SetCursor(cursorpickup_transparent, Vector2.zero, mode);
        }
        else if (cursorstate == 3)
        {
            Cursor.SetCursor(cursorinteract, Vector2.zero, mode);

        }
        else if (cursorstate == 4)
        {
            Cursor.SetCursor(cursorinteract_transparent, Vector2.zero, mode);
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
