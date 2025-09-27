using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    SoundManager soundManager;
   // [SerializeField] AudioClip plaerFallingSFX;

    [SerializeField] AudioClip jumpSound;
    public float moveSpeed = 7f;
    private Rigidbody2D rb;
    private Animator anim;
    private float moveX;
    private float moveY;
    public SpriteRenderer sr;
    private bool grounded;
    private bool isWall;
    private bool isClimbing;
    private bool OnCrate;
    //public Transform wallCheckPoint;
    //public LayerMask wallLayer;
    public float wallCheckDistance = 0.5f;

    void Awake()
    {   //references rigidbody and animator
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        moveX = Input.GetAxisRaw("Horizontal");
        moveY = Input.GetAxisRaw("Vertical");
        rb.velocity = new Vector2(moveX * moveSpeed, rb.velocity.y);


        //move right and left
        if (moveX > 0.01f)
        {
            sr.flipX = true;
            
            //transform.localScale = new Vector2(1* transform.localScale.x,1* transform.localScale.y);
        }
        else if (moveX < -0.01f)
        {
            sr.flipX = false;
            //transform.localScale = new Vector2(-1*transform.localScale.x, 1 * transform.localScale.y);
        }
        ////climb
        //isWall = Physics2D.Raycast(wallCheckPoint.position, transform.right, wallCheckDistance, wallLayer);
        //if (isWall && Mathf.Abs(moveY) > 0.1f)
        //{
        //    isClimbing = true;
        //}
        //else if (!isWall || moveY == 0)
        //{
        //    isClimbing = false;
        //}
        //if (isClimbing)
        //{
        //    rb.gravityScale = 0;
        //    rb.velocity = new Vector2(rb.velocity.x, moveY * moveSpeed);
        //    Debug.Log("Climbing...");
        //}
        //else
        //{
        //    rb.gravityScale = 1;
        //}


        //jump
        if (Input.GetKey(KeyCode.Space) && (grounded || OnCrate)  &&!isClimbing)
        {
            rb.velocity = new Vector2(rb.velocity.x, moveSpeed);
            if (Input.GetKeyDown(KeyCode.Space) && (grounded || OnCrate) && !isClimbing)
                SoundManager.instance.playSound(jumpSound);


        }


        //Animation Parameters
        anim.SetBool("run", moveX != 0);
        anim.SetBool("jump", !grounded && !OnCrate);
        // anim.SetBool("climb", isClimbing);

    }
    //Sure Player touch Ground
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            grounded = true;
        }
        else if (collision.gameObject.CompareTag("Wall"))
        {
            isWall = true;
           // Debug.Log("Player touched wall");
        }
        else if (collision.gameObject.CompareTag("Crate"))
        {
            OnCrate = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            grounded = false;
        }
        else if (collision.gameObject.CompareTag("Wall"))
        {
            isWall = false;
        }else if (collision.gameObject.CompareTag("Crate"))
        {
           OnCrate = false;
        }
    }

}
