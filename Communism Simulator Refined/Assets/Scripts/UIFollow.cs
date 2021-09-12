using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIFollow : MonoBehaviour
{
    public GameObject target;
    public Vector3 targetposition;
    public float positionmodifier;

    public void Update()
    {

        targetposition = target.transform.position;
        targetposition += new Vector3(positionmodifier, -positionmodifier, positionmodifier);

        this.transform.position = targetposition;
    }
}
