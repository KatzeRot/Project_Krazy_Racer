using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopBrake : MonoBehaviour {
	private Vector3 brakePosition;
	private Quaternion brakeRotation;
	// Use this for initialization
	void Start () {
		brakePosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);
		//brakeRotation = 
	}
	
	// Update is called once per frame
	void Update () {
		transform.SetPositionAndRotation(brakePosition, brakeRotation);
	}
}
