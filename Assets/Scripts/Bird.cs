using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    public float upForce;
    private bool isDead = false;
    Rigidbody2D rb2d;
    private Animator anim;  
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fly1"))
        {
            fly();
        }
    }
    public void fly(){
        if (isDead == false)
        {
            rb2d.velocity = Vector2.up * upForce;
            rb2d.AddForce(new Vector2(0, upForce));
            anim.SetTrigger("Flap");
          }
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        isDead = true;
        anim.SetTrigger("Dead");
        GameController.instance.BirdDied(); 
    }
}
