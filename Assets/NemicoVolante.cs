using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NemicoVolante : Nemici
{
    
    private Collider2D coll;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    protected override void Start() {
        base.Start();
        coll = GetComponent<Collider2D>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
