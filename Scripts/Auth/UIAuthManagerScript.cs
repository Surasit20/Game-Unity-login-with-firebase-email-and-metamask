using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIAuthManagerScript : MonoBehaviour
{
    // create instance
   
    //UI object 
    public GameObject signinUI;
    public GameObject signupUI;

    
    //load signin screen
    public void SignInScreenButton() 
    {
        signinUI.SetActive(true);
        signupUI.SetActive(false);
    }
    //load signup screen
    public void SignUpScreenButton() 
    {
        signinUI.SetActive(false);
        signupUI.SetActive(true);
    }
}
