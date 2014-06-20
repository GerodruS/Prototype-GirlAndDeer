using UnityEngine;
using System.Collections;

public class GirlControll : MonoBehaviour
{
	[HideInInspector]
	public bool facingRight = true;			// For determining which way the player is currently facing.
	[HideInInspector]

	private Animator anim;					// Reference to the player's animator component.
	
	public float moveForce = 30f;			// Amount of force added to move the player left and right.
	public float maxSpeed = 1f;				// The fastest the player can travel in the x axis.

	public float climbSpeed = 0.1f;
	
	
	void Awake()
	{
		// Setting up references.
		anim = GetComponent<Animator>();
	}
	
	
	void Update()
	{
	}
	
	
	void FixedUpdate ()
	{
		if (isClimbState())
		{
			rigidbody2D.velocity = Vector3.zero;

			rigidbody2D.gravityScale = 0;

			float h = Input.GetAxis ("Vertical");
			float w = Input.GetAxis ("Horizontal");
			transform.position = new Vector3(transform.position.x + w * Time.deltaTime * (climbSpeed + maxSpeed) / 2,
			                                 transform.position.y + h * Time.deltaTime * climbSpeed,
			                                 transform.position.z);

			if (w < 0 && facingRight || 0 < w && !facingRight)
			{
				Flip();
			}
			/*
			float x = rigidbody2D.velocity.x;
			float y = rigidbody2D.velocity.y;

			if (h * rigidbody2D.velocity.y < climbMaxSpeed)
			{
				rigidbody2D.AddForce (Vector2.up * h * climbForce);
			}
			if (w * rigidbody2D.velocity.x < climbMaxSpeed)
			{
				rigidbody2D.AddForce (Vector2.right * w * climbForce);
			}

			if (Mathf.Abs (rigidbody2D.velocity.x) > climbMaxSpeed)
			{
				x = Mathf.Sign (rigidbody2D.velocity.x) * maxSpeed;
			}
			if (Mathf.Abs (rigidbody2D.velocity.y) > climbMaxSpeed)
			{
				y = Mathf.Sign (rigidbody2D.velocity.y) * maxSpeed;
			}
						
			rigidbody2D.velocity = new Vector2 (x, y);
			*/
		}
		else
		{
			rigidbody2D.gravityScale = 1;
			//anim.SetBool("Seat", false);
			//anim.SetBool("Jump", false);

			float w = Input.GetAxis ("Vertical");
			if (w < 0)
			{
				Debug.Log("seat");
				anim.SetInteger("StateNumber", 2);
			}
			else if (w > 0)
			{
				//Debug.Log("jump");
				//anim.SetTrigger("Jump");
				//anim.SetBool("Jump", true);
			}
			else
			{
				// Cache the horizontal input.
				float h = Input.GetAxis ("Horizontal");

				if (h != 0.0f)
				{
					anim.SetInteger("StateNumber", 1);
				
					// The Speed animator parameter is set to the absolute value of the horizontal input.
					//anim.SetFloat ("Speed", Mathf.Abs (h));
					
					// If the player is changing direction (h has a different sign to velocity.x) or hasn't reached maxSpeed yet...
					if (h * rigidbody2D.velocity.x < maxSpeed)
						// ... add a force to the player.
						rigidbody2D.AddForce (Vector2.right * h * moveForce);
					
					// If the player's horizontal velocity is greater than the maxSpeed...
					if (Mathf.Abs (rigidbody2D.velocity.x) > maxSpeed)
						// ... set the player's velocity to the maxSpeed in the x axis.
						rigidbody2D.velocity = new Vector2 (Mathf.Sign (rigidbody2D.velocity.x) * maxSpeed, rigidbody2D.velocity.y);
					
					// If the input is moving the player right and the player is facing left...
					if (h > 0 && !facingRight)
						// ... flip the player.
						Flip ();
					// Otherwise if the input is moving the player left and the player is facing right...
					else if (h < 0 && facingRight)
						// ... flip the player.
						Flip ();
				}
				else
				{
					anim.SetInteger("StateNumber", 0);
				}
			}
		}
	}
	
	
	void Flip ()
	{
		// Switch the way the player is labelled as facing.
		facingRight = !facingRight;
		
		// Multiply the player's x local scale by -1.
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
	
	//static int climbState = Animator.StringToHash("ClimbState");

	bool isClimbState()
	{
		/*
		Animator anim = GetComponent<Animator>();
		int currentState = anim.GetCurrentAnimatorStateInfo(0).IsName("ClimbState");
		Debug.Log(currentState + " :: " + climbState);
		return climbState == currentState;
		*/
		bool result = anim.GetCurrentAnimatorStateInfo(0).IsName("ClimbState");
		Debug.Log(result);
		return result;
	}
}
