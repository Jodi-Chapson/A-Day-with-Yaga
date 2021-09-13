using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightManager : MonoBehaviour
{
    [SerializeField]
    Light sun;
    [SerializeField]
    InteractionManager IM;
    // Start is called before the first frame update
    void Start()
    {
        sun = GameObject.Find("Sun").GetComponent<Light>();
        IM = GameObject.Find("Game Manager").GetComponent<InteractionManager>();
        sun.intensity = 0.7f;
    }

    // Update is called once per frame
    void Update()
    {
        if(IM.taskcounter == 1)
        {
            sun.intensity = Mathf.Lerp(0.7f, 0.9f, 4 * Time.deltaTime);
        }
    }
}
