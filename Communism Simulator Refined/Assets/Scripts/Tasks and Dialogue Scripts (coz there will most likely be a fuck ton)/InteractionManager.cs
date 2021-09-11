using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractionManager : MonoBehaviour
{
    [Header("References")]
    public Player player;
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


    public void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
    }
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
                    player.canMove = true;

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
        //PlayerText.text = Data.OpeningDialogue;
        StopAllCoroutines();
        StartCoroutine(AnimateSentence(Data.OpeningDialogue, PlayerText));

        dialogueActive = true;
        activedialogue = PlayerSpeechObject;
        clicks = 0;
        player.canMove = false;

    }

    public void PonderDialogue (string sentence)
    {
        //initiate Yaga thinking about whats missing

        PlayerSpeechObject.SetActive(true);
        StopAllCoroutines();
        StartCoroutine(AnimateSentence(sentence, PlayerText));

        dialogueActive = true;
        activedialogue = PlayerSpeechObject;
        clicks = 0;
        player.canMove = false;


    }


    public void ConcludingDialogue(InteractionData Data)
    {
        // initiates end dialogue
        PlayerSpeechObject.SetActive(true);
        //PlayerText.text = Data.ClosingDialogue;
        StopAllCoroutines();
        StartCoroutine(AnimateSentence(Data.ClosingDialogue, PlayerText));

        dialogueActive = true;
        activedialogue = PlayerSpeechObject;
        clicks = 0;

        isConclusion = true;
        concludingTask = Data.TaskID;
        player.canMove = false;

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

    public IEnumerator AnimateSentence(string dialogue, Text targettext)
    {
        targettext.text = "";

        foreach (char letter in dialogue.ToCharArray())
        {
            targettext.text += letter;
            yield return new WaitForSeconds(0.05f);
        }

    }
}
