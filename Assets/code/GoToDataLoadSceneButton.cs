using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GoToDataLoadSceneButton : MonoBehaviour {

	string username;
	string password;
	UnityEngine.GameObject errorMessage;

	public void OnClick() {
		username = UnityEngine.GameObject.Find("Input Username").GetComponent<InputField>().text;
		password = UnityEngine.GameObject.Find("Input Password").GetComponent<InputField>().text;
		errorMessage = UnityEngine.GameObject.Find("TextErrorMessage");
		StartCoroutine(signup("http://0.0.0.0:5000/signup", username, password, "key", "hash"));
	}

    IEnumerator signup(string url, string username, string password, string public_key, string terminal_hash) {
		WWWForm form = new WWWForm();
		form.AddField("username", username);
		form.AddField("password", password);
		form.AddField("public_key_base64", public_key);
		form.AddField("terminal_hash", terminal_hash);

        // accsess
        WWW www = new WWW(url, form);
        yield return www;
		// error
		if (!string.IsNullOrEmpty(www.error))
		{
			errorMessage.GetComponent<Text>().text = "Error. Please Rytry.";
		}
		if(www.text == "ok")
		{
			SceneManager.LoadScene("DataLoad");			
		}
		else
		{
			errorMessage.GetComponent<Text>().text = www.text;
		}
    }
}
