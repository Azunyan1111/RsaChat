using UnityEngine;
using System.Collections;
using UnityEngine.UI;
// using UnityEngine.UI.ScrollRect;

public class ScrollController3 : MonoBehaviour {

	[SerializeField]
	RectTransform prefab_my = null;
	/* timer */
	public static float timeleft;

	
	void Start () 
	{
		timeleft = 0.1f;
		var item = GameObject.Instantiate(prefab_my) as RectTransform;
		item.SetParent(transform, false);
		var text = item.GetComponentInChildren<Text>();			
		text.text = "Now Loading";
		
	} 
	void Update () 
	{
		timeleft -= Time.deltaTime;
        if (timeleft <= 0.0) {
            timeleft = 20.0f;
			// set new friend zone
			StartCoroutine(set_new_firend_zone(GameData.UserData.url + "set_new_friend_zone", 
												GameData.UserData.username, GameData.UserData.terminal_hash));
			// get new friend zone
			StartCoroutine(get_new_firend_zone(GameData.UserData.url + "get_new_friend_zone", 
												GameData.UserData.username, GameData.UserData.terminal_hash));
			
        }
	}	

	IEnumerator set_new_firend_zone(string url, string username_, string terminal_hash_) {
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
		Debug.Log("set_newFriend_zone" + ":" + www.text);
    }
	IEnumerator get_new_firend_zone(string url, string username_, string terminal_hash_) {
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
		
		// remove all chat object
		foreach ( Transform n in GameObject.Find("Content_").transform )
		{
			GameObject.Destroy(n.gameObject);
		}
		Debug.Log(www.text);
		
		

		string[] friend_list = www.text.Split(',');
		if(friend_list.Length == 1)
		{
			var item = GameObject.Instantiate(prefab_my) as RectTransform;
			item.SetParent(transform, false);
			var text = item.GetComponentInChildren<Text>();
			text.text = "Online user not found";
		}
		foreach (string stData in friend_list) {
			if(stData == GameData.UserData.username)
			{
				continue;
			}
			var no_print = false;
			foreach (string stFriend in GameData.UserData.friend_list.Split(','))
			{
				if(stData == stFriend)
				{
					Debug.Log(stData + ":" + stFriend);
					no_print = true;
					continue;
				}
			}
			if(no_print == true)
			{
				continue;
			}
			var item = GameObject.Instantiate(prefab_my) as RectTransform;
			item.SetParent(transform, false);
			var text = item.GetComponentInChildren<Text>();
			text.text = stData;
		}
    }
}