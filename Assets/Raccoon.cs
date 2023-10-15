using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raccoon : MonoBehaviour {

    private bool isHolding = false;

    private Rigidbody2D rb;
    private BoxCollider2D bc;
    // Start is called before the first frame update
    void Start() {
        rb = GetComponent<Rigidbody2D>();
        bc = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update() {
        
        if(Input.GetKeyDown("Fire1")) {
            Skill1();
        }

        bool isCrouching = Input.GetKey("Fire2");

        float strength = Input.GetKey("Fire3") && !isCrouching ? 10f : 15f;

        float dirX = Input.GetAxis("Horizontal") * strength;

        rb.velocity = new Vector2(dirX, rb.velocity.y);

        if (Input.GetButtonDown("Jump") && Mathf.Abs(rb.velocity.y) < 0.001f) {
            rb.velocity = new Vector2(rb.velocity.x, strength + 3f);
        }

        if (isCrouching) {
            bc.size = new Vector2(1f, 0.5f);
        } else {
            bc.size = new Vector2(1f, 1f);
        }

    }

    private void Skill1() {
        if(isHolding) {
            // Throw
            isHolding = false;
        } else {
            // Pick up
            isHolding = true;
        }

        Ray2D ray = new(transform.position, Vector2.right);
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, 1f);
    }
}
