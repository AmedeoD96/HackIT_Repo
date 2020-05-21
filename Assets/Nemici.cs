using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nemici : MonoBehaviour {
    protected Animator anim;

    protected virtual void Start() {
        anim = GetComponent<Animator>();
    }

    public void JumpedOn() {
        anim.SetTrigger("Death");
    }
    
    private void Death() {
        Destroy(this.gameObject);
    }
}
