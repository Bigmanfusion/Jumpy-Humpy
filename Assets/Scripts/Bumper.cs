using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bumper : MonoBehaviour
{
    [SerializeField] private float speed;
    private Rigidbody2D body;
    private Animator anim;
    private bool grounded;
    private int horizontalInput;

    private void Awake()
    {
      body = GetComponent<Rigidbody2D>(); 
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);

        float scaleX = this.transform.localScale.x;
        float scaleY = this.transform.localScale.y;

        float faceLeft = scaleX > 0 ? 0 - scaleX : scaleX;
        float faceRight = scaleX < 0 ? 0 - scaleX : scaleX;

        if (horizontalInput > 0.01f)
        {
            this.transform.localScale = new Vector2(faceRight, scaleY);
        }
        else if (horizontalInput < -0.01f)
        {
            this.transform.localScale = new Vector2(faceLeft, scaleY);
        }

        if (Input.GetKeyDown(KeyCode.Space))
            body.velocity = new Vector2(body.velocity.x, speed);

        if(Input.GetKeyDown(KeyCode.Space) && grounded)
                Jump();

        anim.SetBool("Walk", horizontalInput != 0);
        anim.SetBool("grounded", grounded);


        if (Input.GetKeyDown(KeyCode.Space))
            Jump();

        if (Input.GetKeyUp(KeyCode.Space) && body.velocity.y > 0)
            body.velocity = new Vector2(body.velocity.x, body.velocity.y / 2);


    }

    private void Jump()
    {
        body.velocity = new Vector2(body.velocity.x, speed);
        //anim.SetTrigger("jump");
        grounded = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
            grounded = true;
    }

    public bool canAttack()
    {
        return horizontalInput == 0 && grounded;
    }





}