using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour
{
    [Header("References")]
    public GameObject targetplayer;

    [Header("States + Stats")]
    public bool camFollow;
    public Vector3 startPos;

    [Header("Camera Manipulation")]
    public float ymod;
    public float xmod;
    public float zmod;


    
    public void Start()
    {
        startPos = this.transform.position;
    }

    public void Update()
    {
        if (camFollow)
        {
            Vector3 target = new Vector3(targetplayer.transform.position.x + xmod, startPos.y + ymod, targetplayer.transform.position.z + zmod);


            this.transform.position = target;


        }
    }

}
