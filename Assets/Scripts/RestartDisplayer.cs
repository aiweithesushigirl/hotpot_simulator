using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RestartDisplayer : MonoBehaviour
{
    // Start is called before the first frame update
    public Text text_component;
    public GameObject gameController;
    private readonly string restart = "Press left key to restart";
    private readonly string nextLevel = "Press left key to go to next level";
    void Start()
    {
        //text_component = GetComponent<Text>();
        
        text_component.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (gameController.GetComponent<GameController>().player1Win || gameController.GetComponent<GameController>().player2Win || gameController.GetComponent<GameController>().bothWin)
        {
            text_component.text = restart;
            text_component.enabled = true;
        }

        if (!gameController.GetComponent<GameController>().player1Win && !gameController.GetComponent<GameController>().player2Win && !gameController.GetComponent<GameController>().bothWin)
        {
            text_component.enabled = false;
        }

    }
}
