using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartEvent : MonoBehaviour {

	// Use this for initialization
	void Start () {
		if (GameData.UserData.username != null)
		{
			SceneManager.LoadScene("DataLoad");
		}
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
