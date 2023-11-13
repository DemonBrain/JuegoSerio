using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Parrot : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D coll;
    private SpriteRenderer sprite;

    private Animator anim;
    

    [SerializeField] private LayerMask jumpableGround;
    public bool HasItem { get; set; } = false;

    private float dirX = 0f;
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float jumpForce = 14f;

    public Text velText;

    private enum MovementState {idle, running, jumping, falling, flying};
    private MovementState state = MovementState.idle;

    // Start is called before the first frame update<
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {

            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }         

        velText.text = "Velocidad Y: " + rb.velocity.y.ToString(); 

        UpdateAnimationState();
    }

    private void UpdateAnimationState(){
        MovementState state;
        if (dirX > 0f && IsGrounded()==true ){
            state = MovementState.running;
            sprite.flipX = false;
        }
        else if (dirX < 0f && IsGrounded()==true){
            state = MovementState.running;
            sprite.flipX = true;
        }


        else if (rb.velocity.y > jumpForce*0.7){
            state = MovementState.jumping;
            Flip();
        }

        else if (rb.velocity.y< jumpForce*0.7 && rb.velocity.y > -0.5*jumpForce && IsGrounded()==false){
            state = MovementState.flying;
            Flip();
        }
        
        else if (rb.velocity.y < -0.5*jumpForce && IsGrounded()==false){
            state = MovementState.falling;
            Flip();
        }
        else if (rb.velocity.y < 0 && IsGrounded()==false){
            state = MovementState.falling;
            Flip();
        }

        else{
            state = MovementState.idle;
        }
        
        anim.SetInteger("state", (int)state);
    }

    private void Flip(){
        if (dirX > 0f){
            sprite.flipX = false;
        }

        else if (dirX < 0f){
            sprite.flipX = true;
        }
    }
    
    private bool IsGrounded(){
       return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }
}
