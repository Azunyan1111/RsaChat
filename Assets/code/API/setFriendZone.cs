using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class setFriendZone : MonoBehaviour {

	public static float timeleft;
	public static float timeleft2;

	void Start () 
	{
		timeleft 	= 1000000.0f;
        timeleft2 	= 1000000.0f;					
	}

	public void OnClick() {
		// set
		StartCoroutine(set_friend_zone(GameData.UserData.url + "set_friend_zone", 
		GameData.UserData.username, GameData.UserData.terminal_hash));
		// get new friend zone
		timeleft = 5.0f;
	}

	void Update () 
	{
		timeleft -= Time.deltaTime;
		timeleft2 -= Time.deltaTime;
        if (timeleft <= 0.0) {
            timeleft = 5.0f;			
			//get
			StartCoroutine(get_friend_zone_result(GameData.UserData.url + "get_friend_zone_result", 
			GameData.UserData.username, GameData.UserData.terminal_hash));
		}
	}

	IEnumerator set_friend_zone(string url, string username_, string terminal_hash_) {
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
			// TODO: print error, pls Retry.
		}
		if (www.text == "ok")
		{
			var errorMessage = UnityEngine.GameObject.Find("TextErrorMessage_").GetComponent<Text>();
			errorMessage.text = "接続中";
		}
		else
		{
			var errorMessage = UnityEngine.GameObject.Find("TextErrorMessage_").GetComponent<Text>();
			errorMessage.text = "エラー:再試行してください。";
		}
		Debug.Log(www.text);
    }
	IEnumerator get_friend_zone_result(string url, string username_, string terminal_hash_) {
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
			// TODO: print error, pls Retry.
		}
		if (www.text == "ok")
		{
			var errorMessage = UnityEngine.GameObject.Find("TextErrorMessage_").GetComponent<Text>();
			errorMessage.text = "マッチング";
			SceneManager.LoadScene("FriendList");
		}
		else
		{
			// set
			StartCoroutine(set_friend_zone(GameData.UserData.url + "set_friend_zone", 
			GameData.UserData.username, GameData.UserData.terminal_hash));
		}
		Debug.Log(www.text);
    }
}
