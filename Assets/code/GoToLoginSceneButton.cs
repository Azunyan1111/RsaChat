using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class GoToLoginSceneButton : MonoBehaviour {

	public void OnClick() {
		SceneManager.LoadScene("Login");
	}
}
