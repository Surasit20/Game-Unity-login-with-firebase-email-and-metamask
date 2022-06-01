using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class FloorColliderScript : MonoBehaviour
{
    public Slider healthSlider;
    private int health = 100; //max HP
    private void OnTriggerEnter2D(Collider2D fruitOb)
    {
        //reduce hp
        if (fruitOb.tag == "Fruit")
        {
            health -= 25;
            if (health <= 0)
            {
                SceneManager.LoadScene("GameMenuScene");
            }
            Destroy(fruitOb.gameObject);
            healthSlider.value = health ;
        }
    }
}
