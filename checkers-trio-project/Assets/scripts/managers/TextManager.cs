using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextManager : MonoBehaviour {

	public static string currentPlayerString;

	Text curPlayText;
	Text curCountOfPiecesText;

	private GameManager gameManager;

	private  Color RED_COLOR = new Color(255,0,0,255);
	private  Color YELLOW_COLOR = new Color(255,227,0,255);
	private  Color GREEN_COLOR = new Color(0,255,0,255);


	// Use this for initialization
	void Start () {
		gameManager = GameObject.Find("Desk").GetComponent<GameManager> ();

		currentPlayerString = "Green";
		curPlayText = GetComponent<Text> ();

		curCountOfPiecesText = GameObject.Find ("CountOfPiecesText").GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
		curPlayText.text = currentPlayerString;

		curCountOfPiecesText.text = UpdateCountOfPieces ();
		Color color = curPlayText.text == "Green" ? GREEN_COLOR : (currentPlayerString == "Red" ? RED_COLOR : YELLOW_COLOR);
		curCountOfPiecesText.color = new Color(0,255,255,255);
		curPlayText.color = color;
	}

	string UpdateCountOfPieces(){
		return "Green:" + gameManager.players [0].countOfPieces + "\n" +
		                "Yellow:" + +gameManager.players [1].countOfPieces + "\n" +
		                "Red:" + gameManager.players [2].countOfPieces + "\n";
	}

	 
}
