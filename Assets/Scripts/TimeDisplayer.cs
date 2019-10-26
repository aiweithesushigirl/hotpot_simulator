using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeDisplayer : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject gameController;
    Text text_component;
    void Start()
    {
        text_component = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        text_component.text = $"Time: {gameController.GetComponent<GameController>().timeText}";
        if (gameController.GetComponent<GameController>().timesUp)
        {
            text_component.enabled = false;
        }
        else
        {
            text_component.enabled = true;
        }
    }
}
