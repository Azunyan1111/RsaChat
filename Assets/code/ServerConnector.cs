using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using LitJson;


public class ServerConnector : MonoBehaviour {

    public ServerConnector () { // Private Constructor
        // Debug.Log("Create SampleSingleton instance.");
        // Debug.Log("hoge");
    }

    // public static ServerConnector Instance {
        // get {
            // if( mInstance == null ) mInstance = new ServerConnector();
            // return mInstance;
        // }
    // }

    IEnumerator signup(string url, string username, string password, string public_key, string terminal_hash) {
		WWWForm form = new WWWForm();
		form.AddField("username", username);
		form.AddField("password", password);
		form.AddField("public_key_base64", public_key);
		form.AddField("terminal_hash", terminal_hash);

        // accsess
        WWW www = new WWW(url, form);
        yield return www;    
        Debug.Log(www.text);
    }

    // test connection to google.
    public IEnumerator google()
    {
        WWW www = new WWW("http://google.co.jp");
        yield return www;    
        Debug.Log(www.text);
    }
}