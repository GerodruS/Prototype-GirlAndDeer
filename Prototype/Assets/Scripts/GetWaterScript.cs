using UnityEngine;
using System.Collections;

public class GetWaterScript : MonoBehaviour {

	// Use this for initialization
	GameObject player;
	bool enable = false;
	
	// Update is called once per frame
	void Update () {
		if (enable)
		{
			Animator anim = player.GetComponent<Animator>();
			anim.SetBool("Water", true);
		}
	}
	
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player") {
			enable = true;
			player = other.gameObject;
		}
	}
	
	void OnTriggerExit2D(Collider2D other)
	{
		if (other.tag == "Player") {
			enable = false;
			player = null;
		}
	}
}
