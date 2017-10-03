using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text.RegularExpressions;

public class CheckersBoard : MonoBehaviour {

	public GameObject greenPiecePrefab;
	public GameObject redPiecePrefab;
	public GameObject yellowPiecePrefab;
	public Player currentPlayer;


	private Piece selectedPiece;
	private Regex regex = new Regex(@"\w*Piece\b", RegexOptions.None);


	private int countOfCompletedActions;
	private GameManager gameManager;

	// Use this for initialization
	void Start () {
		countOfCompletedActions = 0;
		gameManager = GetComponent<GameManager> ();
		currentPlayer = gameManager.currentPlayer;

	}


	// Update is called once per frame
	void Update () {
		
		if (CheckPlayerCompletedAction ())
			countOfCompletedActions++;

		if (countOfCompletedActions > 1) {
			currentPlayer = gameManager.NextPlayer ();
			countOfCompletedActions = 0;
		}
			
			
	}

	private bool CheckPlayerCompletedAction(){
		bool actionCompleted = false;

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

						float distance = Vector3.Distance (selectedPiece.transform.position, hitInfo.transform.position);

						Debug.Log ("Distance " + distance);

						//if (distance > 1.5f && distance < 4.4f) {

						if (distance < 2.4f) {

							Vector3 positionOfCell = hitInfo.transform.position;
							positionOfCell.y = 0.22f;	
							positionOfCell.z = positionOfCell.z - 0.35f;
							selectedPiece.transform.position = positionOfCell;

							actionCompleted = true;
						} else {
							countOfCompletedActions = 0;
						}
							
						//}

						DeselectPiece ();
					}
				} else if (regex.IsMatch(hitInfo.transform.gameObject.tag)) {


					if (selectedPiece != null) {
						countOfCompletedActions = 0;
						DeselectPiece ();

					} else if (GetPermission (hitInfo.transform.gameObject.tag)) {
						selectedPiece = hitInfo.transform.gameObject.GetComponent<Piece> ();
						selectedPiece.SetLight (true,selectedPiece.transform.position);

						actionCompleted = true;
					} else 
						DeselectPiece ();

				}else {
					countOfCompletedActions = 0;
					Debug.Log ("Nog");
					DeselectPiece ();
				}

			} else {
				Debug.Log("No hit");
			}
			//Debug.Log("Mouse is down");
		} 
		return actionCompleted;
	}

	private bool GetPermission(string tag){
		return tag.Equals (currentPlayer.colorOfPieces + "Piece");
	}

	private void DeselectPiece(){
		if (selectedPiece != null) {
			selectedPiece.SetLight (false,new Vector3());
			selectedPiece = null;
		}
	}


}
