using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIText : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    public bool isText;
    public Text text;
    public int size;
    public Vector3 scale;

    public void Start()
    {
        if (isText)
        {
            text = this.GetComponentInChildren<Text>();
            size = text.fontSize;
        }
        else
        {
            scale = this.GetComponent<RectTransform>().localScale;
        }
    }


    public void OnPointerEnter(PointerEventData eventData)
        {

        if (isText)
        {
            text.fontSize = size + 10;
        }
        else
        {
            this.GetComponent<RectTransform>().localScale = scale * 1.1f;
        }

        }
    public void OnPointerExit(PointerEventData eventData)
    {
        if (isText)
        {
            text.fontSize = size;
        }
        else
        {
            this.GetComponent<RectTransform>().localScale = scale;
        }

        //Debug.Log("EXIT");
        //throw new System.NotImplementedException();
    }


}
