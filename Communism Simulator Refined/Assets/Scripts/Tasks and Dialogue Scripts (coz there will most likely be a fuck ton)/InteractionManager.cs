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
    public GameObject BettySpeechObject;
    public GameObject BettySpeechBubble;
    public Text PlayerText;
    public Text BettyText;

    [Header("Interactables References")]
    public GameObject bridge;
    public GameObject BettyTaskID2;
    public GameObject BettyTaskID3;
    public GameObject BettyTaskID6;

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

        if (Data.OpeningCharacterID == 0)
        {
            //player speaking
            PlayerSpeechObject.SetActive(true);
            StopAllCoroutines();
            StartCoroutine(AnimateSentence(Data.OpeningDialogue, PlayerText));

            dialogueActive = true;
            activedialogue = PlayerSpeechObject;
            clicks = 0;
            player.canMove = false;




        }
        else if (Data.OpeningCharacterID == 1)
        {
            //betty speaking

            BettySpeechObject.SetActive(true);
            StopAllCoroutines();
            StartCoroutine(AnimateSentence(Data.OpeningDialogue, BettyText));

            dialogueActive = true;
            activedialogue = BettySpeechObject;
            clicks = 0;
            player.canMove = false;
        }
        

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

        if (Data.OpeningCharacterID == 0)
        {
            PlayerSpeechObject.SetActive(true);

            StopAllCoroutines();
            StartCoroutine(AnimateSentence(Data.ClosingDialogue, PlayerText));

            dialogueActive = true;
            activedialogue = PlayerSpeechObject;
            clicks = 0;

            isConclusion = true;
            concludingTask = Data.TaskID;
            player.canMove = false;
        }
        else if (Data.OpeningCharacterID == 1)
        {
            BettySpeechObject.SetActive(true);

            StopAllCoroutines();
            StartCoroutine(AnimateSentence(Data.ClosingDialogue, BettyText));

            dialogueActive = true;
            activedialogue = BettySpeechObject;
            clicks = 0;

            isConclusion = true;
            concludingTask = Data.TaskID;
            player.canMove = false;
        }
            
        

    }
    public void ConcludeInteraction(int taskID)
    {
        Debug.Log("task " + taskID + " complete!");

        //for handling the effects of completed tasks - if any
        //is called after concluding dialogue
        //may initiate opening dialogue of next quest

        if (taskID == 2)
        {
            //Betty task 1
            BettyTaskID2.SetActive(false);
            BettyTaskID3.SetActive(true);
            StartCoroutine(BettyPause(1));
            
        }
        else if (taskID == 3)
        {
            //Betty task 2
            BettyTaskID3.SetActive(false);
            BettyTaskID6.SetActive(true);
            StartCoroutine(BettyPause(2));
            

        }
        
        
    }

    public IEnumerator BettyPause(int task)
    {
        
        yield return new WaitForSeconds(0.1f);
        if (task == 1)
        {
            BettyTaskID3.GetComponent<Interactables>().TriggerInteraction();
        }
        else if (task == 2)
        {
            BettyTaskID6.GetComponent<Interactables>().TriggerInteraction();
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
