using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 direction;
    public float forwardSpeed;
    public LayerMask groundMask;
    public bool _isGrounded;

    private int desiredLane = 1; // 0:left, 1:mildde, 2:right
    public float laneDistance = 4; // iki serit arasi mesafe
    
    public float jumpForce;
    public float Gravity = -20;

    public Animator animator;
    void Start()
    {

        controller = GetComponent<CharacterController>();

        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (!PlayerManager.Instance.gameOver)
        {
            direction.z = forwardSpeed;

            _isGrounded = Physics.CheckSphere(transform.position, 0.1f, groundMask);


            direction.y += Gravity * Time.deltaTime;
            if (controller.isGrounded)
            {

                if (Input.GetKeyDown(KeyCode.UpArrow))
                {
                    Jump();
                    animator.SetTrigger("Jump");
                }
            }

            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                desiredLane++;
                if (desiredLane == 3)
                    desiredLane = 2;
            }
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                desiredLane--;
                if (desiredLane == -1)
                    desiredLane = 0;
            }

            Vector3 targetPosition = transform.position.z * transform.forward + transform.position.y * transform.up;

            if (desiredLane == 0)
            {
                targetPosition += Vector3.left * laneDistance;
            }
            else if (desiredLane == 2)
            {
                targetPosition += Vector3.right * laneDistance;
            }

            if (transform.position == targetPosition)
                return;
            Vector3 diff = targetPosition - transform.position;
            Vector3 moveDir = diff.normalized * 25 * Time.deltaTime;
            if (moveDir.sqrMagnitude < diff.sqrMagnitude)
                controller.Move(moveDir);
            else
                controller.Move(diff);

            
        }
        


    }
    private void FixedUpdate()
    {
        if (!PlayerManager.Instance.gameOver)
        {
            controller.Move(direction * Time.fixedDeltaTime);

        }

    }

    private void Jump()
    {
        direction.y = jumpForce;
    }
    void Die()
    {
        animator.SetBool("isDead", true);
        // Diðer ölümle ilgili iþlemler (örneðin, oyun durdurma)
    }
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if(hit.transform.tag == "Obstacle")
        {
            PlayerManager.Instance.gameOver = true;
        }
    }

}
