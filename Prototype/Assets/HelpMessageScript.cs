using UnityEngine;
using System.Collections;

public class HelpMessageScript : MonoBehaviour {

	public string message = string.Empty;
	private bool activate = true;

	void OnTriggerEnter2D(Collider2D other)
	{
		if (activate && other.tag == "Player") {
			GameObject helpGUIText = GameObject.FindGameObjectWithTag("HelpGUIText");
			MessageShowScript messageShowScript = helpGUIText.GetComponent<MessageShowScript>();
			messageShowScript.SetString(message);
			activate = false;
		}
	}
}
