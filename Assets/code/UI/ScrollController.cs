using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScrollController : MonoBehaviour {

	[SerializeField]
	RectTransform prefab = null;

	void Start () 
	{
		// add friend
		StartCoroutine(get_friend("http://192.168.1.4:5000/get_friend", GameData.UserData.username, GameData.UserData.terminal_hash));

		Debug.Log(GameData.UserData.friend_list);		
		string[] friend_list = GameData.UserData.friend_list.Split(',');
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