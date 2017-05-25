using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class GoToDataLoadSceneButton : MonoBehaviour {

	public void OnClick() {
		SceneManager.LoadScene("DataLoad");
	}
}
