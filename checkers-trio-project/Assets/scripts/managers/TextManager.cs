using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextManager : MonoBehaviour {

	public static string currentPlayerString;

	Text curPlayText;

	private  Color RED_COLOR = new Color(255,0,0,255);
	private  Color YELLOW_COLOR = new Color(255,227,0,255);
	private  Color GREEN_COLOR = new Color(0,255,0,255);


	// Use this for initialization
	void Start () {
		currentPlayerString = "Green";
		curPlayText = GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
		curPlayText.text = currentPlayerString;


		curPlayText.color = curPlayText.text == "Green" ? GREEN_COLOR : (currentPlayerString == "Red" ? RED_COLOR : YELLOW_COLOR);
	}
}
