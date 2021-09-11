using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractionManager : MonoBehaviour
{
    [Header("References")]
    public GameObject PlayerSpeechObject;
    public RectTransform PlayerSpeechBubble;
    public Text PlayerText;

    [Header("Interactables References")]
    public GameObject bridge;

    [Header("Other Variables")]
    public int concludingTask;
    public bool dialogueActive;
    public bool isConclusion;
    public int clicks;
    public GameObject activedialogue;

    public void Update()
    {
        if (dialogueActive)
        {
            if (Input.GetMouseButtonDown(0))
            {
                
                if (clicks == 1)
                {
                    dialogueActive = false;
                    activedialogue.SetActive(false);
                    clicks = 0;
                    
                    if (isConclusion)
                    {
                        ConcludeInteraction(concludingTask);
                        isConclusion = false;
                    }

                }
                else
                {
                    clicks++;
                }
                
            }
        }
    }

    public void OpeningDialogue (InteractionData Data)
    {
        //initiates opening dialogue
        PlayerSpeechObject.SetActive(true);
        PlayerText.text = Data.OpeningDialogue;

        dialogueActive = true;
        activedialogue = PlayerSpeechObject;
        clicks = 0;

    }


    public void ConcludingDialogue(InteractionData Data)
    {
        // initiates end dialogue
        PlayerSpeechObject.SetActive(true);
        PlayerText.text = Data.ClosingDialogue;

        dialogueActive = true;
        activedialogue = PlayerSpeechObject;
        clicks = 0;

        isConclusion = true;
        concludingTask = Data.TaskID;

    }
    public void ConcludeInteraction(int taskID)
    {
        Debug.Log("task " + taskID + " complete!");

        //for handling the effects of completed tasks - if any
        //is called after concluding dialogue
        //may initiate opening dialogue of next quest


        if (taskID == 0)
        {
            Debug.Log("bridge built");
            bridge.SetActive(false);
        }
        
    }
}
