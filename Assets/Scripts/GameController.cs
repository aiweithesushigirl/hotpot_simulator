using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static GameController instance;
    private float startTime;
    public bool timesUp = false;
    public bool player1Win = false;
    public bool player2Win = false;
    public bool bothWin = false;
    public int gameTime;
    public string timeText;
    public ToastManager toaster;
    public YouCanGrabDisplayer youCanGrab;
    public Dictionary<int, int> playerPoints = new Dictionary<int, int>
    {
        { 1, 0 },
        { 2, 0 },
    };
    private bool startGame;
    
    
    void Awake()
    {
        
        player1Win = false;
        player2Win = false;
        bothWin = false;
        startGame = false;


        if (!instance)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }


    }
    public void Tutorial()
    {
        StartCoroutine(toasting());
    }

    IEnumerator toasting()
    {
        toaster.setText("Use left joystick to move the chopsticks around");
        toaster.toast();
        yield return new WaitForSeconds(7f);
        toaster.setText("Use right joystick to move the chopsticks up and down");
        toaster.toast();
        yield return new WaitForSeconds(5f);
        toaster.setText("Hold on to RT to grab food when you get close");
        toaster.toast();
        yield return new WaitForSeconds(5f);
        toaster.setText("You have 120 seconds");
        toaster.toast();
        yield return new WaitForSeconds(5f);
        toaster.setText("Now try it!");
        toaster.toast();
        yield return new WaitForSeconds(1f);
        Destroy(toaster);
        startGame = true;
        startTime = Time.time;
        //yield return null;

    }


    void Update()
    {
        if (startGame)
        {
            
            float guiTime = Time.time - startTime;



            float minutes = guiTime / 60;
            float seconds = guiTime % 60;
            float fraction = (guiTime * 100) % 100;

            timeText = (int)minutes + ":" + (int)seconds + ":" + (int)fraction;

            if (guiTime >= gameTime)
            {
                timesUp = true;
            }
            if (timesUp)
            {
                if (playerPoints[1] > playerPoints[2])
                {
                    player1Win = true;
                }
                else if (playerPoints[1] < playerPoints[2])
                {
                    player2Win = true;
                }
                else
                {
                    bothWin = true;
                }
                
            }

            if (player1Win || player2Win)
            {
                //player.SetActive(false);
                if (Input.GetMouseButtonDown(0))
                {
                    player1Win = false;
                    player2Win = false;
                    bothWin = false;
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                }
            }
        }

    }


    public void addPoint(int stage, int point, int playerIndex)
    {
        string text = "";
        //float r = 115f;  // red component
        //float g = 164f;  // green component
        //float b = 38f; // blue component

        switch (stage)
        {
            case -1:
                playerPoints[playerIndex] += 0;
                break;
            case 0:
                playerPoints[playerIndex] += point;
                text = ("Player" + playerIndex + " +" + point);
                //youCanGrab.setColor(new Color(r, g, b));
                youCanGrab.setText(text);
                youCanGrab.GetComponent<YouCanGrabDisplayer>().canGrab = true;
                StartCoroutine(pointToast());
                break;
            case 1:
                playerPoints[playerIndex] += 3 * point;
                text = "Player" + playerIndex + " +" + 3 * point;
                //youCanGrab.setColor(new Color(r, g, b));
                youCanGrab.setText(text);
                youCanGrab.GetComponent<YouCanGrabDisplayer>().canGrab = true;
                StartCoroutine(pointToast());
                break;
            case 2:
                playerPoints[playerIndex] += 2 * point;
                text = "Player" + playerIndex + " +" + 2 * point;
                //youCanGrab.setColor(new Color(r, g, b));
                youCanGrab.setText(text);
                youCanGrab.GetComponent<YouCanGrabDisplayer>().canGrab = true;
                StartCoroutine(pointToast());
                break;
            default:
                break;
        }
    }

    public void DeductPoint(int point, int playerIndex)
    {
        playerPoints[playerIndex] -= point;
        string text4 = "Player" + playerIndex + " -" + point;
        youCanGrab.setColor(Color.red);
        youCanGrab.setText(text4);
        youCanGrab.GetComponent<YouCanGrabDisplayer>().canGrab = true;
        StartCoroutine(pointToast());
    }

    private IEnumerator pointToast()
    {

        yield return new WaitForSeconds(1f);
        youCanGrab.GetComponent<YouCanGrabDisplayer>().canGrab = false;
    }


}
