using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class setNewFriendZone : MonoBehaviour {

	public void OnClick() {
		var text = this.GetComponentInChildren<Text>();
		GameData.UserData.now_chat_friend = text.text;
		if(text.text == "Online user not found")
		{
			return;
		}

		// get new friend zone
		StartCoroutine(new_friend_zone_add_friend(GameData.UserData.url + "new_friend_zone_add_friend", 
											GameData.UserData.username, text.text, GameData.UserData.terminal_hash));
		
		

		SceneManager.LoadScene("DataLoad");	
	}

	IEnumerator new_friend_zone_add_friend(string url, string username_, string friend_username_, string terminal_hash_) {
		WWWForm form = new WWWForm();
		var send_data = new 
		{
			username = username_,
			friend_username = friend_username_,
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
