using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D playerRB;
    Animator playerAnimator;
    public float moveSpeed = 1f;
    public float jumpSpeed = 1f;

    public static bool facingRight = true;
    public bool isGrounded = false;
    
  


    // Start is called before the first frame update
    void Start()
    {
        facingRight = true;
        playerRB = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();

    }

    void Awake()
    {

    }

    // Update is called once per frame
    void Update()
    {
        horizontalMove();
       

        if (playerRB.velocity.x < 0 && facingRight)
        {
            flipFace();
           
        }
        else if (playerRB.velocity.x > 0 && !facingRight)
        {
            flipFace();
           
        }

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded) //zýpla
        {
            jump();
        }
        if(playerRB.velocity.x == 0 && isGrounded)
        {
             playerAnimator.Play("PlayerIdle");
        }
        else
        {
            playerAnimator.Play("Playerrun");
        }
    }

    void flipFace()
    {
        facingRight = !facingRight;
        Vector3 tempLocalScale = transform.localScale;
        tempLocalScale.x *= -1;
        transform.localScale = tempLocalScale;
    }

    void FixedUpdate()
    {

    }

    void horizontalMove()
    {
        playerRB.velocity = new Vector2(Input.GetAxis("Horizontal") * moveSpeed, playerRB.velocity.y);
        

    }

    void jump()
    {
        playerRB.velocity=new Vector2(playerRB.velocity.x,0);
        playerRB.AddForce(Vector2.up*jumpSpeed,ForceMode2D.Impulse);
        print(Input.GetAxis("Vertical"));
        isGrounded = false;
    }

    void OnCollisionEnter2D(Collision2D coll) 
    {
        if(coll.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
      
        
    }
}
