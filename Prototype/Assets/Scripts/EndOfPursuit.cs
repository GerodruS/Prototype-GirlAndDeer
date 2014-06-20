using UnityEngine;
using System.Collections;

public class EndOfPursuit : MonoBehaviour {

	public GameObject restartPosition;
	public GameObject girl;
	private int frame = -1;
	
	void Update()
	{
		frame = -1 < frame ? --frame : -1;
		if (0 == frame)
		{
			GameObject player = GameObject.FindGameObjectWithTag("Player");
			Animator anim = player.GetComponent<Animator>();
			anim.SetTrigger("Unconscious");
		}
	}
	
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player") {			
			Instantiate (girl, restartPosition.transform.position, transform.rotation);
			Destroy (other.gameObject);
			frame = 10;
			
			GameObject mainCamera = GameObject.Find("Main Camera");
			if (mainCamera != null)
			{
				CameraFollow cameraFollow = mainCamera.GetComponent<CameraFollow>();
				if (cameraFollow != null)
				{
					cameraFollow.xSmooth = 1;
					mainCamera.camera.orthographicSize = 2;
					cameraFollow.delta = new Vector3(0, cameraFollow.delta.y, cameraFollow.delta.z);
					cameraFollow.doRoll();
				}
				//CameraFollow.xsmooth = 10;
				//mainCamera.camera.size = 3;
				//CameraFollow.delta = 3;
			}
		}
	}
}
