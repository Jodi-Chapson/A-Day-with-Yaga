using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionManager : MonoBehaviour
{

    
    public void OpeningDialogue (InteractionData Data)
    {
        //initiates opening dialogue
    }
    public void ConcludingDialogue(InteractionData Data)
    {
        // initiates end dialogue

    }
    public void ConcludeInteraction(int taskID)
    {
        Debug.Log("task " + taskID + " complete!");

        //for handling the effects of completed tasks - if any
        //is called after concluding dialogue
        //may initiate opening dialogue of next quest
        
    }
}
