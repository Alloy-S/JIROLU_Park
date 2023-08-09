using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementArrow : MonoBehaviour
{

    private float horizontal;
    private float speed = 5.5f;
    private float jumpingPower = 10f;
    private float movementX;
    private float canJump = 0f;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    private bool isGrounded;


    // Start is called before the first frame update
    void Start()
    {
        movementX = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.GetInstance().getGameState() == GameState.playing)
        {

            isGrounded = Physics2D.OverlapCapsule(groundCheck.position, new Vector2(0.5f, 0.2f), CapsuleDirection2D.Horizontal, 0, groundLayer);
        
            rb.velocity = new Vector2(movementX * speed, rb.velocity.y);

// Time.time > canJump
            if (Input.GetKey(KeyCode.UpArrow) && isGrounded)
            {
                FindObjectOfType<AudioManager>().play("jump2");
                rb.velocity = Vector2.up * jumpingPower;
                canJump = Time.time + 0.5f;
            }



            // if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
            // {
            //     rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * .5f);
            // }

            if (Input.GetKey(KeyCode.LeftArrow))
            {
                movementX = -1;
            } 

            if (Input.GetKey(KeyCode.RightArrow))
            {
                movementX = 1;
            }

            if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow))
            {
                movementX = 0;
            }

        }
    }
}
