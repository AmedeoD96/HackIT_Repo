using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nemici : MonoBehaviour {
    protected Animator anim;
    protected Rigidbody2D rb;
    protected AudioSource esplosione;

    protected virtual void Start() {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        esplosione = GetComponent<AudioSource>();
    }

    public void JumpedOn() {
        anim.SetTrigger("Death");
        rb.velocity = Vector2.zero;
        rb.bodyType = RigidbodyType2D.Kinematic;
        GetComponent<Collider2D>().enabled = false;
        esplosione.Play();
    }
    
    private void Death() {
        Destroy(this.gameObject);
    }
}
