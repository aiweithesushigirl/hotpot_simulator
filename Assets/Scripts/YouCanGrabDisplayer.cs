using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class YouCanGrabDisplayer : MonoBehaviour
{
    // Start is called before the first frame update
    Text text_component;
    public bool canGrab;
    void Start()
    {
        text_component = GetComponent<Text>();
        //text_component.text = "You can grab the food now!";
        canGrab = false;
        text_component.enabled = false;
    }

    public void setText(string text)
    {
        text_component.text = text;
    }

    public void setColor(Color c)
    {
        text_component.color = c;
    }

    // Update is called once per frame
    void Update()
    {

        if (canGrab)
        {
            text_component.enabled = true;
        }
        else
        {
            text_component.enabled = false;
        }

    }
}
