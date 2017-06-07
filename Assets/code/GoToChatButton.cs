using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GoToChatButton : MonoBehaviour {

	public void OnClick() {
		SceneManager.LoadScene("Chat");
	}
}
