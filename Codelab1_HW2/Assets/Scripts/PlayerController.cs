using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class PlayerController : MonoBehaviour
{

    //stop the presses I think I found a shorter way of doing this, and I want to try it out
    // #region Input
    // public KeyCode UpInput;
    // public KeyCode DownInput;
    // public KeyCode RightInput;
    // public KeyCode LeftInput;

    // #endregion

    #region variables

    // dont need this with character controller
    //Rigidbody rb;
    public float moveSpeed = 10;
    public Camera playerCamera;

    // first person camera stuff thanks to my codelab 0 final project and the internet
    public Transform playerRotationBody; //making suere the body moves according to the mouse look

    public float mouseSensitivity = 100f; //how fast you can move the cursor to move your head

    float xRotation = 0; //current xrotation

    public float gravity = -9.81f; //the gravity

    Vector3 velocity; //the velocity used for gravity
    public CharacterController controller; // a new fangled thing I found built into unity

    #endregion

    //make sure there is only one player
    public static PlayerController instance; //create this one instance

    
    private void Awake ()
        {
            if(instance == null){ //if there isn't one already in this scene
            instance = this;
            DontDestroyOnLoad (gameObject);

            }else{
                Destroy (gameObject); //otherwise destroy this one
            }
        
        }
    
    // Start is called before the first frame update
    void Start()
    {
        //rb = GetComponent<Rigidbody>(); //rigidbody for controller

        //hide cursor
        Cursor.lockState = CursorLockMode.Locked;

    }

    // Update is called once per frame
    void Update()
    {
        #region MouseLook

        float mouseX = Input.GetAxis ("Mouse X") * mouseSensitivity;
        float MouseY = Input.GetAxis ("Mouse Y") * mouseSensitivity;
        
        //accounting for tilt
        xRotation -= MouseY;
        
        //clamping it so you can't do flips
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        //rotate the camera on the head up or down
        playerCamera.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f); 

        //rotating around the body
        playerRotationBody.Rotate(Vector3.up * mouseX);

        #endregion


        #region Movement - horizontal vertical based

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        //a standard way of finding WASD -- 
        //apparently also works for controller input will have to test that

        Vector3 movement = transform.right * x + transform.forward * z;
       //Vector3 movement = transform.forward * z;
        //using the transform direction create the x and z (horizonal/vertical) movement

        controller.Move(movement * moveSpeed * Time.deltaTime);
        //move with that number multiplied by the speed over time just like with rotation
        
        #endregion

        #region gravity since rigidbodies and character controllers don't get along

        velocity.y += gravity + Time.deltaTime; //the gravity of the object

        controller.Move (velocity * Time.deltaTime); //that gravity over time

        //There was more involving accurate falling speed, but honestly this is working so nice right now
        #endregion
        
    }

    void OnTriggerEnter (Collider other)
    {
        //Debug.Log("I've bumped something");

        if (other.gameObject.name == "Prize")
        {
            //remove the prize if I bump into it and add a point to the score
            Destroy(other.gameObject);
            GameManager.instance.PrizeCount();
            Debug.Log("I have gotten a point!");
            AudioSource Ding = GetComponent<AudioSource>();
            Ding.Play();
        }
    }
}
