﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour {
    [SerializeField] private string sceneName;
    [SerializeField] private Canvas message;
    private Player playerScript;
    private GameObject player;

    private void Start() {
        player = GameObject.Find("Player");
        playerScript = player.GetComponent<Player>();
        message.enabled = false;
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if (playerScript.indizi != 2){
            message.enabled = true;
        }else if (other.gameObject.tag == "Player"){
            SceneManager.LoadScene(sceneName);

        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.gameObject.tag == "Player"){
            message.enabled = false;
        }
    }
}