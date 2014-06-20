using UnityEngine;
using System.Collections;

public class SetWaterScript : MonoBehaviour {
	
	public GameObject deer;

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player") {
			GameObject player = other.gameObject;
			Animator anim = player.GetComponent<Animator>();
			if (anim.GetBool("Water"))
			{
				anim.SetBool("Water", false);
				
				Instantiate (deer, transform.position, transform.rotation);
				Destroy (gameObject);
			}
		}
	}
}
