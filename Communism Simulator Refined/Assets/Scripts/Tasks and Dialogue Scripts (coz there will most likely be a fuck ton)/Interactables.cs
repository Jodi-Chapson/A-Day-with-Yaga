using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactables : MonoBehaviour
{
    //script attached to all objects that can be interacted with for dialogue or tasks
    [Header("References")]
    public Player player;
    public ResourceManager rm;
    public InteractionManager im;
    public InteractionData data;

    [Header("Toggles")]
    public bool isClick; //object is meant to be clicked on, as opposed to trigger via collider



    public void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
        rm = GameObject.Find("Game Manager").GetComponent<ResourceManager>();
        im = GameObject.Find("Game Manager").GetComponent<InteractionManager>();
    }


    private void OnMouseDown()
    {
        if (isClick)
        {
            if (Vector3.Distance(this.transform.position, player.transform.position) < 1.5f)
            {
                TriggerInteraction();

            }
        }
    }


    public void TriggerInteraction()
    {
        if (!data.isTriggered)
        {
            //player is touching object for the first time. 

            //display opening dialogue 
            if (!im.dialogueActive)
            {
                im.OpeningDialogue(data);
                data.isTriggered = true;
                
            }
        }
        else
        {
            //player has interacted with this object before - hence check requirements and display appropriate dialogue
            //this object is for sure a task.

            if (im.dialogueActive)
            {
                return;
            }


                int completedRequirements = 0;

            //if a requirement is wood
            if (data.wantedWood != 0)
            {
                if (rm.woodNum >= data.wantedWood)
                {
                    completedRequirements++;
                }
            }

            //if a requirement is stone
            if (data.wantedStone != 0)
            {
                if (rm.stoneNum >= data.wantedStone)
                {
                    completedRequirements++;
                }
            }

            //if a requirement is berries
            if (data.wantedBerries != 0)
            {
                if (rm.berriesNum >= data.wantedBerries)
                {
                    completedRequirements++;
                }
            }

            //if a requirement is fish
            if (data.wantedFish != 0)
            {
                if (rm.fishNum >= data.wantedFish)
                {
                    completedRequirements++;
                }
            }

            if (completedRequirements >= data.NumOfRequirements)
            {
                //you fulfill all requirements

                // deduct the appropriate amount of resources
                rm.woodNum -= data.wantedWood;
                rm.stoneNum -= data.wantedStone;
                rm.berriesNum -= data.wantedBerries;
                rm.fishNum -= data.wantedFish;

                //any effects of the task are set in motion
                //im.ConcludeInteraction(data.TaskID);
                im.ConcludingDialogue(data);
            }
        }
    }




}
