using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D.IK;

public class Raccoon : MonoBehaviour {
    private bool isHolding = false;
    private Animator anim;
    private Rigidbody2D objectHolding;

    private bool isCrouching = false;
    [SerializeField] private float jumpForce = 3f;
    [SerializeField] private float speed = 10f;
    [SerializeField] private float runningSpeed = 15f;
    [SerializeField] private float steps = 10f;

    private enum MovementState {
        Idle,
        Walking,
        Jumping,
        Falling,
        Crouching,
        Landing
    }

    private Rigidbody2D rb;
    private BoxCollider2D bc;
    private SpriteRenderer sr;

    [SerializeField] private LayerMask jumpableGround;
    private float velocityX = 0f;
    // Start is called before the first frame update
    void Start() {
        rb = GetComponent<Rigidbody2D>();
        bc = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        isHolding = false;
        objectHolding = null;
    }

    // Update is called once per frame
    void Update() {
        
        if(Input.GetAxisRaw("Fire2") == 1) {
            //Skill1();
        }

        isCrouching = Input.GetAxisRaw("Fire1") == 1;

        float strength = Input.GetAxisRaw("Fire3") == 1 && !isCrouching ? runningSpeed : speed;

        strength = isCrouching ? strength / 2 : strength;

        float dirX = Input.GetAxisRaw("Horizontal") * strength;

        if(dirX > 0)
            velocityX = Mathf.Min(rb.velocity.x + dirX / steps, dirX);

        else if(dirX < 0)
            velocityX = Mathf.Max(rb.velocity.x + dirX / steps, dirX);

        else
            velocityX = 0;

        rb.velocity = new Vector2(velocityX, rb.velocity.y);

        if (Input.GetAxisRaw("Jump") == 1 && IsGrounded()) {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
        
        UpdateAnimationState();

    }

    private void UpdateAnimationState() {

        MovementState state;
        if(velocityX > 0f) {
            state = MovementState.Walking;
            sr.flipX = false;
        } else if(velocityX < 0f) {
            state = MovementState.Walking;
            sr.flipX = true;
        } else {
            state = MovementState.Idle;
        }

        if(isCrouching) {
            state = MovementState.Crouching;
        }

        if(rb.velocity.y > 0.001f) {
            state = MovementState.Jumping;
        } else if(rb.velocity.y < -0.001f) {
            state = MovementState.Falling;
        }

        if(state == MovementState.Crouching) {
            bc.size = new Vector2(1.177811f, 0.6775999f);
        }else {
            bc.size = new Vector2(1.077168f, 0.9459839f);
        }

        anim.SetInteger("movementState", (int)state);
    }

    private bool IsGrounded() {
        return Physics2D.BoxCast(bc.bounds.center, bc.bounds.size, 0f, Vector2.down, 0.1f, jumpableGround);
    }

    private void Skill1() {
        if(isHolding) {
            isHolding = false;
            objectHolding.isKinematic = false;
            objectHolding.transform.position = transform.position + new Vector3(1f, 0f, 0f);
            objectHolding = null;
        } else {
            // Pick up
            isHolding = true;
            Vector2 dir = transform.rotation.y == 0 ? Vector2.right : Vector2.left;
            RaycastHit2D hit = Physics2D.Raycast(transform.position, dir, 1f);
            if(hit.collider != null) {
                Debug.Log(hit.collider.gameObject.name);
                hit.collider.gameObject.transform.position = transform.position + new Vector3(1f, 0f, 0f);
                hit.collider.gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
                objectHolding = hit.collider.gameObject.GetComponent<Rigidbody2D>();
            }
        }
    }
}
