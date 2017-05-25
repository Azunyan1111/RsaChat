using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class GoToFriendListSceneButton : MonoBehaviour {

	public void OnClick() {
		SceneManager.LoadScene("FriendList");
	}
}
