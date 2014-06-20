using UnityEngine;
using System.Collections;

public class DeerFollowScript : MonoBehaviour
{
	GameObject player;
	private bool facingRight = true;			// For determining which way the player is currently facing.
	public float maxDistance = 5;
	//public GameObject rope;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player");
		Physics2D.IgnoreCollision(player.collider2D, collider2D);
		/*
		Instantiate (rope, transform.position, transform.rotation);
		RopeScript ropeScript = rope.GetComponent<RopeScript>();
		ropeScript.SetStart(this.gameObject, Vector3.right);
		ropeScript.SetFinish(player, Vector3.zero);
		*/
	}
	
	// Update is called once per frame
	void Update ()
	{
		float distance = transform.position.x - player.transform.position.x;
		if (distance < 0.0f && !facingRight ||
		    0.0f < distance && facingRight)
		{
			Flip ();
		}

		if (maxDistance < Mathf.Abs(distance))
		{
			transform.position = new Vector3(transform.position.x + Mathf.Sign(distance) * (maxDistance - Mathf.Abs(distance)), transform.position.y, transform.position.z);
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
}
