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
            if (Vector3.Distance(this.transform.position, player.transform.position) < data.triggerdistance)
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
                im.StartDialogue(0, data);
                data.isTriggered = true;
                

                if (!data.hasRequirement)
                {
                    
                    im.ConcludeInteraction(data.TaskID);
                    
                    Destroy(this.GetComponent<Interactables>());
                }
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
                im.StartDialogue(1, data);
                Destroy(this.GetComponent<Interactables>());
            }
            else if (completedRequirements < data.NumOfRequirements)
            {
                //stuff is unfulfilled
                string ponder;
                string wood = "";
                string stone = "";
                string berries = "";
                string fish = "";
                int numberofStrings = 0;
                ponder = "I still need ";

                if (data.wantedWood != 0)
                {
                    
                    int remainder = data.wantedWood - rm.woodNum;
                    if (remainder > 0)
                    {
                        
                        if (remainder == 1)
                        {
                            wood += remainder + " piece of wood";
                            
                        }
                        else
                        {
                            wood += remainder + " pieces of wood";
                            
                        }
                        numberofStrings++;
                    }
                }

                if (data.wantedStone != 0)
                {
                    int remainder = data.wantedStone - rm.stoneNum;
                    if (remainder >0)
                    {
                        if (numberofStrings > 0)
                        { 
                            if (data.NumOfRequirements - numberofStrings == 1)
                            {
                                stone += " and ";
                            }
                            else
                            {
                                stone += ", ";

                            }
                            
                        }

                        if (remainder == 1)
                        {
                            stone += remainder + " stone";
                        }
                        else
                        {
                            stone += remainder + " stones";
                        }

                        numberofStrings++;

                    }


                }

                if (data.wantedBerries != 0 )
                {
                    int remainder = data.wantedBerries - rm.berriesNum;
                    if (remainder > 0)
                    {
                        if (numberofStrings > 0)
                        {
                            if (data.NumOfRequirements - numberofStrings == 1)
                            {
                                berries += " and ";
                            }
                            else
                            {
                                berries += ", ";
                            }
                        }

                        if (remainder == 1)
                        {
                            berries += remainder + " berry";
                        }
                        else
                        {
                            berries += remainder + " berries";
                        }

                        numberofStrings++;
                    }
                }

                if (data.wantedFish != 0)
                {
                    int remainder = data.wantedFish - rm.fishNum;
                    if (remainder > 0)
                    {
                        if (numberofStrings > 0)
                        {
                            if (data.NumOfRequirements - numberofStrings == 1)
                            {
                                fish += " and ";
                            }
                            else
                            {
                                fish += ", ";
                            }
                        }

                        if (remainder == 1)
                        {
                            fish += remainder + " fish";
                        }
                        else
                        {
                            fish += remainder + " fish";
                        }

                        numberofStrings++;
                    }
                }

                ponder += wood + stone + berries + fish + ".";

                im.dialogue.Clear();
                im.speakerID.Clear();

                im.dialogue.Enqueue(ponder);
                im.speakerID.Enqueue(0);

                im.NextDialogue();
                im.dialogueActive = true;
                im.firsttext = true;

                Debug.Log(ponder);
                Debug.Log("ponder");
                

            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (!isClick)
            {
                TriggerInteraction();
                im.firsttext = false;
            }
        }
    }


}
