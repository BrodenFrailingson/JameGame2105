using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float horizontal;
    private float vertical;
    private float Speed =3f;
    private bool isFacingRight = true;

    [SerializeField] private Rigidbody2D rb;
   

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        Flip();
    }

    private void  FixedUpdate()
    {
        rb.velocity = new Vector2(rb.velocity.x, vertical * Speed);
        rb.velocity = new Vector2(horizontal * Speed,rb.velocity.y);
    }

    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;

        }
    }
}
