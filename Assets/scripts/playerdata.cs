using UnityEngine;
using System.Collections;
using System;
using System.IO;
using LitJson;
using UnityEngine.UI;
public class playerdata : MonoBehaviour {
    public Text usernametext;
    public string username;
    public Text leveltext;
    public string level;
    private JsonData playerData;
    public Canvas servererrormessage;
    public string uid;

    void Start () {

        Debug.Log("Retrieving Player Data");
        Console.WriteLine("Retrieving Player Data");
        uid = PlayerPrefs.GetString("UID");
        string url = "http://127.0.0.1/project45/?uid=" + uid;
        WWW www = new WWW(url);
        StartCoroutine(WaitForRequest(www));

    }
    IEnumerator WaitForRequest(WWW www)
    {
        yield return www;

     
        if (www.error == null)
        {
            string read = www.text;
           
    


            string json = read;
     
        
            TestReadingArray(json);
            Rt(json);
        }
        else
        {
            Debug.Log("WWW Error: " + www.error);
            servererrormessage.enabled = true;
        }
    }

    void Update () {

        usernametext.text = username;
        leveltext.text = "Level " + level;
        uid = PlayerPrefs.GetString("UID");

    }

    static void TestReadingArray(string json_array)
    {
        JsonReader defaultReader;

        defaultReader = new JsonReader(json_array);

       
        ReadArray(defaultReader);
      
    }
  
    static void ReadArray(JsonReader reader)
    {
       

        try
        {
            JsonData data = JsonMapper.ToObject(reader);

                Debug.Log(data[0]["username"]);
             
            playerdata test = new playerdata();
          string username = (string) data[0]["username"];
            test.Rt(username);
        }
        catch
        {
            Debug.LogError("GD array error");
            
        }
    }
    public void Rt(string player)
    {
        JsonData data = JsonMapper.ToObject(player);
        username = (string)data[0]["username"];
        string exp1 = (string)data[0]["exp"];
       int exp = Int32.Parse(exp1);
        int lvl = exp / 1200;

        level = lvl.ToString();
        
           
    }
}
