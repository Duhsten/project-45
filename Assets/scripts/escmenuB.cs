using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class escmenuB : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void leave()
    {
        SceneManager.LoadScene("menu");
    }

    public void Exit()
    {
        Application.Quit();
    }
}
