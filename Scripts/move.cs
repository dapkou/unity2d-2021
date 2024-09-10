using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    public float jumpForce;
    public float speed;
    private Rigidbody2D rb;

    public Transform groubdPos;
    private bool isGroubded;
    public float checkRadius;
    public LayerMask whatIsGround;
    //
    private float JumpTimeCounter;
    public float jumpTime;
    private bool isJumping;


    private bool isTouchingFront;
    public Transform frontCheak;
    private bool wallSliding;
    public float wallSlidingSpeed;
    //

    private bool wallJumping;
    public float xWallForce;
    public float yWallForce;
    public float wallJumpTime;

    public LayerMask whatIsWall;

    bool doubleJump;

    //public static int healthPoints = 3;
    //
    //float dirX;
    int playerLayer, platformLayer;
    bool jumpOffCoroutineIsRynning = false;
    //

    private Animator anim;

    // Start is called before the first frame update
    private void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        //
        playerLayer = LayerMask.NameToLayer("Player");
        platformLayer = LayerMask.NameToLayer("Platform");
        //
    }

    // Update is called once per frame
    private void Update()
    {
        //dirX = Input.GetAxis("Horizontal");
        float input = Input.GetAxisRaw("Horizontal");
        isGroubded = Physics2D.OverlapCircle(groubdPos.position, checkRadius, whatIsGround);
        if (rb.velocity.y == 0)
            isGroubded = true;
        else isGroubded = false;
        if (isGroubded)
            doubleJump = true;

        if (isGroubded && Input.GetKeyDown(KeyCode.Z) && rb.velocity.y == 0)
        {
            anim.SetTrigger("takeOf");
            doubleJump = false;
            isJumping = true;
            JumpTimeCounter = jumpTime;
            rb.velocity = Vector2.up * jumpForce;
        }
        //
        if (Input.GetKeyDown(KeyCode.Z) && !Input.GetKey(KeyCode.DownArrow) && rb.velocity.y == 0)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Force);
        }
        else if (Input.GetKeyDown(KeyCode.Z) && Input.GetKey(KeyCode.DownArrow))
        {
            StartCoroutine("JumpOff");
        }
        if (rb.velocity.y > 0)
            Physics2D.IgnoreLayerCollision(playerLayer, platformLayer, true);
        else if (rb.velocity.y <= 0 && !jumpOffCoroutineIsRynning)
            Physics2D.IgnoreLayerCollision(playerLayer, platformLayer, false);
        //
        if (isGroubded == true)
        {
            doubleJump = false;
            anim.SetBool("isJumping", false);
        }
        else
        {
            anim.SetBool("isJumping", true);
        }

        float moveInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

        if (moveInput == 0)
        {
            anim.SetBool("isRunning", false);
        }
        else
        {
            anim.SetBool("isRunning", true);
        }
        if (moveInput < 0)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
        if (moveInput > 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }

        //wall jump
        isTouchingFront = Physics2D.OverlapCircle(frontCheak.position, checkRadius, whatIsWall);
        if (isTouchingFront == true && wallJumping == false && input != 0){
            wallSliding = true;
        }else{
            wallSliding = false;
        }
        if (wallSliding)
        {
            rb.velocity = new Vector2(rb.velocity.x, Mathf.Clamp(rb.velocity.y, -wallSlidingSpeed, float.MaxValue));
        }
        if (Input.GetKeyDown(KeyCode.UpArrow) && wallSliding == true)
        {
            wallJumping = true;
            Invoke("SetWallJumpingToFalse", wallJumpTime);
        }
        if (wallJumping == true)
        {
            anim.SetTrigger("wallJump");
            rb.velocity = new Vector2(xWallForce * -input, yWallForce);

        }
        //
        //private void FixedUpdate()
        //{
        //    rb.velocity = new Vector2(dirX = speed, rb.velocity.y);
        //}
        //
        IEnumerator JumpOff()
        {
            jumpOffCoroutineIsRynning = true;
            Physics2D.IgnoreLayerCollision(playerLayer, platformLayer, true);
            yield return new WaitForSeconds(0.5f);
            Physics2D.IgnoreLayerCollision(playerLayer, platformLayer, false);
            jumpOffCoroutineIsRynning = false;
        }
    }
    void SetWallJumpingToFalse()
    {
        wallJumping = false;
    }
}
