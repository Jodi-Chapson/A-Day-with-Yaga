using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fireplace : MonoBehaviour
{
    public bool isEnabled;
    public ResourceManager rm;
    public float interactiondistance;
    public bool isCooking;
    public bool isCooked;
    public GameObject fish;
    public ParticleSystem smoke;

    


    public Material fish1;
    public Material fish2;
    public Material fish3;


    public int cookingprocess;


   
    public void Start()
    {
        rm = GameObject.Find("Game Manager").GetComponent<ResourceManager>();

        

    }

    private void OnMouseDown()
    {
        if (isEnabled && !rm.GetComponent<InteractionManager>().dialogueActive)
        {
            
            {
                

                if (Vector3.Distance(this.transform.position, rm.GetComponent<GameManager>().player.GetComponent<Transform>().transform.position) < interactiondistance)
                {

                    if (isCooking)
                    {
                        if (isCooked)
                        {
                            fish.SetActive(false);

                            Vector3 alteredposition = new Vector3(this.transform.position.x, this.transform.position.y + 0.3f, this.transform.position.z);
                            GameObject notif = Instantiate(rm.prefab, alteredposition, Quaternion.identity);

                            notif.GetComponentInChildren<Text>().text = "+1 cooked fish";




                            rm.hasCookedFish = true;



                            isCooked = false;
                            isCooking = false;
                        }





                    }
                    else
                    {
                        if (rm.fishNum > 0)
                        {

                            rm.fishNum--;
                            fish.SetActive(true);
                            fish.GetComponent<MeshRenderer>().material = fish1;
                            StartCoroutine(CookingTimer());


                            isCooking = true;
                        }
                        else
                        {
                            rm.GetComponent<InteractionManager>().dialogue.Clear();
                            rm.GetComponent<InteractionManager>().speakerID.Clear();

                            string fishneeded = "I need a fish to cook.";

                            rm.GetComponent<InteractionManager>().dialogue.Enqueue(fishneeded);
                            rm.GetComponent<InteractionManager>().speakerID.Enqueue(0);

                            rm.GetComponent<InteractionManager>().NextDialogue();
                            rm.GetComponent<InteractionManager>().dialogueActive = true;
                            rm.GetComponent<InteractionManager>().firsttext = true;

                           
                        }
                    }




                }
            }
            
        }
    }

    public void Update()
    {
        
        if (cookingprocess == 1)
        {
            fish.GetComponent<MeshRenderer>().material.Lerp(fish1,fish2,0.5f);
        }
        else if (cookingprocess == 2)
        {
            fish.GetComponent<MeshRenderer>().material.Lerp(fish2, fish3, 0.5f);
        }
    }

    public IEnumerator CookingTimer()
    {
        
        isCooking = true;
        cookingprocess = 1;
        yield return new WaitForSeconds(2f);
        cookingprocess = 2;
        yield return new WaitForSeconds(3f);

        cookingprocess = 0;
        fish.GetComponent<MeshRenderer>().material = fish3;

        smoke.gameObject.SetActive(true);
        isCooked = true;
        yield return new WaitForSeconds(1f);
        smoke.gameObject.SetActive(false);

        

    }





    public void OnMouseEnter()
    {
        if (isEnabled)
        {
            if (Vector3.Distance(this.transform.position, rm.GetComponent<GameManager>().player.GetComponent<Transform>().transform.position) < interactiondistance)
            {
                rm.GetComponent<GameManager>().cursorstate = 3;

            }
            else
            {
                rm.GetComponent<GameManager>().cursorstate = 4;
            }


        }
    }

    public void OnMouseOver()
    {
        if (isEnabled)
        {
            if (Vector3.Distance(this.transform.position, rm.GetComponent<GameManager>().player.GetComponent<Transform>().transform.position) < interactiondistance)
            {
                rm.GetComponent<GameManager>().cursorstate = 3;

            }
            else
            {
                rm.GetComponent<GameManager>().cursorstate = 4;
            }


        }
    }

    public void OnMouseExit()
    {
        if (isEnabled)
        {
            if (rm.GetComponent<GameManager>().cursorstate == 3 || rm.GetComponent<GameManager>().cursorstate == 4)
            {
                rm.GetComponent<GameManager>().cursorstate = 0;
            }
        }
    }



}
