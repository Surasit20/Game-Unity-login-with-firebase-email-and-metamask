using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Auth;
using UnityEngine.SceneManagement;
using TMPro;
public class AuthMangaerScript : MonoBehaviour
{
    
    private FirebaseAuth auth; //create instabt firebase auth variable
    public TMP_Text accountInfo;

    private float timeRemaining = 15; //set time remaining 15 second
    //private float timeRemaining = 60*5; //set time remaining 5 minute
    private void Start()
    {
        auth = FirebaseAuth.DefaultInstance;
        //set info an account of user
        accountInfo.text = "Your Account: " + PlayerPrefs.GetString("Account") + "\n" + "Type Login: " + PlayerPrefs.GetString("TypeAccount");
    }

    private void Update()
    {
        //when stay still over 5 minute then logout
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            Debug.Log(timeRemaining);
        }
        else
        {
            SignOutButton();
        }

        //check don't have account
        if (PlayerPrefs.GetString("TypeAccount") == "" || PlayerPrefs.GetString("Account") == "")
        {
            SceneManager.LoadScene(0);
        }
    }
    //logout
    public void SignOutButton()
    {   
        //logout email
        if(PlayerPrefs.GetString("TypeAccount") == "Email")
        {
            auth.SignOut();
            PlayerPrefs.SetString("Account", "");
            PlayerPrefs.SetString("TypeAccount", "");
            SceneManager.LoadScene(0);
        }
        //logout metamask
        else if (PlayerPrefs.GetString("TypeAccount") == "Metamask")
        {
            PlayerPrefs.SetString("Account", "");
            PlayerPrefs.SetString("TypeAccount", "");
            SceneManager.LoadScene(0);
        }
    }

}

