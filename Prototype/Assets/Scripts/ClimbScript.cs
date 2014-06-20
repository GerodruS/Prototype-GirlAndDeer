using UnityEngine;
using System.Collections;

public class ClimbScript : MonoBehaviour {

	// Use this for initialization
	
	// Update is called once per frame
	void Update () {
	}
	
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player") {
			Animator anim = other.gameObject.GetComponent<Animator>();
			anim.SetBool("Climb", true);
		}
	}
	
	void OnTriggerExit2D(Collider2D other)
	{
		if (other.tag == "Player") {
			Animator anim = other.gameObject.GetComponent<Animator>();
			anim.SetBool("Climb", false);
		}
	}
}
