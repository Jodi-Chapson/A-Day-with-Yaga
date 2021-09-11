using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class InteractionData
{

    public int TaskID; //unique taskID, which should be indicated in the google docs, if those are up to date
    
    public bool isTriggered; //means the player has interacted with this object
    public float triggerdistance;

    public bool hasRequirement;
    public int NumOfRequirements; //so if a task wants only wood, this will be 1. if it wants say, wood, stone and fish, this will be 3. based on number of required unique resources

    public int wantedWood;
    public int wantedStone;
    public int wantedBerries;
    public int wantedFish;

    public int OpeningCharacterID; // to check which character is speaking, and works with the string of dialoge. 0 is Yaga, and 1 is Betty
    public string OpeningDialogue;
    public int ClosingCharacterID;
    public string ClosingDialogue;
    //normal dialogues and commentary from Yaga only use OpeningDialogue
    //mostly applies to tasks - Closing Dialogue is presented when a task is completed :D haha fuk me

    //i will attempt actual two-person dialogues later



}
