using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;
    
    public PlayerAction inputAction;
    Vector2 move;
    Vector2 rotate;
    private float walkSpeed = 5.0f;
    public Camera playerCamera;
    Vector3 cameraRotation;

    //player jump
    Rigidbody rb;
    private float distanceToGround;
    private bool isGrounded = true;
    public float jump = 5f;

    //player animation
    Animator playerAnimator;
    private bool isWalking = false;

    //projectile bullets
    public GameObject bullet;
    public Transform projetilePos;


    public float force = 100;

    private bool hasKey = false;

    public void SetKey(bool state)
    {
        hasKey = state;
    }

    public bool GetKey()
    {
        return hasKey;
    }

    private void OnEnable()
    {
        inputAction.Player.Enable();
    }

    private void OnDisable()
    {
        inputAction.Player.Disable();
    }

    // Start is called before the first frame update
    //awake to start
    void Start()
    {
        if (!instance)
        {
            instance = this;
        }
        //using controller from playerinputcontroller
        inputAction = PlayerInputController.controller.inputAction;

        inputAction.Player.Move.performed += cntxt => move = cntxt.ReadValue<Vector2>();
        inputAction.Player.Move.canceled += cntxt => move = Vector2.zero;

        inputAction.Player.Jump.performed += cntxt => Jump();

        inputAction.Player.Shoot.performed += cntxt => Shoot();

        rb = GetComponent<Rigidbody>();
        playerAnimator = GetComponent<Animator>();
        distanceToGround = GetComponent<Collider>().bounds.extents.y;

    }

    private void Jump()
    {
        if (isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jump);
            isGrounded = false;
        }
    }

    public void Shoot()
    {
        Rigidbody bulletRb = Instantiate(bullet, projetilePos.position, Quaternion.identity).GetComponent<Rigidbody>();
        bulletRb.AddForce(transform.forward * 32f, ForceMode.Impulse);
        bulletRb.AddForce(transform.up * 5f, ForceMode.Impulse);
    }



    // Update is called once per frame
    void Update()
    {
        transform.Translate(transform.forward * move.x * Time.deltaTime * walkSpeed, Space.Self);
        transform.Translate(-transform.right * move.y * Time.deltaTime * walkSpeed, Space.Self);

        isGrounded = Physics.Raycast(transform.position, -Vector3.up, distanceToGround);

       

    }
     private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Enemy") //player hits the enemy
        {
            HealthManager.instance.ChangeHealth(-1);
            //push player back
            // Calculate Angle Between the collision point and the player
            Vector3 dir = collision.contacts[0].point - transform.position;
            // We then get the opposite (-Vector3) and normalize it
            dir = -dir.normalized;
            // And finally we add force in the direction of dir and multiply it by force. 
            collision.gameObject.GetComponent<Rigidbody>().AddForce(dir *force);


        }
    }
}
