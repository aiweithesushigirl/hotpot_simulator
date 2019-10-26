using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OvercookedDisplayer : MonoBehaviour
{
    // Start is called before the first frame update
    Text text_component;
    public bool isOvercooked;
    void Start()
    {
        text_component = GetComponent<Text>();
        text_component.text = "I'm overcooked";
        isOvercooked = false;
        text_component.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (isOvercooked)
        {
            text_component.enabled = true;
        }
        else
        {
            text_component.enabled = false;
        }

    }
}
