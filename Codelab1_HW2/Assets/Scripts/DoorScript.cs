using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    public int Prizes = 0;
    public static int RequiredScore;
   
    
    void Awake ()
    {
        RequiredScore = Prizes;
    }
    // Start is called before the first frame 

    void Start()
    {
       RequiredScore = Prizes;
    
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter (Collider other)
    {
        GameManager.instance.ChangeScene();
        Debug.Log ("Going to the next level");

    }
}
