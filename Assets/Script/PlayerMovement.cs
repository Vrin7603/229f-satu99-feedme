using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float Speed; 
    private float move;

    Rigidbody rb2d;

    void Start()
    {
        rb2d = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        move = Input.GetAxis("Horizontal");

        rb2d.linearVelocity = new Vector2(move * Speed, rb2d.linearVelocity.y);
    }
}
