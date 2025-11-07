using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Vector2 moveInput;
    private Animator animator;

    

    


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Debug.Log("Velocity: " + (moveInput * moveSpeed));
        //rb.velocity = moveInput * moveSpeed;
        #if UNITY_2023_1_OR_NEWER
            rb.linearVelocity = moveInput * moveSpeed;
        #else
            rb.velocity = moveInput * moveSpeed;
        #endif

        
    }

    public void Move(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>(); // FIRST

        animator.SetFloat("InputX", moveInput.x);
        animator.SetFloat("InputY", moveInput.y);

        if (context.canceled)
        {
            animator.SetBool("isWalking", false);
            animator.SetFloat("LastInputX", moveInput.x);
            animator.SetFloat("LastInputY", moveInput.y);
        }
        else
        {
            animator.SetBool("isWalking", true);
        }

        //animator.SetBool("isWalking", true);
        //Debug.Log("Move Input: " + moveInput);

        //if (context.canceled)
        //{
            //animator.SetBool("isWalking", false);
            //animator.SetFloat("LastInputX", moveInput.x);
            //animator.SetFloat("LastInputY", moveInput.y);
        //}
        //moveInput = context.ReadValue<Vector2>();
        //animator.SetFloat("InputX", moveInput.x);
        //animator.SetFloat("InputY", moveInput.y);
    }
}
