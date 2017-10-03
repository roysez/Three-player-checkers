using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour 
{
	public float _smoothTime = 0.6f;
	public int idtest;

	private GameManager gameManager;
	// 1 - green
	// 2 - yellow
	// 3 - red

	private float[] _rotList = new float[]{0.0f, -120f, -240f};

	private void Start() {
		gameManager = GameObject.Find ("Desk").GetComponent<GameManager> ();
	}
	private void FixedUpdate()
	{
		Rotate (gameManager.currentPlayer.id);
	}

	public void Rotate(int id)
	{
		float yTo = _rotList [id];

		Quaternion to = Quaternion.Euler (0, yTo, 0);
		transform.rotation = Quaternion.Slerp (transform.rotation, to, _smoothTime* Time.deltaTime);
	}

}
