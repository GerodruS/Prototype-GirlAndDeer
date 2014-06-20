using UnityEngine;
using System.Collections;

public class DeerIsCaught : MonoBehaviour {
	/*
	private GameObject player;		// Reference to the player's transform.

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	*/
	public GameObject girlOnDeer;

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player") {
			Instantiate (girlOnDeer, transform.position, transform.rotation);
			Destroy (other.gameObject);
			Destroy (this.gameObject);

			
			GameObject mainCamera = GameObject.Find("Main Camera");
			if (mainCamera != null)
			{
				CameraFollow cameraFollow = mainCamera.GetComponent<CameraFollow>();
				if (cameraFollow != null)
				{
					cameraFollow.xSmooth = 100;
					mainCamera.camera.orthographicSize = 3;
					cameraFollow.delta = new Vector3(3, cameraFollow.delta.y, cameraFollow.delta.z);
				}
				//CameraFollow.xsmooth = 10;
				//mainCamera.camera.size = 3;
				//CameraFollow.delta = 3;
			}
		}
	}

}
