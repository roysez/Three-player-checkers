using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingsButton : MonoBehaviour 
{




	public void Restart ()
	{
		SceneManager.LoadScene ("main");
	}

	public void ExitGame ()
	{
		#if UNITY_STANDALONE
			Application.Quit ();
		#endif
		#if UNITY_EDITOR
		UnityEditor.EditorApplication.isPlaying = false;
		#endif
	}

}
