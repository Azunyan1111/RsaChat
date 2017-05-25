using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class GoToNewFriendSceneButton : MonoBehaviour {

	public void OnClick() {
		SceneManager.LoadScene("NewFriend");
	}
}
