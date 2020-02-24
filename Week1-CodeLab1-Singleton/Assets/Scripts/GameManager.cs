using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
 
    public static GameManager instance; // create this one only\
   //variable for a countdown timer  public int timerAmt;

   //variable for a count-up timer
    // invoke variable int Timer = 0;
    private float Timer = 0f;

    public  Text scoreText;
    public  Text timerText;




    private void Awake()
    {
        if (instance == null){ // if there isn't one already
            
        instance = this;
        DontDestroyOnLoad(gameObject); //make this the main instance
        
        }else{
        Destroy(gameObject); //if the is one already : DESTROY ME
        }
    }
    // Start is called before the first frame update
    void Start()
    {
       // the invoke timer InvokeRepeating("timerTick", 1, 1);
        
    }

    // Update is called once per frame
    void Update()
    {
        Timer += Time.deltaTime;
        // invoke timer timerText.text = "Time: \n" + Timer;
        timerText.text = "Time: \n" + (int)Timer;
        scoreText.text = "Score:\n" + PlayerController.instance.score;
    }

    //invoke timer stuff void timerTick()
    // {
    //     Timer++;
    // }
}
