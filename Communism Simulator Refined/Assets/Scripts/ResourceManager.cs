using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourceManager : MonoBehaviour
{

    [Header("References")]
    public float collectionDistance;
    public GameManager manager;
    public GameObject prefab;

    [Header("Resource Stats")]
    public int woodNum = 0;
    public int stoneNum = 0;
    public int berriesNum = 0;
    public int fishNum = 0;



    void Start()
    {
        manager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        
    }

    
    void Update()
    {
        //wood.text = woodNum + "/" + woodmax;
        //stone.text = stoneNum + "/" + stonemax;

        //if (woodNum >= woodmax)
        //{
        //    if (woodstrike.activeSelf == false)
        //    {
        //        woodstrike.SetActive(true);
        //    }
        //}



        //if (stoneNum >= stonemax)
        //{
        //    if (stonestrike.activeSelf == false)
        //    {
        //        stonestrike.SetActive(true);
        //    }
        //}


        

    }
}
