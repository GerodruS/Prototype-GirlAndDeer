using UnityEngine;
using System.Collections;

public class DeerAttentionScript : MonoBehaviour {

	public float distance = 10.0f;
	public float attentionSpeed = 0.6f;
	public float worrySpeed = 1.2f;

	private GameObject player;		// Reference to the player's transform.
	public float attention = 0;
	public int worry = 0;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
		bool isAttention = false;

		if (0 == worry) {
			if (Mathf.Abs (transform.position.x - player.transform.position.x) < distance) {

				Animator anim = player.GetComponent<Animator> ();
				if (anim.GetInteger ("StateNumber") != 2) {
					attention += attentionSpeed * Time.deltaTime;
				} else {
					attention -= attentionSpeed * Time.deltaTime;
				}
			} else {

				attention -= attentionSpeed * Time.deltaTime;
			}

			if (1.0f <= attention) {
				worry = 1;

				Flip();
			}
			else if (0.5f <= attention) {
				isAttention = true;
			}
		} else if (1 == worry) {
			Animator anim = player.GetComponent<Animator> ();

			if (anim.GetInteger ("StateNumber") != 2) {
				attention += worrySpeed * Time.deltaTime;
			} else {
				attention -= attentionSpeed * Time.deltaTime;
			}

			if (attention <= 0)
			{
				worry = 0;
				Flip();
			}			
			else if (2 <= attention) {
				attention = 0;
				worry = 2;
				Flip();
			}
		} else if (2 == worry) {
			rigidbody2D.AddForce (Vector2.right * 500);
			attention = 0;
			worry = 0;
		}
		attention = Mathf.Clamp(attention, 0.0f, 2.0f);

		Animator animThis = GetComponent<Animator>();
		animThis.SetBool("Attention", isAttention);
	}
	
	
	void Flip ()
	{		
		// Multiply the player's x local scale by -1.
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}
