using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    #region Input Variables
    //the public variables for the input
    public KeyCode UpInput;
    public KeyCode DownInput;
    public KeyCode LeftInput;
    public KeyCode RightInput;

    #endregion


    #region Other Variables
    //This is where other variables go
    Rigidbody2D rb2d;
    public float force = 10;
    ParticleSystem hitWall;
    public GameObject Prize;
    public int score = 0;
    
   


    //in-class singleton work
    public static PlayerController instance; //create this object instance static

    private void Awake()
    {
        if (instance == null){ // if there isn't one already
            
        instance = this;
        DontDestroyOnLoad(gameObject); //make this the main instance
        
        }else{
            Destroy(gameObject); //if the is one already : DESTROY ME
        }

    }

    

    #endregion

    // Start is called before the first frame update
    void Start()
    {
    

        //Getting the particle system for hitting a wall
        hitWall = GetComponent<ParticleSystem>();
        //getting the rigidbody
        rb2d = GetComponent<Rigidbody2D>();
          
        
    }

    // Update is called once per frame
    void Update()
    {
        //Input stuff

        //If right is pressed apply a force right
        if(Input.GetKey(RightInput))
        {
            rb2d.AddForce(Vector2.right * force);
        }

        //If left is pressed apply a force left

        if(Input.GetKey(LeftInput))
        {
            rb2d.AddForce(Vector2.left * force);
        
        }
    
        //If up is pressed apply a force up

        if(Input.GetKey(UpInput))
        {
            rb2d.AddForce(Vector2.up * force);

        }

        //If down is pressed apply a force down

        if (Input.GetKey(DownInput))
        {
            rb2d.AddForce (Vector2.down * force);
        }

      
    

    }

    void OnCollisionEnter2D (Collision2D collision){

        
        //if you hit a wall play the hit particle effect
        if(collision.gameObject.tag == "wall")
        {
        Debug.Log ("I have hit a wall");
        hitWall.Play();
    
        }

    }


   
    
}
