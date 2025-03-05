using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    
    public float walkSpeed = 5f;
    public float runSpeed = 10f;
    public float crouchSpeed = 2f;
    public float gravity = -20f;
    public float jumpHeight = 3f;

    public Transform groundCheck;
    public float groundDistance = 0.1f;
    public LayerMask groundMask;

    public Transform headCheck;
    public float headDistance = 0.3f; // Aumentado para detectar mejor obstáculos
    public LayerMask obstacleMask;

    public float standingHeight = 2f;
    public float crouchingHeight = 1.2f; // Aumentado para ser más alto al agacharse
    public Vector3 standingCenter = new Vector3(0, 1f, 0);
    public Vector3 crouchingCenter = new Vector3(0, 0.6f, 0); // Ajustado para mejor posición

    Vector3 velocity;
    bool isGrounded;
    bool isCrouching;
    bool hasObstacleAbove;
    bool isFalling;

    public Animator animator;

    void Update()
    {
        CheckGroundStatus();
        CheckHeadStatus();
        HandleMovement();
        HandleJump();
        ApplyGravity();
    }

    void CheckGroundStatus()
    {
        bool wasGrounded = isGrounded;
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2.5f;
        }
        
        isFalling = !isGrounded;
        animator.SetBool("isFalling", isFalling);
    }

    void CheckHeadStatus()
    {
        hasObstacleAbove = Physics.CheckSphere(headCheck.position, headDistance, obstacleMask) || 
                           Physics.CheckSphere(transform.position + Vector3.up * standingHeight, headDistance, obstacleMask);
    }

    void HandleMovement()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        bool isRunning = Input.GetKey(KeyCode.LeftShift);
        bool isCrouchingNow = Input.GetKey(KeyCode.LeftControl);
        
        if (isCrouchingNow && !isRunning)
        {
            isCrouching = true;
            controller.height = crouchingHeight;
            controller.center = crouchingCenter;
           // animator.SetTrigger("Standing To Crouched");
        }
        else if (!isCrouchingNow && !hasObstacleAbove)
        {
            isCrouching = false;
            controller.height = standingHeight;
            controller.center = standingCenter;
            //animator.SetTrigger("StandUp");
        }
        
        float currentSpeed = isCrouching ? crouchSpeed : (isRunning ? runSpeed : walkSpeed);
        animator.SetBool("isRunning", isRunning);
        animator.SetBool("isCrouching", isCrouching);
        
        animator.SetFloat("VelX", x);
        animator.SetFloat("VelY", y);
        
        Vector3 move = transform.right * x + transform.forward * y;
        controller.Move(move * Time.deltaTime * currentSpeed);
    }

    void HandleJump()
    {
        if (Input.GetButtonDown("Jump") && isGrounded  && !hasObstacleAbove)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            isFalling = true;
            animator.SetBool("isFalling", isFalling);
        }
    }

    void ApplyGravity()
    {
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}
