using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piece : MonoBehaviour {


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void SetLight(bool var,Vector3 position){
		Light light =GameObject.Find ("MovableLight").GetComponent<Light> ();
		if (var) {
			
			position.y = 1.35f;
			light.transform.position = position;
			light.enabled = true;
		} else
			light.enabled = var;

	}
}
