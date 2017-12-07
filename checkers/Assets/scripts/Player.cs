using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	public int id;
	public int countOfPieces;
	public string colorOfPieces;

	public Player() {
		countOfPieces = 12;
	}

	public Player(int _id){
		id = _id;
		countOfPieces = 12;
		colorOfPieces = id==0?"Green":(id==1?"Yellow":"Red");
	}

	// Use this for initialization
	void Start () {


	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
