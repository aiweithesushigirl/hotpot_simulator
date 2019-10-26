using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverDisplayer : MonoBehaviour
{
    // Start is called before the first frame update
    public Text text_component;
    public GameObject gameController;
    private readonly string player1WinTxt = "Player1 Wins!";
    private readonly string player2WinTxt = "Player2 Wins!";
    private readonly string bothWinTxt = "So I guess you're both hotpot geniuses!";
    void Start()
    {      
        text_component.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (gameController.GetComponent<GameController>().player1Win)
        {
            text_component.text = player1WinTxt;
            text_component.enabled = true;
        }
        if (gameController.GetComponent<GameController>().player2Win)
        {
            text_component.text = player2WinTxt;
            text_component.enabled = true;
        }
        if (gameController.GetComponent<GameController>().bothWin)
        {
            text_component.text = player2WinTxt;
            text_component.enabled = true;
        }
        if (!gameController.GetComponent<GameController>().player1Win && !gameController.GetComponent<GameController>().player2Win && !gameController.GetComponent<GameController>().bothWin)
        {
            text_component.enabled = false;
        }

    }
}
