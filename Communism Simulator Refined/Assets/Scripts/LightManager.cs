using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightManager : MonoBehaviour
{
    [SerializeField]
    Light sun;
    [SerializeField]
    InteractionManager IM;
    public Vector3 targetAngle1 = new Vector3(80f, 180f, 135f);
    public Vector3 targetAngle2 = new Vector3(105f, 135f, 90f);
    public Vector3 targetAngle3 = new Vector3(125f, 135f, 90f);
    public Vector3 targetAngle4 = new Vector3(145f, 135f, 90f);
    public Vector3 targetAngle5 = new Vector3(160f, 135f, 90f);
    public Vector3 targetAngle6 = new Vector3(170f, 135f, 90f);
    private Vector3 currentAngle;

    [SerializeField]
    GameObject[] lanternLights;
    
    void Start()
    {
        sun.transform.eulerAngles = new Vector3(60f, 135f, 90f);
        sun = GameObject.Find("Sun").GetComponent<Light>();
        IM = GameObject.Find("Game Manager").GetComponent<InteractionManager>();
        sun.intensity = 0.7f;
        sun.color = new Color32(170, 210, 219, 255);
        RenderSettings.ambientIntensity = 0.85f;
        lanternLights = GameObject.FindGameObjectsWithTag("Lantern_Light");
        foreach(GameObject gm in lanternLights)
        {
            gm.GetComponent<Light>().enabled = false;
        }
    }

    
    void Update()
    {
        if(IM.taskcounter == 1)
        {
            sun.intensity = Mathf.Lerp(0.7f, 0.9f, 1);
            currentAngle = sun.transform.eulerAngles;
            currentAngle = new Vector3(
             Mathf.LerpAngle(currentAngle.x, targetAngle1.x, 1),
             Mathf.LerpAngle(currentAngle.y, targetAngle1.y,  1),
             Mathf.LerpAngle(currentAngle.z, targetAngle1.z, 1));
            RenderSettings.ambientIntensity = 0.9f;
            sun.transform.eulerAngles = currentAngle;
            currentAngle = Vector3.zero;
        }
        if(IM.taskcounter == 2)
        {
            
            currentAngle = sun.transform.eulerAngles;
            currentAngle = new Vector3(
             Mathf.LerpAngle(currentAngle.x, targetAngle2.x, 1),
             Mathf.LerpAngle(currentAngle.y, targetAngle2.y, 1),
             Mathf.LerpAngle(currentAngle.z, targetAngle2.z, 1));
            sun.transform.eulerAngles = currentAngle;
            currentAngle = Vector3.zero;
        }
        if (IM.taskcounter == 3)
        {
            sun.intensity = Mathf.Lerp(0.9f, 0.8f, 1);
            currentAngle = sun.transform.eulerAngles;
            currentAngle = new Vector3(
             Mathf.LerpAngle(currentAngle.x, targetAngle3.x, 1),
             Mathf.LerpAngle(currentAngle.y, targetAngle3.y, 1),
             Mathf.LerpAngle(currentAngle.z, targetAngle3.z, 1));
            sun.transform.eulerAngles = currentAngle;
            currentAngle = Vector3.zero;
        }
        if (IM.taskcounter == 4)
        {
            sun.intensity = Mathf.Lerp(0.8f, 0.7f,   1);
            currentAngle = sun.transform.eulerAngles;
            currentAngle = new Vector3(
             Mathf.LerpAngle(currentAngle.x, targetAngle4.x, 1),
             Mathf.LerpAngle(currentAngle.y, targetAngle4.y, 1),
             Mathf.LerpAngle(currentAngle.z, targetAngle4.z, 1));
            sun.transform.eulerAngles = currentAngle;
            RenderSettings.ambientIntensity = 0.7f;
            sun.color = Color32.Lerp(new Color32(170, 210, 219, 255), new Color32(255,196,126,255), 1);
            currentAngle = Vector3.zero;
        }
        if (IM.taskcounter == 5)
        {
            sun.intensity = Mathf.Lerp(0.7f, 0.6f, 1);
            currentAngle = sun.transform.eulerAngles;
            currentAngle = new Vector3(
             Mathf.LerpAngle(currentAngle.x, targetAngle5.x, 1),
             Mathf.LerpAngle(currentAngle.y, targetAngle5.y, 1),
             Mathf.LerpAngle(currentAngle.z, targetAngle5.z, 1));
            sun.transform.eulerAngles = currentAngle;
            RenderSettings.ambientIntensity = 0.5f;
            sun.color = Color32.Lerp(new Color32(255, 196, 126, 255), new Color32(255, 72,0,255), 1);
            currentAngle = Vector3.zero;
            foreach (GameObject gm in lanternLights)
            {
                gm.GetComponent<Light>().enabled = true;
            }
        }
        if (IM.taskcounter == 6)
        {
            sun.intensity = Mathf.Lerp(0.6f, 0.5f, 1);
            currentAngle = sun.transform.eulerAngles;
            currentAngle = new Vector3(
             Mathf.LerpAngle(currentAngle.x, targetAngle6.x, 1f),
             Mathf.LerpAngle(currentAngle.y, targetAngle6.y, 1f),
             Mathf.LerpAngle(currentAngle.z, targetAngle6.z, 1f));
            sun.transform.eulerAngles = currentAngle;
            sun.color = Color32.Lerp(new Color32(255, 39, 0, 255), new Color32(255, 0, 0, 255), 1);
            RenderSettings.ambientIntensity = 0.45f;
            currentAngle = Vector3.zero;
        }
    }
}
