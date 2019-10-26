using System.Collections.Generic;
using InControl;
using UnityEngine;
using UnityEngine.UI;

public class ChopsticksManager : MonoBehaviour
{
    public GameObject gameController;
	public GameObject playerPrefab;
    public GameObject shadow;
    public Text text1;
    const int maxPlayers = 2;

	List<Vector3> playerPositions = new List<Vector3>() {
		new Vector3( 2, 2, -1.5f ),
		new Vector3( -2.9f, 2, -1.5f )
	};

	List<Chopsticks> players = new List<Chopsticks>(maxPlayers);



	void Start()
	{
		InputManager.OnDeviceDetached += OnDeviceDetached;
	}


	void Update()
	{
		var inputDevice = InputManager.ActiveDevice;

		if (JoinButtonWasPressedOnDevice(inputDevice))
		{
            
			if (ThereIsNoPlayerUsingDevice(inputDevice))
			{
				CreatePlayer(inputDevice);
                gameController.GetComponent<GameController>().Tutorial();
            }
		}
	}


	bool JoinButtonWasPressedOnDevice(InputDevice inputDevice)
	{
        return inputDevice.Action1.WasPressed || inputDevice.Action2.WasPressed;
	}


	Chopsticks FindPlayerUsingDevice(InputDevice inputDevice)
	{
		var playerCount = players.Count;
		for (var i = 0; i < playerCount; i++)
		{
			var player = players[i];
			if (player.Device == inputDevice)
			{
				return player;
			}
		}

		return null;
	}


	bool ThereIsNoPlayerUsingDevice(InputDevice inputDevice)
	{
		return FindPlayerUsingDevice(inputDevice) == null;
	}


	void OnDeviceDetached(InputDevice inputDevice)
	{
		var player = FindPlayerUsingDevice(inputDevice);
		if (player != null)
		{
			RemovePlayer(player);
		}
	}


	Chopsticks CreatePlayer(InputDevice inputDevice)
	{
		if (players.Count < maxPlayers)
		{
			// Pop a position off the list. We'll add it back if the player is removed.
			var playerPosition = playerPositions[0];
			playerPositions.RemoveAt(0);

			var gameObject = (GameObject)Instantiate(playerPrefab, playerPosition, Quaternion.identity);
            //var shadowObject = (GameObject)Instantiate(shadow, playerPosition, Quaternion.identity);

            gameObject.GetComponent<Chopsticks>().playerIndex = players.Count + 1;

            var player = gameObject.GetComponent<Chopsticks>();
            //sha.GetComponent<ShadowController>();
            player.Device = inputDevice;
			players.Add(player);

			return player;
		}

		return null;
	}


	void RemovePlayer(Chopsticks player)
	{
		playerPositions.Insert(0, player.transform.position);
		players.Remove(player);
		player.Device = null;
		Destroy(player.gameObject);
	}


	void OnGUI()
	{
		const float h = 22.0f;
		var y = 10.0f;
        GUIStyle myStyle = new GUIStyle();
        myStyle.fontSize = 20;
       myStyle.normal.textColor = Color.white;
        GUI.Label(new Rect(10, y, 600, y + h), "Active players: " + players.Count + "/" + maxPlayers, myStyle);
        
		y += h;

		if (players.Count < maxPlayers)
		{
			GUI.Label(new Rect(10, y, 600, y + h), "Press a button to join!", myStyle);
			y += h;
		}
	}
}
