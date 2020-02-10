using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PrizeScript : MonoBehaviour
{

    ParticleSystem prizeBurst;
    public static int currentLevel = 0;
    public int targetScore;

    // Start is called before the first frame update
    void Start()
    {
        prizeBurst = GetComponent<ParticleSystem>();
        targetScore = PlayerController.instance.score * 2+5; //score grading


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D (Collision2D collision)
    {
        //when hit by anything move to a random position on screen
        transform.position = new Vector2 (Random.Range (-6,6), Random.Range(-4,4));
        prizeBurst.Play();

       if(collision.gameObject.tag == "player1"){

       PlayerController.instance.score++;
        Debug.Log ("Score: " + PlayerController.instance.score);
       }

        if(PlayerController.instance.score > targetScore)
        {
            currentLevel ++;
            SceneManager.LoadScene(currentLevel);
        }
    }
}
