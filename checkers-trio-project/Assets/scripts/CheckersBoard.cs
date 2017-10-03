using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text.RegularExpressions;

public class CheckersBoard : MonoBehaviour
{

	public GameObject greenPiecePrefab;
	public GameObject redPiecePrefab;
	public GameObject yellowPiecePrefab;
	public Player currentPlayer;


	private Piece selectedPiece;
	private Regex regex = new Regex (@"\w*Piece\b", RegexOptions.None);


	private int countOfCompletedActions;
	private GameManager gameManager;




	// Use this for initialization
	void Start ()
	{
		countOfCompletedActions = 0;
		gameManager = GetComponent<GameManager> ();
		currentPlayer = gameManager.currentPlayer;
	}


	// Update is called once per frame
	void Update ()
	{

		if (CheckPlayerCompletedAction ())
			countOfCompletedActions++;

		if (countOfCompletedActions > 1) {
			currentPlayer = gameManager.NextPlayer ();
			countOfCompletedActions = 0;
		}


	}

	private bool CheckPlayerCompletedAction ()
	{
		bool actionCompleted = false;

		if (Input.GetMouseButtonDown (0)) {
			//Debug.Log("Mouse is down");

			RaycastHit hitInfo = new RaycastHit ();
			bool hit = Physics.Raycast (Camera.main.ScreenPointToRay (Input.mousePosition), out hitInfo);
			if (hit) {
				Debug.Log ("Hit " + hitInfo.transform.gameObject.name);
				if (hitInfo.transform.gameObject.tag == "BlackCell") {
					
					Vector3 cellPositionToMove = hitInfo.transform.position;



					if (selectedPiece != null) 
					{

						float distance = Vector3.Distance (selectedPiece.transform.position,cellPositionToMove);

						Debug.Log ("Distance " + distance);



						if (distance > 1.5f && distance < 4.4f && CheckIfFree (cellPositionToMove))
						{
							Vector3 centerOfVectors = new Vector3 ((cellPositionToMove.x + selectedPiece.transform.position.x)/2,
								cellPositionToMove.y,
								(cellPositionToMove.z + selectedPiece.transform.position.z)/2	);

								
							if (distance < 2.4f) {
								
								MovePiece (cellPositionToMove);

								actionCompleted = true;
							} else if(!CheckIfEnemy(centerOfVectors)){
								
								Debug.Log ("МОЖНА БИТИ");
								Hit (centerOfVectors);

								MovePiece (cellPositionToMove);

								actionCompleted = true;
							
							} else
								countOfCompletedActions = 0;

						} else
							countOfCompletedActions = 0;
						
						DeselectPiece ();
					}
				} 
				else if (regex.IsMatch (hitInfo.transform.gameObject.tag)) 
				{


					if (selectedPiece != null) {
						countOfCompletedActions = 0;
						DeselectPiece ();

					} else if (GetPermission (hitInfo.transform.gameObject.tag)) {
						selectedPiece = hitInfo.transform.gameObject.GetComponent<Piece> ();
						selectedPiece.SetLight (true, selectedPiece.transform.position);

						actionCompleted = true;
					} else
						DeselectPiece ();

				} else {
					countOfCompletedActions = 0;
					Debug.Log ("Nog");
					DeselectPiece ();
				}

			} else {
				Debug.Log ("No hit");
			}
			//Debug.Log("Mouse is down");
		} 
		return actionCompleted;
	}

	private bool GetPermission (string tag)
	{
		return tag.Equals (currentPlayer.colorOfPieces + "Piece");
	}

	private void DeselectPiece ()
	{
		if (selectedPiece != null) {
			selectedPiece.SetLight (false, new Vector3 ());
			selectedPiece = null;
		}
	}


	private bool CheckIfFree (Vector3 centre)
	{
		Vector3 pieceCenter = new Vector3 (centre.x, centre.y + 0.22f, centre.z - 0.35f);
		Collider[] colliders = Physics.OverlapSphere (pieceCenter, 0.05f);
		Debug.Log ("Size: " + colliders.Length);


		if (colliders.Length == 0) {
			return true;
		} else
			return false;
	}

	private void Hit(Vector3 center){
		Vector3 pieceCenter = new Vector3 (center.x, center.y + 0.22f, center.z - 0.35f);
		Collider[] colliders = Physics.OverlapSphere (pieceCenter, 0.05f);

		Debug.Log ("Видалення" + );

		gameManager.hitPlayer (colliders [0].gameObject.transform.tag);

		colliders [0].gameObject.SetActive (false);

	}

	private void MovePiece(Vector3 cellPositionToMove){
		cellPositionToMove.y = 0.22f;	
		cellPositionToMove.z = cellPositionToMove.z - 0.35f;
		selectedPiece.transform.position = cellPositionToMove;

	}

	private bool CheckIfEnemy(Vector3 center)
	{
		if(CheckIfFree(center)){
			return false;
		}
			else {
			return Physics.OverlapSphere (new Vector3 (center.x, center.y + 0.22f, center.z - 0.35f), 0.05f)[0]
			.gameObject
			.transform
			.tag==currentPlayer.colorOfPieces+"Piece";
			}

	}
}