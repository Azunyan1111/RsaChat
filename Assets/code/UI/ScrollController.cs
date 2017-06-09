using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScrollController : MonoBehaviour {

	[SerializeField]
	RectTransform prefab = null;
	[SerializeField]
	RectTransform my_line = null;
	[SerializeField]
	RectTransform friend_line = null;

	void Start () 
	{
		// add friend
		StartCoroutine(get_friend(GameData.UserData.url + "get_friend", GameData.UserData.username, GameData.UserData.terminal_hash));

		// my profile and line
		// add line
		var item_my_line = GameObject.Instantiate(my_line) as RectTransform;
		item_my_line.SetParent(transform, false);
		// my profile
		var item_my = GameObject.Instantiate(prefab) as RectTransform;
		item_my.SetParent(transform, false);
		var text_my = item_my.GetComponentInChildren<Text>();
		text_my.text = GameData.UserData.username;
		// friend line
		var item_friend_line = GameObject.Instantiate(friend_line) as RectTransform;
		item_friend_line.SetParent(transform, false);

		string[] friend_list = GameData.UserData.friend_list.Split(',');
		// not internet
		if (friend_list.Length == 0){ return; }				
		
		// add friend
		foreach (string stData in friend_list) {
			if(stData == GameData.UserData.username)
			{
				continue;				
			}
			var item = GameObject.Instantiate(prefab) as RectTransform;
			item.SetParent(transform, false);
			var text = item.GetComponentInChildren<Text>();
			text.text = stData;
		}
		
		// for(int i=0; i<15; i++)
		// {
			// var item = GameObject.Instantiate(prefab) as RectTransform;
			// item.SetParent(transform, false);
			// var text = item.GetComponentInChildren<Text>();
			// 
			// text.text = "item:" + i.ToString();
		// }
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
		}
		GameData.UserData.friend_list = www.text;
		Debug.Log(www.text);
		GameData.Save();
    }
}