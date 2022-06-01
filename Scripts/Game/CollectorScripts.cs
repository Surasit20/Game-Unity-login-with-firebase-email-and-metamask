using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class CollectorScripts : MonoBehaviour
{
    public TMP_Text scoreText;
    private int score;
    void increaseScore()
    {
        score++;
        scoreText.text = "Score:" + score;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Enemy")
        {
            increaseScore();
            collision.gameObject.SetActive(false);

        } 
    }
   
}
