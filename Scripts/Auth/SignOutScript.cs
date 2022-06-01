using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Firebase;
using Firebase.Auth;
public class SignOutScript : MonoBehaviour
{
    // Start is called before the first frame update
    private FirebaseAuth auth;
    private void Start()
    {
        auth = FirebaseAuth.DefaultInstance;
    }
    public void SignOutButton()
    {
        if (PlayerPrefs.GetString("TypeAccount") == "Firebase")
        {
            auth.SignOut();
            PlayerPrefs.SetString("Account", "");
            PlayerPrefs.SetString("TypeAccount", "");
            SceneManager.LoadScene(0);

        }
        else if(PlayerPrefs.GetString("TypeAccount") == "Metamask")
        {
            PlayerPrefs.SetString("Account", "");
            PlayerPrefs.SetString("TypeAccount", "");
            SceneManager.LoadScene(0);
        }
    }
}
