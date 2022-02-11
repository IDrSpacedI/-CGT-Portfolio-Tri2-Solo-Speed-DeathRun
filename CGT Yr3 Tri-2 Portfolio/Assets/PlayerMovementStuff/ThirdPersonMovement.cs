using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{
    //refernce to charactor contorller component
    public CharacterController controller;
    //refence to the camera
    public Transform cam;
    //movemebt speed
    public float speed = 5f;

    public float walkSpeed = 5f;
    public float sprintSpeed = 7f;

    //jump height
    public float jumpHeight = 3f;
    //smooth turn value
    public float turnSmoothTime = 0.1f;
    //ref value holder
    float turnSmoothVelocity;

    public float gravity = -9.81f;

    Vector3 velocity;
    bool isGrounded;

    public Transform groundCheck;
    public float groundDistance = 0.3f;
    public LayerMask groundMask;

    public Animator movementAnim;

    public ParticleSystem SpeedTrail;

    public float count;

    public bool disableMovement;

    public void Awake()
    {
        disableMovement = false;
    }

    // Start is called before the first frame update
    void Start()
    {

        movementAnim = GetComponentInChildren<Animator>();
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = false;
    }

    void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.tag == "Death")
        {
            print("RESET!!!!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(disableMovement == false)
        {
            //Movement Function
            Movement();
            Run();
            Gravity();
            Jump();
        }

        Ragdoll();
        
    }

    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.name == "Barrel")
        {
            movementAnim.enabled = false;
            disableMovement = true;
        }
    }

    public void Movement()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if (direction.magnitude >= 0.1f)
        {
            //Calculation for turning /direction angles
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            //smoothing turn rotation
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            //apply rotation
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
            //gives the right direction to move with the camera's calculation
            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            //apply move
            controller.Move(moveDir.normalized * speed * Time.deltaTime);

            movementAnim.SetFloat("Speed", 1f, 0.1f, Time.deltaTime);

        }
        else
        {
            Idle();
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            SpeedTrail.Play();
        }
        else if (Input.GetKeyUp(KeyCode.W))
        {
            SpeedTrail.Stop();
        }
    }



    private void Ragdoll()
    {
        if (Input.GetKey(KeyCode.E))
        {
            movementAnim.enabled = false;
            disableMovement = true;
        }

        if (Input.GetKey(KeyCode.Q))
        {
            movementAnim.enabled = true;
            disableMovement = false;
        }
    }

    private void Run()
    {
        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.LeftShift))
        {
            speed = sprintSpeed;
            movementAnim.SetFloat("Speed", 1f, 0.1f, Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.LeftShift))
        {
            speed = sprintSpeed;
            movementAnim.SetFloat("Speed", 1f, 0.1f, Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.LeftShift))
        {
            speed = sprintSpeed;
            movementAnim.SetFloat("Speed", 1f, 0.1f, Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.LeftShift))
        {
            speed = sprintSpeed;
            movementAnim.SetFloat("Speed", 1f, 0.1f, Time.deltaTime);
        }
        else
        {
            speed = walkSpeed;
            Idle();

        }
    }

    public void Gravity()
    {

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }

    public void Jump()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            movementAnim.SetTrigger("Jump");
        }
    }

    public void Idle()
    {
        movementAnim.SetFloat("Speed", 0f, 0.1f, Time.deltaTime);
    }
 
}
