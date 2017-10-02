using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class scr : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Ray ray;
		RaycastHit hit;

		ray = Camera.current.ScreenPointToRay(new Vector3(Event.current.mousePosition.x, SceneView.currentDrawingSceneView.camera.pixelHeight - Event.current.mousePosition.y));
		float x1, y1, z1, x2, y2, z2;
		if (Physics.Raycast(ray, out hit))
		{
			x1 = Input.mousePosition.x;
			y1 = Input.mousePosition.y;
			z1 = Input.mousePosition.z;
			x2 = hit.point.x;
			y2 = 0;
			z2 = hit.point.z;

			Debug.Log (x2 + " " + y2 + " " + z2);
		}

	}
}
