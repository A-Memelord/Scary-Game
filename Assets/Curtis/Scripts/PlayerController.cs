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
    public Animator Animator;

    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;
    public LayerMask WhatIsGround;

    private bool isGrounded;

    public bool isFacingRight = true;

    public bool moving = false;

    public float movement_anim_value = 0f;


    void Start()
    {
        Cc = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            moveSpeed = 8f;
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            moveSpeed = 4f;
        }

        bool wasGrounded = isGrounded;
        isGrounded = Physics.CheckSphere(groundCheck.position, groundCheckRadius, WhatIsGround);

        if (wasGrounded && !isGrounded && velocity.y <= 0)
        {
            velocity.y = 0;
        }

        horizontal = Input.GetAxisRaw("Horizontal") * moveSpeed;
        Vector3 move = new Vector3(0, 0, horizontal);

        if (move.z == 4)
        {
            moving = true;
        }
        else
        {
            moving = false;
        }
        ///////////////////////animation stuff/////////////////////
        if (Mathf.Abs(horizontal) > 0)
        {
            movement_anim_value += 3f * Time.deltaTime;
        }
        else
        {
            movement_anim_value -= 3f * Time.deltaTime;
        }
        movement_anim_value = Mathf.Clamp(movement_anim_value, 0f, 1f);
        Animator.SetFloat("movement", movement_anim_value);
        ////////////////////////////////////////////////////////////////////////////////
        
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
