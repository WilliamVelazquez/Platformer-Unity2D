using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public Rigidbody2D playerRb;
    public float speed = .5f;
    public float jumpSpeed = 300;
    public bool isGrounded = true;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        playerRb.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, playerRb.velocity.y);

        if (isGrounded)
        {
            //if (Input.GetKeyDown(KeyCode.Space))
            if (Input.GetButtonDown("Jump"))
            {
                playerRb.AddForce(Vector2.up * jumpSpeed);
                isGrounded = false;
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
