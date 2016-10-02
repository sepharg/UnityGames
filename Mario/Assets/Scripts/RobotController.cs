using UnityEngine;
using System.Collections;

public class RobotController : MonoBehaviour {

	public float maxSpeed = 10; // The fastest the player can travel in the x axis.
	public float jumpForce = 400f; // Amount of force added when the player jumps.
	bool facingRight = true;  // For determining which way the player is currently facing.
	private bool grounded;            // Whether or not the player is grounded.
	private Transform groundCheck;    // A position marking where to check if the player is grounded.

	Rigidbody2D rb2d;

	Animator animator;


	void Awake () 
	{
		rb2d = GetComponent<Rigidbody2D>();
		animator = GetComponent<Animator>();
		groundCheck = transform.Find("GroundCheck");
	}
	
	void FixedUpdate ()
	{
		if (grounded)
		{
			
		}


		float move = Input.GetAxis("Horizontal");
		rb2d.velocity = new Vector2(move * maxSpeed, rb2d.velocity.y);

		animator.SetFloat("speed", Mathf.Abs(move));

		if (move > 0 && !facingRight)
		{
			Flip();
		} else
		{
			if(move < 0 && facingRight)
			{
				Flip();
			}
		}
	}

	void Flip()
	{
		facingRight = !facingRight;
		var theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}
