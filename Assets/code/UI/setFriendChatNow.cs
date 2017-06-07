using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class setFriendChatNow : MonoBehaviour {

	public void OnClick() {

		var text = this.GetComponentInChildren<Text>();
		GameData.UserData.now_chat_friend = text.text;
		Debug.Log(GameData.UserData.now_chat_friend);
		SceneManager.LoadScene("Chat");	
	}
}
