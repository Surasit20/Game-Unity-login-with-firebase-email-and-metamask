using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Auth;
using UnityEngine.SceneManagement;
using TMPro;
public class AuthFirebaseManager : MonoBehaviour
{
    //Auth Variables
    private FirebaseAuth auth;
    //Sign In Variables
    [Header("Login")]
    public TMP_InputField emailLoginField;
    public TMP_InputField passwordLoginField;
    public TMP_Text errorLoginText;


    //Sign Up Variables
    [Header("Register")]
    public TMP_InputField emailRegisterField;
    public TMP_InputField passwordRegisterField;
    public TMP_InputField passwordRegisterVerifyField;
    public TMP_Text errorRegisterText;

    //loadScreen Variables
    public UIAuthManagerScript loadScreen;

    void Start()
    {
        auth = FirebaseAuth.DefaultInstance;
        
    }


    public void SigninButton()
    {
        StartCoroutine(Signin(emailLoginField.text, passwordLoginField.text));
    }


    public void SignupButton()
    {
        if(emailRegisterField.text == "")
        {
            errorRegisterText.text = "Missing Email";
            return;
        }
        else if (passwordRegisterField.text =="" || passwordRegisterVerifyField.text == "")
        {
            errorRegisterText.text = "Password";
            return;
        }
        else if(passwordRegisterField.text != passwordRegisterVerifyField.text)
        {
            errorRegisterText.text = "Password Does Not Match!";
            return;
        }

        StartCoroutine(Signup(emailRegisterField.text, passwordRegisterField.text ));
    }
    private IEnumerator Signin(string _email, string _password)
    {

        var signInTask = auth.SignInWithEmailAndPasswordAsync(_email, _password);
        yield return new WaitUntil(predicate: () => signInTask.IsCompleted);

        if (signInTask.Exception == null)
        {
            SceneManager.LoadScene("GameMenuScene");
            Debug.Log(signInTask.Result.Email);
            PlayerPrefs.SetString("Account", signInTask.Result.Email);
            PlayerPrefs.SetString("TypeAccount", "Email");
         
        }
        else
        {
            FirebaseException firebaseEx = signInTask.Exception.GetBaseException() as FirebaseException;
            AuthError errorCode = (AuthError)firebaseEx.ErrorCode;
            errorLoginText.text = errorCode.ToString();
            Debug.Log(errorCode.ToString());
        }

    }

    private IEnumerator Signup(string _email, string _password)
    {

        var signUpTask = auth.CreateUserWithEmailAndPasswordAsync(_email, _password);
        yield return new WaitUntil(predicate: () => signUpTask.IsCompleted);

        if (signUpTask.Exception == null)
        {
            loadScreen.SignInScreenButton();
            Debug.Log(signUpTask.Result.UserId);
 
        }
        else
        {
            FirebaseException firebaseEx = signUpTask.Exception.GetBaseException() as FirebaseException;
            AuthError errorCode = (AuthError)firebaseEx.ErrorCode;
            errorRegisterText.text = errorCode.ToString();
            Debug.Log(errorCode.ToString());

        }

    }
}
