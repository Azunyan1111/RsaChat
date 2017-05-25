using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GoToSignUpSceneButton : MonoBehaviour {

	public void OnClick() {
		SceneManager.LoadScene("SignUp");
	}
}