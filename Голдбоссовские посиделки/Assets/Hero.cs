using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour
{
    public float speed = 3f;    public int lives = 5;    public float jumpForce = 0.5f;    private Rigidbody2D rb;    private SpriteRenderer sprite;

    private bool isGrounded = false;
    private Animator anim;

    private void Awake()    {        rb = GetComponent<Rigidbody2D>();        sprite = GetComponentInChildren<SpriteRenderer>();
        anim = GetComponent<Animator>();

    }
    private States State    {        get { return (States)anim.GetInteger("state"); }        set { anim.SetInteger("state", (int)value); }    }

    private void Run()    {
        if (isGrounded) State = States.run;

        Vector3 dir = transform.right * Input.GetAxis("Horizontal");        transform.position = Vector3.MoveTowards(transform.position, transform.position + dir, speed * Time.deltaTime);        sprite.flipX = dir.x < 0.0f;
    }
    private void Jump()    {        rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);    }
    private void checkGround()    {        Collider2D[] collider = Physics2D.OverlapCircleAll(transform.position, 0.3f);        isGrounded = collider.Length > 1;        if (!isGrounded) State = States.jump;    }

    // Update is called once per frame
    void Update()    {
        if (isGrounded) State = States.idle;

        if (Input.GetButton("Horizontal"))        {            Run();        }        if (isGrounded && Input.GetButton("Jump"))        {            Jump();        }


    }
    
    private void FixedUpdate()    {        checkGround();    }

}

public enum States{    idle,    run,    jump}

