using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    public int coins;
    public int lives = 3;

    private float horizontalValue;
    private Vector3 moveVector;
    private bool isGrounded;

    Animator animator;
    Rigidbody rb;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        horizontalValue = Input.GetAxisRaw("Horizontal");
        animator.SetFloat("yVelocity", rb.velocity.y);
        animator.SetBool("isGrounded", isGrounded);
        if (Physics.CheckSphere(groundCheck.position, 2, groundLayer))
            isGrounded = true;
        else 
            isGrounded = false;

        if (Input.GetButtonDown("Jump") && isGrounded)
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);

        moveVector.y = rb.velocity.y;
        moveVector.x = horizontalValue * speed;
        moveVector.z = speed;
        rb.velocity = moveVector;
    }

    public void AddCoin(int _value)
    {
        coins += _value; 
        print(coins);
    }

    public void Hit()
    {
        lives--;
    }
}
