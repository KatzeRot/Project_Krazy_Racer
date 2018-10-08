using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMierda : MonoBehaviour {
	//[SerializeField] GameObject rightWheel;
	//[SerializeField] GameObject leftWheel;
	[SerializeField] Transform car;
	Transform positionCamera;
	//Transform positionPoint;
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		positionCamera = this.GetComponent<Transform>();
		//cameraPoint = cameraPoint.GetComponent<Transform>();
		Debug.Log("Posición: " + positionCamera + " Punto: " + car);
		//transform.position.x = car.position.x + 10;
		transform.Translate(0f,car.position.x + 10, 0f);		
	}
}
