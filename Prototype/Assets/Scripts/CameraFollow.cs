using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour 
{
	public float xMargin = 1f;		// Distance in the x axis the player can move before the camera follows.
	public float yMargin = 1f;		// Distance in the y axis the player can move before the camera follows.
	public float xSmooth = 8f;		// How smoothly the camera catches up with it's target movement in the x axis.
	public float ySmooth = 8f;		// How smoothly the camera catches up with it's target movement in the y axis.
	public Vector2 maxXAndY;		// The maximum x and y coordinates the camera can have.
	public Vector2 minXAndY;		// The minimum x and y coordinates the camera can have.
	public Vector3 delta = Vector3.zero;		// The minimum x and y coordinates the camera can have.
	public float rollSpeed = 100.0f;		// How smoothly the camera catches up with it's target movement in the y axis.
	public float rollSpeedAfterRoll = 100.0f;		// How smoothly the camera catches up with it's target movement in the y axis.
	public float xMarginRoll = 2f;		// Distance in the x axis the player can move before the camera follows.

	void Awake ()
	{
		// Setting up the reference.
		//transform.position = new Vector3(player.position.x, transform.position.y, transform.position.z);
	}


	bool CheckXMargin(float playerX)
	{
		// Returns true if the distance between the camera and the player in the x axis is greater than the x margin.
		return Mathf.Abs(transform.position.x - playerX) > xMargin;
	}


	bool CheckYMargin(float playerY)
	{
		// Returns true if the distance between the camera and the player in the y axis is greater than the y margin.
		return Mathf.Abs(transform.position.y - playerY) > yMargin;
	}


	void FixedUpdate ()
	{
		TrackPlayer();
		Roll();
	}
	
	
	void TrackPlayer ()
	{
		GameObject player = GameObject.FindGameObjectWithTag("Player");
		//player = GameObject.FindGameObjectWithTag("Player");
		// By default the target x and y coordinates of the camera are it's current x and y coordinates.
		float targetX = transform.position.x;
		float targetY = transform.position.y;

		float playerX = player.transform.position.x + delta.x;
		float playerY = player.transform.position.y + delta.y;

		// If the player has moved beyond the x margin...
		if(CheckXMargin(playerX))
			// ... the target x coordinate should be a Lerp between the camera's current x position and the player's current x position.
			targetX = Mathf.Lerp(targetX, playerX, xSmooth * Time.deltaTime);

		// If the player has moved beyond the y margin...
		if(CheckYMargin(playerY))
			// ... the target y coordinate should be a Lerp between the camera's current y position and the player's current y position.
			targetY = Mathf.Lerp(targetY, playerY, ySmooth * Time.deltaTime);

		// The target x and y coordinates should not be larger than the maximum or smaller than the minimum.
		targetX = Mathf.Clamp(targetX, minXAndY.x, maxXAndY.x);
		targetY = Mathf.Clamp(targetY, minXAndY.y, maxXAndY.y);

		// Set the camera's position to the target position with the same z component.
		transform.position = new Vector3(targetX, targetY, transform.position.z);
	}


	private bool roll = false;


	public void doRoll()
	{
		roll = true;
	}
	
	void Roll()
	{
		if (roll)
		{			
			GameObject player = GameObject.FindGameObjectWithTag("Player");
			float playerX = player.transform.position.x + delta.x;
			float currMargin = Mathf.Abs(transform.position.x - playerX);
			float distance = currMargin - xMargin;
			if (0 < distance)
			{
				if (currMargin > xMarginRoll)
				{
					transform.Rotate(Vector3.back * (rollSpeed + distance) * Time.deltaTime);
				}
				else
				{
					float oldZAngle = transform.eulerAngles.z;
					transform.Rotate(Vector3.back * (rollSpeed + distance) * Time.deltaTime);
					Debug.Log(transform.eulerAngles.z);
					float newZAngle = transform.eulerAngles.z;
					if (newZAngle <= 90 && 90 <= oldZAngle)
					{
						transform.eulerAngles = new Vector3(0, 0, 90);
					}
				}
			}
			else
			{
				float oldZAngle = transform.eulerAngles.z;
				transform.Rotate(Vector3.back * rollSpeedAfterRoll * Time.deltaTime);
				Debug.Log(transform.eulerAngles.z);
				float newZAngle = transform.eulerAngles.z;
				if (oldZAngle <= newZAngle)
				{
					transform.eulerAngles = Vector3.zero;
					roll = false;

					Animator anim = player.GetComponent<Animator>();
					anim.SetTrigger("Stay");
				}
			}
		}
	}
}
