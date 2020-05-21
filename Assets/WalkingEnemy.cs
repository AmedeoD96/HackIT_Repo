using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingEnemy : Nemici {

    [SerializeField] private float leftCap;
    [SerializeField] private float rightCap;
    [SerializeField] private float jumpLenght = 10f;
    [SerializeField] private float jumpHeight = 15f;
    [SerializeField] private LayerMask ground;
    private Collider2D coll;
    private Rigidbody2D rb;

    private bool facingLeft = true;

    protected override void Start() {
        base.Start();
        coll = GetComponent<Collider2D>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update() {
        //salto->caduta
        if (anim.GetBool("Jumping")){
            if (rb.velocity.y < .1){
                anim.SetBool("Falling", true);
                anim.SetBool("Jumping", false);
            }
        }
        
        //caduta->salto
        if (coll.IsTouchingLayers(ground) && anim.GetBool("Falling")){
            anim.SetBool("Falling", false);
            
        }
    }

    private void Move() {
        if (facingLeft){
            //Controllo se sono prima dell'oggetto a sinistra. Altrimenti mi giro a destra
            if (transform.position.x > leftCap){
                //Controllo se il nemico sta guardando a destra. Se no lo giro
                if (transform.localScale.x != 1){
                    transform.localScale = new Vector3(1, 1);
                }

                //Se sono a terra, salta
                if (coll.IsTouchingLayers(ground)){
                    //Salta
                    rb.velocity = new Vector2(-jumpLenght, jumpHeight);
                    anim.SetBool("Jumping", true);
                }
            }
            else{
                facingLeft = false;
            }
        }
        else{
            if (transform.position.x < rightCap){
                //Controllo se il nemico sta guardando a destra. Se no lo giro
                if (transform.localScale.x != -1){
                    transform.localScale = new Vector3(-1, 1);
                }

                //Se sono a terra, salta
                if (coll.IsTouchingLayers(ground)){
                    //Salta
                    rb.velocity = new Vector2(jumpLenght, jumpHeight);
                    anim.SetBool("Jumping", true);
                }
            }
            else{
                facingLeft = true;
            }
        }
    }

    

    
}
