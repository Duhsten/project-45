using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using LitJson;
using UnityEngine.SceneManagement;

public class login : MonoBehaviour {
    public  InputField username;
    public InputField password;
    public Canvas loggingin;
    public string user;
    public string pass;

    void Start () {

    }
    
    void Update()
    {
        user = username.text;
        pass = password.text;
    }

    public void LoginClick()
    {
        loggingin.enabled = true;
        user = username.text;
        pass = password.text;
        string url = "127.0.0.1/project45/login.php";

        WWWForm form = new WWWForm();
        form.AddField("username", user);
        form.AddField("password", pass);
        WWW www = new WWW(url, form);

        StartCoroutine(WaitForRequest(www));
    }

    IEnumerator WaitForRequest(WWW www)
    {
        yield return www;

        // check for errors
        if (www.text == "error")
        {
            Debug.Log("Login Error!: " + www.text);
        }
        else
        {
            logintrue(www.text);
        }
    }
    
    private void logintrue(string user)
    {
        string url = "http://127.0.0.1/project45/user.php?username=" + user;
        WWW www = new WWW(url);
        StartCoroutine(WaitForRequest2(www));
    }

    IEnumerator WaitForRequest2(WWW www)
    {
        yield return www;

        // check for errors
        if (www.error == null)
        {
            string read = www.text;

            string json = read;

            JsonReader defaultReader;

            defaultReader = new JsonReader(json);
            JsonData data = JsonMapper.ToObject(defaultReader);

            Debug.Log(data[0]["uid"]);

            playerdata test = new playerdata();
            string uid = (string)data[0]["uid"];

            PlayerPrefs.SetString("UID", uid);

            SceneManager.LoadScene("menu");

        }
        else
        {
            Debug.Log("WWW Error: " + www.error);
            SceneManager.LoadScene("auth");
        }
    }
 
 
}
