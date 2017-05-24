using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GoToNewAddressSceneButton : MonoBehaviour {

	public void OnClick() {
		SceneManager.LoadScene("NewAddress");
	}
}