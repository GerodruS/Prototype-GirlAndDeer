using UnityEngine;
using System.Collections;

public class NightmareScript : MonoBehaviour {

	public GameObject image;
	public float distance = 1;
	public GameObject shelter;
	private int frame = 0; 

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (0 == frame)
		{
			GameObject player = GameObject.FindGameObjectWithTag("Player");
			Vector3 distanceCurrent = transform.position - player.transform.position;
			if (distanceCurrent.magnitude < distance)
			{
				image.renderer.enabled = true;
				frame = 120;
			}
		}
		else if (80 == frame)
		{
			--frame;
			shelter.transform.position = transform.position;
			Time.timeScale = 0;
		}
		else if (2 == frame)
		{
			GameObject gameController = GameObject.FindGameObjectWithTag("GameController");
			Pauser pauser = gameController.GetComponent<Pauser>();
			pauser.restart = true;
			
			GameObject restartGUIText = GameObject.FindGameObjectWithTag("HelpGUIText");
			MessageShowScript messageShowScript = restartGUIText.GetComponent<MessageShowScript>();
			messageShowScript.SetString("'R' for Repeat");
		}
		else
		{
			--frame;
		}
	}
}
