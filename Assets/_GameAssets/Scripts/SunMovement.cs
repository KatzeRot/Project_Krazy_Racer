using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunMovement : MonoBehaviour {
	private float rotation;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		//transform.rotation.x = transform.rotation.x + 0.1f;
		//transform.rotation = Quaternion.AngleAxis(80, Vector3.up) + Quaternion.AngleAxis(80, Vector3.up);
		rotation = rotation + 0.01f;
		transform.localRotation = Quaternion.Euler(rotation, 0f, 0f);
	}
}
