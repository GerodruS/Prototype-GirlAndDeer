using UnityEngine;
using System.Collections;

public class MessageShowScript : MonoBehaviour
{
	public float delayTime = 5.0f;
	private float delayTimeCurrent = 0.0f;
	private GUIText guiText;

	// Use this for initialization
	void Start () {
		guiText = GetComponent<GUIText>();
	}
	
	// Update is called once per frame
	void Update () {
		if (0.0f < delayTimeCurrent)
		{
			delayTimeCurrent -= Time.deltaTime;
			if (delayTimeCurrent < 0.0f)
			{
				guiText.text = string.Empty;
				delayTimeCurrent = 0.0f;
			}
		}
	}

	public void SetString(string text)
	{
		SetString(text, delayTime);
	}
	
	public void SetString(string text, float delay)
	{
		delayTimeCurrent = delayTime;
		guiText.text = text;
	}
}
