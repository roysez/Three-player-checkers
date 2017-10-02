using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckersBoard : MonoBehaviour {

	public Piece[,] pieces = new Piece[12,12];

	public Material material;

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
		if (Input.GetMouseButtonDown(0))
		{
			//Debug.Log("Mouse is down");

			RaycastHit hitInfo = new RaycastHit();
			bool hit = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo);
			if (hit) 
			{
				Debug.Log ("Hit " + hitInfo.transform.gameObject.name);
				if (hitInfo.transform.gameObject.tag == "BlackCell") {
					Debug.Log ("It's working!");

					if (selectedPiece != null) {
						
						selectedPiece.transform.position = hitInfo.transform.position;
					
						DeselectPiece ();

					}
				} else if (hitInfo.transform.gameObject.tag == "GreenPiece") {

					selectedPiece = hitInfo.transform.gameObject.GetComponent<Piece> ();
					selectedPiece.SetLight (true);

				} else {
					Debug.Log ("Nog");
					DeselectPiece ();
				}

			} else {
				Debug.Log("No hit");
			}
			//Debug.Log("Mouse is down");
		} 
	}

	private void DeselectPiece(){
		if (selectedPiece != null) {
			selectedPiece.SetLight (false);
			selectedPiece = null;
		}
	}


}
