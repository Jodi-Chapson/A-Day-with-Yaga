using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectibles : MonoBehaviour
{
    [SerializeField]
    int resourcetype; //0 is wood, 1 is stone, 2 is berries, 3 is fish
    ResourceManager rm;
    Transform player;
    public bool canCollect;
    
    [SerializeField]
    ParticleSystem ps;

    private void Start()
    {
        rm = GameObject.Find("Game Manager").GetComponent<ResourceManager>();


        player = GameObject.Find("Player").transform;
        //ps = GetComponentInChildren<ParticleSystem>();
        //ps.enableEmission = false;
    }

    private void Update()
    {

        if (canCollect)
        {
            

            if (Vector3.Distance(this.transform.position, player.position) < rm.collectionDistance + 0.5)
            {

                //ps.enableEmission = true;
            }
            else
            {
                //ps.enableEmission = false;
            }
        }
    }
    public void CollectResource()
    {
        if (resourcetype == 0)
        {
            rm.woodNum++;
        }
        else if (resourcetype == 1)
        {
            rm.stoneNum++;
        }
        else if (resourcetype == 2)
        {
            rm.berriesNum++;
        }
        else if (resourcetype == 3)
        {
            rm.fishNum++;
        }

        Destroy(gameObject);
    }


    private void OnMouseDown()
    {
        if (canCollect)
        {
            //Debug.Log(Vector3.Distance(this.transform.position, player.position));

            if (Vector3.Distance(this.transform.position, player.position) < rm.collectionDistance)
            {

                CollectResource();
                
                

            }
        }

    }
}
