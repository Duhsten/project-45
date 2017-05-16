using UnityEngine;
using System.Collections;

public class playermovement : MonoBehaviour
{
    Animator playercontroller;
    int jumpHash = Animator.StringToHash("Jump");


    // Use this for initialization
    void Start()
    {

        playercontroller = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {

      
            float move = Input.GetAxis("Vertical");
            playercontroller.SetFloat("Speed", move);

            if(Input.GetKeyDown(KeyCode.Space))
            {
                playercontroller.SetTrigger(jumpHash);
            }
        else
        {
            playercontroller.ResetTrigger("Jump");
        }

        
    }
}
