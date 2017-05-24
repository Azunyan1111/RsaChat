using UnityEngine;
using System.Collections;

public class ButtonScript : MonoBehaviour {

	// resize button
	public void Awake(){
		Debug.Log("frist start");
	}

	/// ボタンをクリックした時の処理
	public void OnClick() {
		Debug.Log("Button click!");
	}
}