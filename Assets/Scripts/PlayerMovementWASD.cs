using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementWASD : MonoBehaviour
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
            isGrounded = Physics2D.OverlapCapsule(groundCheck.position, new Vector2(0.5f, 0.2f), CapsuleDirection2D.Vertical, 0, groundLayer);
            rb.velocity = new Vector2(movementX * speed, rb.velocity.y);


            if (Input.GetKey(KeyCode.W) && isGrounded)
            {
                // Debug.Log("JUMP");
                FindObjectOfType<AudioManager>().play("jump2");
                rb.velocity = Vector2.up * jumpingPower;
                canJump = Time.time + 0.5f;
            }



            // if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
            // {
            //     rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * .5f);
            // }

            if (Input.GetKey(KeyCode.A))
            {
                movementX = -1;
            } 

            if (Input.GetKey(KeyCode.D))
            {
                movementX = 1;
            }

            if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
            {
                movementX = 0;
            }
        }

    }

    // public void OnCollisionEnter2D(Collision2D collision) {
    //     if (collision.gameObject.tag == "wall") {
    //         movementX = 0;
    //     }

    // }

    /*private void FixedUpdate()
    {
        *//*rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);*//*
        if (Input.GetKey(KeyCode.A))
        {
            Debug.Log("JUMP");
            rb.velocity = Vector2.left * speed;
        }

        if (Input.GetKey(KeyCode.D))
        {
            Debug.Log("JUMP");
            rb.velocity = Vector2.right * speed;
        }
    }*/

    /*private bool isGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, .2f, groundLayer);
    }*/
}
