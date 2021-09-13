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
    public Text wood, stone, berries, fish;

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
        wood.text = "X " + woodNum.ToString();
        stone.text = "X " + stoneNum.ToString();
        berries.text = "X " + berriesNum.ToString();
        fish.text = "X " + fishNum.ToString();

        if (Input.GetKeyDown("h"))
        {
            //h for hax
            woodNum += 10;
            stoneNum += 10;
            berriesNum += 10;
            fishNum += 10;
        }


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
