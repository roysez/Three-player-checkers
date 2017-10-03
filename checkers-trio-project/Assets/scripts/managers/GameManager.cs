using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public Player[] players ;

	public Player currentPlayer;

	// Use this for initialization
	void Awake () {
		Player greenPlayer = new Player (0);
		Player redPlayer = new Player (2);
		Player yellowPlayer = new Player (1);

		players = new Player[3];
		players [0] = greenPlayer;
		players [1] = yellowPlayer;
		players [2] = redPlayer;

		currentPlayer = greenPlayer;
		TextManager.currentPlayerString = currentPlayer.colorOfPieces;
	}

	// Update is called once per frame
	void Update () {

	}

	public Player NextPlayer(){
		currentPlayer = players [currentPlayer.id==0?1:(currentPlayer.id==1?2:0)];
		TextManager.currentPlayerString = currentPlayer.colorOfPieces;
		return currentPlayer;
	}

	public void hitPlayer(string playerColor){
		if (playerColor.Contains("Green"))
			players [0].countOfPieces -= 1;
		else if (playerColor.Contains("Yellow"))
			players [1].countOfPieces -= 1;
		else
			players [2].countOfPieces -= 1;
	}

	bool CheckGameOver(){
		for (int i = 0; i < 2; i++) {
			if (players [i].countOfPieces == 0) {
				return true;
			}
		}
		return false;
	}
}