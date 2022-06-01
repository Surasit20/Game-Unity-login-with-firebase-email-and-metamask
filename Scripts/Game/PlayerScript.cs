using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PlayerScript : MonoBehaviour
{
    //setup variables
    private float speed = 500f;
    private float maxScope = Screen.width;
    private float minScope = 0;
    private int score = 0;

    //set text score

    public TMP_Text  scoreText;
    void FixedUpdate()
    {
        movePlayer();
    }
    private void Start()
    {
        maxScope = transform.localScale.x * maxScope;
    }

    //move player 
    void movePlayer(){
      
        if (Input.GetMouseButton(0))
        {
            Vector3 move = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (move.x > 1 && transform.position.x <= maxScope)
            {
           
                transform.Translate(speed * Time.deltaTime, 0, 0);

            }
            else if (move.x < -1 && transform.position.x >= minScope)
            {
         
                transform.Translate(-speed * Time.deltaTime, 0, 0);
            }
        }
       
    }

    private void OnTriggerEnter2D(Collider2D fruitOb)
    {
        //increase count score
        if (fruitOb.tag == "Fruit")
        {
            score++;
            scoreText.text = "Score: " + score;
            Destroy(fruitOb.gameObject);
        }
       


    }
}
