using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScrollController2 : MonoBehaviour {

	[SerializeField]
	RectTransform prefab_my = null;
	[SerializeField]
	RectTransform prefab_friend = null;
	/* timer */
	public static float timeleft;

	/*
	void Start () 
	{

		/* frast chat print 
		// get chat data. and save now_chat_data.
		StartCoroutine(get_chat("http://0.0.0.0:5000/get_chat", 
								GameData.UserData.username, GameData.UserData.now_chat_friend, GameData.UserData.terminal_hash));
		// get saved chat data.
		string cat_data = GameData.UserData.now_chat_data;
		// to json.
		LitJson.JsonData jsonData =  LitJson.JsonMapper.ToObject(cat_data);
		// print chats.
		for (int i = 0; i < jsonData.Count; i ++)
		{	
			if(jsonData[i]["user"].ToString() == GameData.UserData.username)
			{
				var item = GameObject.Instantiate(prefab_my) as RectTransform;
				item.SetParent(transform, false);
				var text = item.GetComponentInChildren<Text>();			
				text.text = jsonData[i]["chat"].ToString();
			}
			else
			{
				var item = GameObject.Instantiate(prefab_friend) as RectTransform;	
				item.SetParent(transform, false);
				var text = item.GetComponentInChildren<Text>();			
				text.text = jsonData[i]["chat"].ToString();			
			}
		}
	} */
	void Update () 
	{
		timeleft -= Time.deltaTime;
        if (timeleft <= 0.0) {
            timeleft = 10.0f;
			// remove all chat object
			foreach ( Transform n in GameObject.Find("Content_").transform )
			{
				GameObject.Destroy(n.gameObject);
			}
			// get chat data. and save now_chat_data.
			StartCoroutine(get_chat("http://0.0.0.0:5000/get_chat", 
									GameData.UserData.username, GameData.UserData.now_chat_friend, GameData.UserData.terminal_hash));
			// get saved chat data.
			string cat_data = GameData.UserData.now_chat_data;
			// to json.
			LitJson.JsonData jsonData =  LitJson.JsonMapper.ToObject(cat_data);
			// print chats.
			for (int i = 0; i < jsonData.Count; i ++)
			{	
				if(jsonData[i]["user"].ToString() == GameData.UserData.username)
				{
					var item = GameObject.Instantiate(prefab_my) as RectTransform;
					item.SetParent(transform, false);
					var text = item.GetComponentInChildren<Text>();			
					text.text = jsonData[i]["chat"].ToString();
				}
				else
				{
					var item = GameObject.Instantiate(prefab_friend) as RectTransform;	
					item.SetParent(transform, false);
					var text = item.GetComponentInChildren<Text>();			
					text.text = jsonData[i]["chat"].ToString();			
				}
			}
        }
	}	

	IEnumerator get_chat(string url, string username_, string friend_username_ , string terminal_hash_) {
		
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
		// {"1496815758,67": {"user": "hoge", "chat": "admin is noob"}, "1496815757,58": {"user": "admin", "chat": "fuck"}}
		GameData.UserData.now_chat_data = www.text;
		GameData.Save();
		Debug.Log("end get chat.");
		Debug.Log(www.text);
    }
}