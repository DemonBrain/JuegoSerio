using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raccoon : MonoBehaviour {
    private bool isHolding = false;
    private Animator anim;
    private Rigidbody2D objectHolding;
    [SerializeField] private float jumpForce = 3f;
    [SerializeField] private float speed = 10f;
    [SerializeField] private float runningSpeed = 15f;
    [SerializeField] private float steps = 10f;


    private Rigidbody2D rb;
    private BoxCollider2D bc;
    private SpriteRenderer sr;
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

        bool isCrouching = Input.GetAxisRaw("Fire1") == 1;

        float strength = Input.GetAxisRaw("Fire3") == 1 && !isCrouching ? runningSpeed : speed;

        float dirX = Input.GetAxisRaw("Horizontal") * strength;

        if(dirX > 0)
            velocityX = Mathf.Min(rb.velocity.x + dirX / steps, dirX);

        else if(dirX < 0)
            velocityX = Mathf.Max(rb.velocity.x + dirX / steps, dirX);

        else
            velocityX = 0;

        rb.velocity = new Vector2(velocityX, rb.velocity.y);

        if (Input.GetAxisRaw("Jump") == 1 && Mathf.Abs(rb.velocity.y) < 0.001f) {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        if (isCrouching) {
            bc.size = new Vector2(1f, 0.5f);
            transform.localScale = new Vector3(1f, 0.5f, 1f);
        } else {
            bc.size = new Vector2(1f, 1f);
            transform.localScale = new Vector3(1f, 1f, 1f);
        }

        UpdateAnimationState();

    }

    private void UpdateAnimationState() {
        if(velocityX > 0f) {
            anim.SetBool("walking", true);
            sr.flipX = false;
        } else if(velocityX < 0f) {
            anim.SetBool("walking", true);
            sr.flipX = true;
        } else {
            anim.SetBool("walking", false);
        }
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
