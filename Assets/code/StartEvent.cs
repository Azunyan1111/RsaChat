using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartEvent : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GameData.Reset();
		Screen.fullScreen = false;
		GameData.UserData.url = "http://192.168.1.4:5000/";
		GameData.Save();
		if (GameData.UserData.username != null)
		{
			SceneManager.LoadScene("DataLoad");
		}
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
