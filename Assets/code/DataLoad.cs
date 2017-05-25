using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DataLoad : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Invoke("NextScene", 2.5f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void NextScene(){
		// TODO: load main window
		SceneManager.LoadScene("FriendList");
	}
}
