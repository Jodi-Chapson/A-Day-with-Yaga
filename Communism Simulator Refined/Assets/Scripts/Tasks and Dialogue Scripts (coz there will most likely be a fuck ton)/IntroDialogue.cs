using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroDialogue : MonoBehaviour
{
    [Header("References")]
    public InteractionManager im;
    public string[] introdialogue;
    public int[] speakerID;

    void Start()
    {
        im = GameObject.Find("Game Manager").GetComponent<InteractionManager>();

        StartCoroutine(DelayedStartcozfukthisunity());



    }


    public IEnumerator DelayedStartcozfukthisunity()
    {
        yield return new WaitForSeconds(0.1f);
        
        im.dialogue.Clear();
        im.speakerID.Clear();




        foreach (int id in speakerID)
        {
            im.speakerID.Enqueue(id);
        }

        foreach (string sentence in introdialogue)
        {
            im.dialogue.Enqueue(sentence);
        }

        im.NextDialogue();
        im.dialogueActive = true;
        //im.firsttext = true;


        Destroy(this.gameObject, 2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
