using UnityEngine;
using System.Collections;

public class RopeScript : MonoBehaviour {

	//private GameObject objectStart;
	//private GameObject objectFinish;

	//private Vector3 deltaStart;
	//private Vector3 deltaFinish;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void SetStart(GameObject gameObject, Vector3 delta)
	{
		//objectStart = gameObject;
		//deltaStart = delta;
				
		GameObject chainCell = transform.Find("ChainCell0").gameObject;
		DistanceJoint2D distanceJoint = chainCell.GetComponent<DistanceJoint2D>();
		distanceJoint.connectedBody = gameObject.rigidbody2D;
		distanceJoint.anchor = delta;
	}
	
	public void SetFinish(GameObject gameObject, Vector3 delta)
	{
		//objectFinish = gameObject;
		//deltaFinish = delta;
		
		GameObject chainCell = transform.Find("ChainCell9").gameObject;
		DistanceJoint2D distanceJoint = chainCell.GetComponent<DistanceJoint2D>();
		distanceJoint.connectedBody = gameObject.rigidbody2D;
		distanceJoint.anchor = delta;
	}
}
