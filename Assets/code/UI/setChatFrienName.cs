using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class setChatFrienName : MonoBehaviour {

	// Use this for initialization
	void Start () {
		var text = this.GetComponentInChildren<Text>();
		text.text = GameData.UserData.now_chat_friend;
	}
}
