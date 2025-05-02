using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
   /* public float jumpForce = 7f;
    public LayerMask groundLayer;
    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;
*/
    //private Rigidbody2D rb;

    public Sprite idle01;
    private SpriteRenderer spriteRenderer; //animation

    //private bool isGrounded; //check ground


    void Start()
    {
        //rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = idle01;
    }

    void Update()
    {
        Vector3 movement = Vector3.zero;
        float moveInput = 5f;

        if (Input.GetKey(KeyCode.A))
        {
            moveInput = -1f;
            movement.x = -1f;

            spriteRenderer.sprite = idle01;
            spriteRenderer.flipX = true; // Face left
        }
        else if (Input.GetKey(KeyCode.D))
        {
            moveInput = -1f;
            movement.x = 1f;

            spriteRenderer.sprite = idle01;
            spriteRenderer.flipX = false; // Face right

        }
    }

   
}

