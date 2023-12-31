using UnityEngine;

public class EscalerasScrip : MonoBehaviour
{
    private float vertical;
    private float speed = 8f;
    private bool isLadder;
    private bool isClimbing;
    private bool justSet = false;

    [SerializeField] private Rigidbody2D rb;

    void Update()
    {
        vertical = Input.GetAxisRaw("Vertical");

        if (isLadder && Mathf.Abs(vertical) > 0f)
        {
            isClimbing = true;
        }
    }

    private void FixedUpdate()
    {
        if (isClimbing)
        {
            rb.gravityScale = 0f;
            rb.velocity = new Vector2(rb.velocity.x, vertical * speed);
            justSet = false;
        }
        else if(!justSet)
        {
            rb.gravityScale = 4f;
            justSet = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Escalera"))
        {
            isLadder = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Escalera"))
        {
            isLadder = false;
            isClimbing = false;
        }
    }
}