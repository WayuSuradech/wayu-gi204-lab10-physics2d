using UnityEngine;

public class PlayerMoveMant : MonoBehaviour
{
    public float Speed;
    private float move;
    public float JumpForce;
    public bool IsJumping;
    Rigidbody2D rb2d;
    Vector2 moveInput;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        rb2d.AddForce(moveInput * Speed);
            //move = Input.GetAxis("Horizontal");//
        //rb2d.linearVelocity = new Vector2(move Speed, rb2d.linearVelocity.y);*//
        if (Input.GetButtonDown("Jump")&& !IsJumping)
        {
            rb2d.AddForce(new Vector2(rb2d.linearVelocity.x, JumpForce));
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            IsJumping = false;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            IsJumping = true;
        }
    }
}
