using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterJumping : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] private float jumpForce;
    bool isGrounded;
    public Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground")){ 
            isGrounded = true;
        }
    }

    void Update()
    {
        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            handleJumping();
        }
    }

    public void handleJumping()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        animator.SetFloat("jumpUp", 1);
        isGrounded = false;

        Invoke("resetJumpUp", 0.5f);
    }

    void resetJumpUp()
    {
        animator.SetFloat("jumpUp", -1);
    }
}
