using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 250.0f;
    public float jumpForce = 10.0f;
    public bool isJumping = false;
    public bool isGrounded;
    public Rigidbody2D rb;
    private Vector3 velocity = new Vector3(0, 0, 0);

    void FixedUpdate()
    {
        float horizontalMovement = Input.GetAxis("Horizontal") * speed * Time.deltaTime;

        if(Input.GetButtonDown("Jump"))
        {
            isJumping = true;
        }

        MovePlayer(horizontalMovement);
    }

    void MovePlayer(float _horizontalMovement)
    {
        Vector3 targetVelocity = new Vector2(_horizontalMovement, rb.velocity.y);
        rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref velocity, .05f);

        if(isJumping)
        {
            rb.AddForce(new Vector2(0f, jumpForce));
            isJumping = false;
        }
    }
}
