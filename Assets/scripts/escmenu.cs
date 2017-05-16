using UnityEngine;
using System.Collections;

public class escmenu : MonoBehaviour {
    private bool isShowing;
    public Canvas Menu;
    // Use this for initialization
    void Start () {
        Menu.enabled = false;

    }

    // Update is called once per frame
    bool Pause = false;
    void Update () {
        if (Pause == false)
        {
            Time.timeScale = 1;
        }

        else
        {
            Time.timeScale = 0;
        }

      
        if (Input.GetKey(KeyCode.Escape))
        {
            System.Threading.Thread.Sleep(300);
            if (Pause == true)
            {
                Cursor.visible = false;
                Menu.enabled = false;
                Pause = false;
            }

            

            else
            {
                Cursor.visible = true;
                Menu.enabled = true;
                Pause = true;
            }
        }
    }
}
