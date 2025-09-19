using System.Data;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;

    private float horizontal;

    private CharacterController Cc;

    public float jumpHeight = 5f;
    public float gravity = -9.81f;
    private Vector3 velocity;

    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;
    public LayerMask WhatIsGround;

    private bool isGrounded;

    public bool isFacingRight = true;


    void Start()
    {
        Cc = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            moveSpeed = 9f;
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            moveSpeed = 6f;
        }

        isGrounded = Physics.CheckSphere(groundCheck.position, groundCheckRadius, WhatIsGround);

        horizontal = Input.GetAxisRaw("Horizontal") * moveSpeed;
        Vector3 move = new Vector3(0, 0, horizontal);

        Cc.Move(move * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;

        Cc.Move(velocity * Time.deltaTime);

        if (horizontal > 0 && !isFacingRight)
        {
            Flip();
        }

        else if (horizontal < 0 && isFacingRight)
        {
            Flip();
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
    }

    void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 localScale = transform.localScale;
        localScale.z *= -1;
        transform.localScale = localScale;
    }
}
