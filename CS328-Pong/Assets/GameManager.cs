using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static int Player1Score = 0;
    public static int Player2Score = 0;

    // GUISkin?
    public GUISkin layout;

    GameObject theBall;

    // Use this for initialization
    void Start () {

        theBall = GameObject.FindGameObjectWithTag("Ball");
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public static void Score (string wallID)
    {
        if (wallID == "RightWall")
        {
            Player1Score++;
        }
        else
        {
            Player2Score++;
        }
    }

    private void OnGUI()
    {
        GUI.skin = layout;
        GUI.Label(new Rect(Screen.width / 2 - 150 - 50, 20, 100, 100), "" + Player1Score);
        GUI.Label(new Rect(Screen.width / 2 + 150 + 12, 20, 100, 100), "" + Player2Score);

        if (GUI.Button(new Rect(Screen.width / 2 - 60, 35, 120, 53), "RESTART"))
        {
            Player1Score = 0;
            Player2Score = 0;
            theBall.SendMessage("RestartGame", 0.5f, SendMessageOptions.RequireReceiver);
        }

        if (Player1Score == 5)
        {
            GUI.Label(new Rect(Screen.width / 2 - 150, 200, 2000, 1000), "PLAYER ONE WINS");
            theBall.SendMessage("ResetBall", null, SendMessageOptions.RequireReceiver);
        }
        else if (Player2Score == 5)
        {
            GUI.Label(new Rect(Screen.width / 2 - 150, 200, 2000, 1000), "PLAYER TWO WINS");
            theBall.SendMessage("ResetBall", null, SendMessageOptions.RequireReceiver);
        }

    }

}
