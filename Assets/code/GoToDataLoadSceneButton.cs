using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;
using System.Collections;
using System.Text;
using System.Security.Cryptography;

public class GoToDataLoadSceneButton : MonoBehaviour {

	string username;
	string password;
	UnityEngine.GameObject errorMessage;
	// string publicKey;
	// string privateKey;

	public void OnClick() {
		username = UnityEngine.GameObject.Find("Username Input").GetComponent<InputField>().text;
		password = UnityEngine.GameObject.Find("Password Input").GetComponent<InputField>().text;
		errorMessage = UnityEngine.GameObject.Find("TextErrorMessage");
		// RSA
		// CreateKey("user_key");		
		string random_string = getRandamString(32);
		if (SceneManager.GetActiveScene().name == "SignUp")
		{
			StartCoroutine(signup("http://192.168.1.4/signup", username, password, "key", random_string));
			/*
			var crypt_dat = Encrypt(publickKey, "Hello World");
			Debug.Log(crypt_dat);
			var decrypt_data = Decrypt(privateKey, crypt_dat);
			Debug.Log(decrypt_data);
			CreateKey("user_key");
			var decrypt_datas = Decrypt(privateKey, crypt_dat);
			Debug.Log(decrypt_datas);			
			DeleteKey("user_key");
			*/
		}
		else if (SceneManager.GetActiveScene().name == "SignIn")
		{
			StartCoroutine(signup("http://192.168.1.4:5000/signin", username, password, "key", random_string));			
		}
		 
	}

    IEnumerator signup(string url, string username_, string password_, string public_key_base64_, string terminal_hash_) {
		errorMessage.GetComponent<Text>().text = "";		
		
		WWWForm form = new WWWForm();

		var send_data = new 
		{
			username = username_,
			password = password_,
			public_key_base64 = public_key_base64_,
			terminal_hash = terminal_hash_,
		};
		string send_data_json = LitJson.JsonMapper.ToJson(send_data);
		form.AddField("json", send_data_json);

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
			GameData.UserData.username = username_;
			GameData.UserData.public_key_base64 = public_key_base64_;
			GameData.UserData.terminal_hash = terminal_hash_;
			GameData.Save();
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
			int pos = r.Next(passwordChars.Length);
			char c = passwordChars[pos];
			sb.Append(c);
		}

		return sb.ToString();
	}
/*
	private void CreateKey(string keyContainerName)
	{
		var size = 1024;
		var parameters = new CspParameters()
		{
			KeyContainerName = keyContainerName
		};
		var csp = new RSACryptoServiceProvider(size, parameters);
		publicKey = csp.ToXmlString(false);
		privateKey = csp.ToXmlString(true);
	}
	private void DeleteKey(string keyContainerName)
	{
		var parameters = new CspParameters()
		{
			KeyContainerName = keyContainerName
		};
		using (var csp = new RSACryptoServiceProvider(parameters))
		{
			csp.PersistKeyInCsp = false;
			csp.Clear();
		}
	}
	public string Encrypt(string publicKey, string data)
	{
		var csp = new RSACryptoServiceProvider();
		csp.FromXmlString(publicKey);
		var encryptedData = csp.Encrypt(Encoding.UTF8.GetBytes(data), false);
		return Convert.ToBase64String(encryptedData);
	}
	private string Decrypt(string privateKey, string data)
	{
		var csp = new RSACryptoServiceProvider();
		csp.FromXmlString(privateKey);
		var decryptedData = csp.Decrypt(Convert.FromBase64String(data), false);
		return Encoding.UTF8.GetString(decryptedData);
	}
	*/
}
