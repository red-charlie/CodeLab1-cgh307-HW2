using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
 
    public static GameManager instance; // create this one only



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
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
