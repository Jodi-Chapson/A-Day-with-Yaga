using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIFollow : MonoBehaviour
{
    public GameObject target;

    public void Update()
    {
        this.transform.position = target.transform.position;
    }
}
