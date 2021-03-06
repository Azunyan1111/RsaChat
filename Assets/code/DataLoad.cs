﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DataLoad : MonoBehaviour {

	// Use this for initialization
	void Start () {
		StartCoroutine(get_friend(GameData.UserData.url + "get_friend", GameData.UserData.username, GameData.UserData.terminal_hash));
		// Invoke("NextScene", 2.5f);
	}
	
    IEnumerator get_friend(string url, string username_, string terminal_hash_) {
		
		WWWForm form = new WWWForm();

		var send_data = new 
		{
			username = username_,
			terminal_hash = terminal_hash_,
		};
		string send_data_json = LitJson.JsonMapper.ToJson(send_data);
		form.AddField("json", send_data_json);

        // accsess
        WWW www = new WWW(url, form);
        yield return www;
		// error print
		if (!string.IsNullOrEmpty(www.error))
		{
			// Retry.
			SceneManager.LoadScene("DataLoad");
		}
		GameData.UserData.friend_list = www.text;
		Debug.Log(www.text);
		GameData.Save();
		SceneManager.LoadScene("FriendList");	
    }
}
