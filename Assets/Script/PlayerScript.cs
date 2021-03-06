﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{

    bool canJumpAgain = true;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.timeScale != 0)
        {
            if (Input.GetKey(KeyCode.D))
            {
                transform.position += new Vector3(0.01f, 0f, 0f);

            }
            else if (Input.GetKey(KeyCode.A))
            {
                transform.position += new Vector3(-0.01f, 0f, 0f);
            }
            if (Input.GetKeyDown(KeyCode.W) && canJumpAgain)
            {
                transform.position += new Vector3(0f, 0.5f, 0f);
                canJumpAgain = false;
            }
            
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        canJumpAgain = true;
    }
    
}
