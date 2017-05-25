using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class GoToSignInSceneButton : MonoBehaviour {

	public void OnClick() {
		SceneManager.LoadScene("SignIn");
	}
}
