using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class sendChatData : MonoBehaviour {


	[SerializeField]
	RectTransform prefab_my = null;

	// Use this for initialization
	public void OnClick() {
		var text = GameObject.Find("SendChatInput").GetComponent<InputField>().text;
		// set chat test.
		StartCoroutine(set_chat("http://0.0.0.0:5000/set_chat", 
								GameData.UserData.username, GameData.UserData.now_chat_friend,
								text, GameData.UserData.terminal_hash));
		ScrollController2.timeleft = 0.1f;
	}
	IEnumerator set_chat(string url, string send_username_, string receive_username_, string chat_data_, string terminal_hash_) {
		
		WWWForm form = new WWWForm();

		var send_data = new 
		{
			send_username = send_username_,
			receive_username = receive_username_,
			chat_data = chat_data_,
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
			// TODO: print error, pls Retry.
		}
		Debug.Log(www.text);
    }

}
