using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class NavigatorManager : MonoBehaviour
{
    //load screen sign in and sign up
    public void GotoAuthEmail()
    {
        SceneManager.LoadScene("AuthEmailScreen");
    }

    //load screen main menu game
    public void GotoGameMenu()
    {
        SceneManager.LoadScene("GameMenuScene");
    }

    //load login screen
    public void GotoMainLogin()
    {
        SceneManager.LoadScene(0);
    }

    // game screen
    public void GotoGameScrene()
    {
        SceneManager.LoadScene("GameScene");
    }

}
