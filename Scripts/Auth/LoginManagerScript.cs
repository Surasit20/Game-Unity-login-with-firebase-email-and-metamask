using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoginManagerScript : MonoBehaviour
{
    public Toggle rememberMe;
    public GameObject loading;

    

    async public void OnLogin()
    {
        // get current timestamp
        int timestamp = (int)(System.DateTime.UtcNow.Subtract(new System.DateTime(1970, 1, 1))).TotalSeconds;
        // set expiration time
        int expirationTime = timestamp + 60;
        // set message
        string message = expirationTime.ToString();

        //start loading
        loading.SetActive(true);
        // sign message
        string signature = await Web3Wallet.Sign(message);
        // verify account
        string account = await EVM.Verify(message, signature);
       
        int now = (int)(System.DateTime.UtcNow.Subtract(new System.DateTime(1970, 1, 1))).TotalSeconds;
        // validate
        if (account.Length == 42 && expirationTime >= now) {
            loading.SetActive(false);
            // save account
            PlayerPrefs.SetString("Account", account);
            PlayerPrefs.SetString("TypeAccount", "Metamask");
 
            print("Account: " + account);
            // load next scene
            SceneManager.LoadScene("GameMenuScene");
        }
        //end loading
        loading.SetActive(false);
    }
}
