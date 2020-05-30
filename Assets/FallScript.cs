﻿using UnityEngine;
using UnityEngine.SceneManagement;

public class FallScript : MonoBehaviour {
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Player"){
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
