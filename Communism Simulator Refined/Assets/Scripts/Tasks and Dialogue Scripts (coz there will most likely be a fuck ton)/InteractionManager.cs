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
    public GameObject particles;

    public GameObject bridgefix;
    public GameObject bridgebroke;

    public GameObject fireplacefix;

    public Vector3 chairpos;
    public GameObject chair;
    public GameObject rod;

    public GameObject BettyTaskID2;
    public GameObject BettyTaskID3;
    public GameObject BettyTaskID6;
    

    [Header("Other Variables")]
    public int concludingTask;
    public bool dialogueActive;
    public bool isConclusion;
    public GameObject activedialogue;
    public Queue<int> speakerID;
    public Queue<string> dialogue;
    public bool firsttext;
    public bool immediateeffect;
    public int taskcounter;


    public void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
        speakerID = new Queue<int>();
        dialogue = new Queue<string>();
        taskcounter = 0;
    }
    public void Update()
    {
        //if (dialogueActive)
        //{
        //    player.canMove = false;
        //}
        //else
        //{
        //    player.canMove = true;
        //}
        
        
        
    }

    

    public void LateUpdate()
    {
        if (dialogueActive)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (firsttext)
                {
                    firsttext = false;

                    return;

                    
                    
                }

                NextDialogue();

                
                
                
            }
        }
    }

    public void StartDialogue (int type, InteractionData Data)
    {
        //initiates dialogue
        immediateeffect = Data.immediateeffect;
        speakerID.Clear();
        dialogue.Clear();
        firsttext = true;

        if (type == 0)
        {
            //opening dialogue
            //loads the appropriate dialogue

            foreach (int id in Data.OpeningCharacterID)
            {
                speakerID.Enqueue(id);
            }
            
            foreach (string sentence in Data.OpeningDialogue)
            {
                dialogue.Enqueue(sentence);
                
            }


            NextDialogue();
            dialogueActive = true;
            


        }
        else if (type == 1)
        {
            //closing dialogue

            foreach (int id in Data.ClosingCharacterID)
            {
                speakerID.Enqueue(id);
            }

            foreach (string sentence in Data.ClosingDialogue)
            {
                dialogue.Enqueue(sentence);
            }

            isConclusion = true;
            concludingTask = Data.TaskID;


            NextDialogue();
            dialogueActive = true;
            
            
        }
        

    }

    public void NextDialogue()
    {

        player.canMove = false;
        
        if (dialogue.Count == 1)
        {
            //on the last speech bubble
            if (immediateeffect && isConclusion)
            {
                ConcludeInteraction(concludingTask);
                isConclusion = false;
            }
        }

        if (dialogue.Count == 0)
        {
            //end the dialogue
            EndDialogue();
            return;
        }

        string sentence = dialogue.Dequeue();
        int id = speakerID.Dequeue();

        if (id == 0)
        {
            //yaga is speaking

            PlayerSpeechObject.SetActive(true);
            activedialogue = PlayerSpeechObject;
            if (BettySpeechObject.activeSelf == true)
            {
                BettySpeechObject.SetActive(false);
            }

            StopAllCoroutines();
            StartCoroutine(AnimateSentence(sentence, PlayerText));

        }
        else if (id == 1)
        {
            //betty is speaking

            BettySpeechObject.SetActive(true);
            activedialogue = BettySpeechObject;
            if (PlayerSpeechObject.activeSelf == true)
            {
                 PlayerSpeechObject.SetActive(false);
            }

            StopAllCoroutines();
            StartCoroutine(AnimateSentence(sentence, BettyText));

        }

    }

    public void EndDialogue()
    {
        activedialogue.SetActive(false);
        dialogueActive = false;
        player.canMove = true;
        


        if (isConclusion)
        {
            ConcludeInteraction(concludingTask);
            isConclusion = false;
        }
    }



    public void ConcludeInteraction(int taskID)
    {
        Debug.Log("task " + taskID + " complete!");

        if (this.gameObject.GetComponent<GameManager>().cursorstate == 2)
        {
            this.gameObject.GetComponent<GameManager>().cursorstate = 0;
        }


        //for handling the effects of completed tasks - if any
        //is called after concluding dialogue
        //may initiate opening dialogue of next quest
        if (taskID == 0)
        {
            taskcounter++;
            bridgebroke.SetActive(false);
            bridgefix.SetActive(true);
            GameObject particle = Instantiate(particles, bridgefix.GetComponentInParent<Transform>().transform.position + new Vector3 (-3 ,3, -4), Quaternion.identity);
            Destroy(particle, 1);
        }
        else if (taskID == 1)
        {
            taskcounter++;
            fireplacefix.SetActive(true);
            GameObject particle = Instantiate(particles, new Vector3(fireplacefix.transform.position.x - 1, fireplacefix.transform.position.y + 1, fireplacefix.transform.position.z - 1), Quaternion.identity);
            Destroy(particle, 1);
        }
        else if (taskID == 2)
        {
            taskcounter++;
            //Betty task 1
            BettyTaskID2.SetActive(false);
            BettyTaskID3.SetActive(true);
            StartCoroutine(BettyPause(1));
            
        }
        else if (taskID == 3)
        {
            taskcounter++;
            //Betty task 2
            BettyTaskID3.SetActive(false);
            BettyTaskID6.SetActive(true);
            StartCoroutine(BettyPause(2));
            

        }
        else if (taskID == 7)
        {
            taskcounter++;
            chair.gameObject.transform.localPosition = chairpos;
            chair.gameObject.transform.localEulerAngles = Vector3.zero;
            rod.gameObject.SetActive(true);
            GameObject particle = Instantiate(particles, new Vector3(rod.transform.position.x - 3, rod.transform.position.y + 4, rod.transform.position.z - 3), Quaternion.identity);
            Destroy(particle, 1);
        }
        
        
    }

    public IEnumerator BettyPause(int task)
    {
        
        yield return new WaitForSeconds(0.1f);
        if (task == 1)
        {
            BettyTaskID3.GetComponent<Interactables>().TriggerInteraction();
            firsttext = false;
        }
        else if (task == 2)
        {
            BettyTaskID6.GetComponent<Interactables>().TriggerInteraction();
            firsttext = false;
        }
    }


    public IEnumerator AnimateSentence(string dialogue, Text targettext)
    {
        targettext.text = "";

        foreach (char letter in dialogue.ToCharArray())
        {
            targettext.text += letter;
            yield return new WaitForSeconds(0.04f);
        }

    }
}
