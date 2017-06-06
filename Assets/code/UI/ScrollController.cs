using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScrollController : MonoBehaviour {

	[SerializeField]
	RectTransform prefab = null;

	void Start () 
	{
		Debug.Log(GameData.UserData.friend_list);		
		string[] friend_list = GameData.UserData.friend_list.Split(',');
		foreach (string stData in friend_list) {
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
}