using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverController : MonoBehaviour {

	Animator animator;

	// Use this for initialization
	void Start () {
		gameObject.GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void GameOver(){
		animator.SetTrigger ("gameOver");
	}
}
