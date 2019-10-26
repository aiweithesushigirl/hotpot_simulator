using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointDisplayer : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject gameController;
    public int playerIndex;
    Text text_component;
    void Start()
    {
        text_component = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        int points = gameController.GetComponent<GameController>().playerPoints[playerIndex];
        text_component.text = "Player " + playerIndex + " Points : " + points;
    }
}
