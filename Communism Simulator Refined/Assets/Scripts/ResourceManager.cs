using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourceManager : MonoBehaviour
{
    public int woodNum = 0;
    public int stoneNum = 0;
    public int woodmax, stonemax; //max of each resource, calculated at the start of the game
    public Text wood, stone;
    public float collectionDistance;
    public GameObject woodstrike, stonestrike;
    public GameManager manager;

    
    void Start()
    {
        manager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        woodNum = 0;
        stoneNum = 0;
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
