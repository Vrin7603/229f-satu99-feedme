using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float Speed;
    private float move;

    private Rigidbody2D rb2d;
    private bool facingRight = true;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        move = Input.GetAxis("Horizontal");
        rb2d.velocity = new Vector2(move * Speed, rb2d.velocity.y);

        // Flip the sprite
        if (move > 0 && !facingRight)
        {
            Flip();
        }
        else if (move < 0 && facingRight)
        {
            Flip();
        }
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
}
