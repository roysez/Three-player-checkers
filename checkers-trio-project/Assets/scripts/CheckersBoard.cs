using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckersBoard : MonoBehaviour {

	public Piece[,] pieces = new Piece[12,12];

	public GameObject greenPiecePrefab;
	public GameObject redPiecePrefab;
	public GameObject yellowPiecePrefab;

	public GameObject[] blackCells;

	private Piece selectedPiece;

	Vector2 mouseOver;

	// Use this for initialization
	void Start () {


	}


	// Update is called once per frame
	void Update () {
		// UpdateMouseOver ();

		//Debug.Log (mouseOver);
		if (Input.GetMouseButtonDown(0))
		{
			Debug.Log("Mouse is down");

			RaycastHit hitInfo = new RaycastHit();
			bool hit = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo);
			if (hit) 
			{
				Debug.Log("Hit " + hitInfo.transform.gameObject.name);
				if (hitInfo.transform.gameObject.tag == "BlackCell")
				{
					Debug.Log ("It's working!");
				} if (hitInfo.transform.gameObject.tag == "GreenPiece") {
					hitInfo.transform.gameObject.GetComponentInChildren<Light>().enabled = false;
				}
				else {
					Debug.Log ("nopz");
				}
			} else {
				Debug.Log("No hit");
			}
			Debug.Log("Mouse is down");
		} 
	}

}
