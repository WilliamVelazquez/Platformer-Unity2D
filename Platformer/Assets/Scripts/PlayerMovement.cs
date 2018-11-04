using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public Rigidbody2D playerRb;
    public float speed = .5f;
    public float jumpSpeed = 300;

    public bool isGrounded = true;
    public Animator playerAnimator;
    AudioSource playerJumpAudio;

    // Use this for initialization
    void Start () {
        playerJumpAudio = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
        playerRb.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, playerRb.velocity.y);

        if(Input.GetAxis("Horizontal") == 0)
        {
            playerAnimator.SetBool("isWalking", false);
        }
        else if(Input.GetAxis("Horizontal") < 0)
        {
            playerAnimator.SetBool("isWalking", true);
            GetComponent<SpriteRenderer>().flipX = true;
        }
        else if (Input.GetAxis("Horizontal") > 0)
        {
            playerAnimator.SetBool("isWalking", true);
            GetComponent<SpriteRenderer>().flipX = false;
        }

        if (isGrounded)
        {
            //if (Input.GetKeyDown(KeyCode.Space))
            if (Input.GetButtonDown("Jump"))
            {
                //GetComponent<AudioSource>().Play();
                playerJumpAudio.Play();
                playerRb.AddForce(Vector2.up * jumpSpeed);
                isGrounded = false;
                playerAnimator.SetTrigger("Jump");
            }
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //if (collision.gameObject.tag="")
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}
