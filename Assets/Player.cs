using System;
using System.Collections;
using System.Collections.Generic;
using Platformer.Mechanics;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {
    Rigidbody2D rb;
    Animator anim;

    private enum State {
        idle,
        running,
        jumping,
        falling,
        hurt
    }

    private State state = State.idle;
    private Collider2D coll;
    [SerializeField] private LayerMask ground;
    [SerializeField] private float speed = 7f;
    [SerializeField] private float jumpForce = 15f;
    [SerializeField] private int monetine = 0;
    [SerializeField] private Text monetineText;
    [SerializeField] private float hurtForce = 10f;
    [SerializeField] private int health;
    [SerializeField] private Text healthAmount;

    private void Start() {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        coll = GetComponent<Collider2D>();
        healthAmount.text = health.ToString();
    }

    private void Update() {
        if (state != State.hurt){
            Movement();
        }
        
        AnimationState();
        
        anim.SetInteger("state", (int) state); //Imposto l'animazione grazie all'enum
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "Monetine"){
            Destroy(collision.gameObject);
            monetine++;
            monetineText.text = monetine.ToString();
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag == "Enemy"){
            Nemici enemy = other.gameObject.GetComponent<Nemici>();
            if (state == State.falling){
                enemy.JumpedOn();
                Jump();
            }
            else{
                state = State.hurt;
                HandleHealth();
                if (other.gameObject.transform.position.x > transform.position.x){
                    //Nemico alla mia destra. Mi sposta a sinistra
                    rb.velocity = new Vector2(-hurtForce, rb.velocity.y);
                }
                else{
                    //Nemico alla mia sinistra. Mi sposta a destra
                    rb.velocity = new Vector2(hurtForce, rb.velocity.y);
                }
            }
            
        }
    }

    private void HandleHealth() {
        health -= 1;
        healthAmount.text = health.ToString();
        if (health <= 0){
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    private void Movement() {
        float hDirection = Input.GetAxis("Horizontal");

        //Movimento sinistra
        if (hDirection < 0){
            rb.velocity = new Vector2(-speed, rb.velocity.y);
            transform.localScale = new Vector2(-1, 1);
        }
        //Movimento destra
        else if (hDirection > 0){
            rb.velocity = new Vector2(speed, rb.velocity.y);
            transform.localScale = new Vector2(1, 1);
        }

        //Salto
        if (Input.GetButtonDown("Jump") && coll.IsTouchingLayers(ground)){
            Jump();
        }
    }

    private void Jump() {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        state = State.jumping;
    }

    private void AnimationState() {
        if (state == State.jumping){
            if (rb.velocity.y < .1f){
                state = State.falling;
            }
        }
        else if (state == State.falling){
            if (coll.IsTouchingLayers(ground)){
                state = State.idle;
            }
        }else if (state == State.hurt){
            if (Mathf.Abs(rb.velocity.x) < .1f){
                state = State.idle;
            }
        }
        else if (Mathf.Abs(rb.velocity.x) > 2f){
            //Movimento
            state = State.running;
        }
        else{
            state = State.idle;
        }
        
    }
}
