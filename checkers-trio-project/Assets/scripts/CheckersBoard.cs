using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text.RegularExpressions;

public class CheckersBoard : MonoBehaviour {

	public Piece[,] pieces = new Piece[12,12];

	public Material material;

	public GameObject greenPiecePrefab;
	public GameObject redPiecePrefab;
	public GameObject yellowPiecePrefab;

	public GameObject[] blackCells;

	private Piece selectedPiece;

	private Regex regex = new Regex(@"\w*Piece\b", RegexOptions.None);



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

						Vector3 positionOfCell = hitInfo.transform.position;
						positionOfCell.y = 0.2f;
						positionOfCell.z = positionOfCell.z -0.35f;
						selectedPiece.transform.position = positionOfCell;
					
						DeselectPiece ();

					}
				} else if (regex.IsMatch(hitInfo.transform.gameObject.tag)) {

					if (selectedPiece != null) {
						DeselectPiece ();

					} else {
						selectedPiece = hitInfo.transform.gameObject.GetComponent<Piece> ();
						selectedPiece.SetLight (true);
					}

				}else {
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
