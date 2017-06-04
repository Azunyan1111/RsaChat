using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;
using System.Text;


public class GoToDataLoadSceneButton : MonoBehaviour {

	string username;
	string password;
	UnityEngine.GameObject errorMessage;

	public void OnClick() {
		username = UnityEngine.GameObject.Find("Input Username").GetComponent<InputField>().text;
		password = UnityEngine.GameObject.Find("Input Password").GetComponent<InputField>().text;
		errorMessage = UnityEngine.GameObject.Find("TextErrorMessage");
		if (SceneManager.GetActiveScene().name == "SignUp")
		{
			StartCoroutine(signup("http://0.0.0.0:5000/signup", username, password, "key", getRandamString(32)));				
		}
	}

    IEnumerator signup(string url, string username, string password, string public_key, string terminal_hash) {
		errorMessage.GetComponent<Text>().text = "";		
		
		WWWForm form = new WWWForm();
		form.AddField("username", username);
		form.AddField("password", password);
		form.AddField("public_key_base64", public_key);
		form.AddField("terminal_hash", terminal_hash);

        // accsess
        WWW www = new WWW(url, form);
        yield return www;
		// error print
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

	private string getRandamString(int length)
	{
		string passwordChars = "0123456789abcdefghijklmnopqrstuvwxyz";

		StringBuilder sb = new StringBuilder(length);
		System.Random r = new System.Random();

		for (int i = 0; i < length; i++)
		{
			//文字の位置をランダムに選択
			int pos = r.Next(passwordChars.Length);
			//選択された位置の文字を取得
			char c = passwordChars[pos];
			//パスワードに追加
			sb.Append(c);
		}

		return sb.ToString();
	}
}
