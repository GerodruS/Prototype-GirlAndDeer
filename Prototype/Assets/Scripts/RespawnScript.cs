using UnityEngine;
using System.Collections;

public class RespawnScript : MonoBehaviour {

	public GameObject restartPosition;
	
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player") {
			other.transform.position = restartPosition.transform.position;
		}
	}
}
