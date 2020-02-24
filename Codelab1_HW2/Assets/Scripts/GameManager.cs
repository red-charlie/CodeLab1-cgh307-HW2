using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    GameObject Door;
    public int score = 0;
    public int RoomReqScore = 0;
    public static int currentLevel = 0;

    //Text levelReadout; apparently in new unity the library is now called uielements?
    public Text levelReadout;
    Collider DoorCollider;

    public static GameManager instance; //creating the instance of this 
    AudioSource ambientSound;

    public Text LevelReadout { get => levelReadout; set => levelReadout = value; }

    private void Awake()
    {
        if (instance == null){ //if there isn't an instance

        instance = this; //this is the instance
        DontDestroyOnLoad(gameObject); //don't destroy this when switching scenes and stuff
        
        }else{
            Destroy(gameObject); //if there is already a game manager Destroy this
        }
        
            
        
    }

    // Start is called before the first frame update
    void Start()
    {
        ambientSound = GetComponent<AudioSource>(); //get the audio
        ambientSound.Play(); //play the audio

        //find the required score
        Door = GameObject.Find("Door");
        Door.GetComponent<DoorScript>();
        RoomReqScore = DoorScript.RequiredScore; //make it so
        

        DoorCollider = Door.GetComponent<Collider>();
        
         

    }

    // Update is called once per frame
    void Update()
    {
      
      if (Door == null)
      {
        Door = GameObject.Find("Door");
        Door.GetComponent<DoorScript>();
        RoomReqScore = DoorScript.RequiredScore;    
        DoorCollider = Door.GetComponent<Collider>();
      }
      
        if(DoorCollider == null)
            {
                DoorCollider = Door.GetComponent<Collider>();

            }

        if (score >= RoomReqScore)
        {
        
            score = 0; //reset score
            RoomReqScore = 0; //reset room requirement for new scene
            DoorCollider.enabled = true;

        }
        else{
            DoorCollider.enabled = false;
        }
    }

    public void ChangeScene()

    {
        currentLevel ++; //add one to the current level count
        SceneManager.LoadScene(currentLevel); //switch to the new number of the current level

        Door = GameObject.Find("Door");
        levelReadout.text = "Level " + (int)currentLevel;
        Door.GetComponent<DoorScript>();
        RoomReqScore = DoorScript.RequiredScore;    
        DoorCollider = Door.GetComponent<Collider>();
        
           
    }
    public void PrizeCount()
    {
        score ++; //add one to the current score

    }
}
