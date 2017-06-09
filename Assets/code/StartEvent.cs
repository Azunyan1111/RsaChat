using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartEvent : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GameData.Reset();
		Screen.fullScreen = false;
		// GameData.UserData.url = "http://192.168.1.4:5000/";
		StartCoroutine(get_server_ip("http://azunyan.me/chat_api/"));
		if (GameData.UserData.username != null)
		{
			SceneManager.LoadScene("DataLoad");
		}
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator get_server_ip(string url) {
		
		// WWWForm form = new WWWForm();
        // accsess
        WWW www = new WWW(url);//, form);
        yield return www;
		// error print
		if (!string.IsNullOrEmpty(www.error))
		{
			// Retry.
		}
		GameData.UserData.url = www.text;
		Debug.Log(www.text);
		GameData.Save();
    }
}
