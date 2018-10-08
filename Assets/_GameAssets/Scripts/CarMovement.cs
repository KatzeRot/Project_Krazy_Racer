using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class AxleInfo {
    public WheelCollider leftWheel;
    public WheelCollider rightWheel;
    public bool motor; // is this wheel attached to motor?
    public bool steering; // does this wheel apply steer angle?
}
     
public class CarMovement : MonoBehaviour {
    public List<AxleInfo> axleInfos; // the information about each individual axle
    public float maxMotorTorque; // maximum torque the motor can apply to wheel
    public float maxSteeringAngle; // maximum steer angle the wheel can have
    float motor = 0;
    float steering = 0;
    private Rigidbody rb;

    public void start(){
        rb = this.GetComponent<Rigidbody>();
    }
    // finds the corresponding visual wheel
    // correctly applies the transform
    public void ApplyLocalPositionToVisuals(WheelCollider collider)
    {
        if (collider.transform.childCount == 0) {
            return;
        }
     
        Transform visualWheel = collider.transform.GetChild(0);
     
        Vector3 position;
        Quaternion rotation;
        collider.GetWorldPose(out position, out rotation);
     
        visualWheel.transform.position = position;
        visualWheel.transform.rotation = rotation;
    }
     
    public void FixedUpdate()
    {
        if(Input.GetKey("space")){
            if(motor <= maxMotorTorque){
                motor = motor + 10;
            }  
            }else if(Input.GetKey("s")){
                if(motor >= -150){
                    motor = motor - 500;
                }
            }
            
        if(Input.GetKey("d")){
            if(steering <= maxSteeringAngle){
                ++steering;
            }  
            }else if(Input.GetKey("a")){
                if(steering >= -maxSteeringAngle){
                    --steering;  
                }
            }
        if(!Input.GetKey("space") && !Input.GetKey("s")){
            if(!IsWheelersStop()){
                if(motor < 0){
                    motor++;
                }else{
                    motor--;
                }
            }
        }
        if(!Input.GetKey("d") && !Input.GetKey("a")){
            if(steering < 0){
                steering++;
            }else{
                steering--;
            }
        }

        foreach (AxleInfo axleInfo in axleInfos) {
            if (axleInfo.steering) {
                axleInfo.leftWheel.steerAngle = steering;
                axleInfo.rightWheel.steerAngle = steering;
            }
            if (axleInfo.motor) {
                axleInfo.leftWheel.motorTorque = motor;
                axleInfo.rightWheel.motorTorque = motor;
            }
            ApplyLocalPositionToVisuals(axleInfo.leftWheel);
            ApplyLocalPositionToVisuals(axleInfo.rightWheel);
        }
    }
    public bool IsGroundedAllWheels(){
        int wheels = 0;
        bool checkWheels = false;
        foreach (AxleInfo axleInfo in axleInfos) {
            if (axleInfo.rightWheel.isGrounded) {
                if (axleInfo.leftWheel.isGrounded) {
                    wheels++;
                }
            }
            if( wheels == axleInfos.Count){
                checkWheels = false;
                Debug.Log("Ruedas sin contacto con el SUELO");
            }else{
                checkWheels = true;
            }   
        }
        return checkWheels;
    }
    public bool IsWheelersStop(){
        int wheels = 0;
        bool checkWheels = false;
        foreach (AxleInfo axleInfo in axleInfos) {
            if (axleInfo.rightWheel.rpm == 0) {
                if (axleInfo.leftWheel.rpm == 0) {
                    wheels++;
                }
            }
            if( wheels == axleInfos.Count){
                checkWheels = false;
                Debug.Log("Ruedas PARADAS");
            }else{
                checkWheels = true;
            }   
        }
        return checkWheels;
    }
    public void Update(){
        Debug.Log(motor);
        //Movimiento del vehiculo cuando estás en el aire
        if(IsGroundedAllWheels()){
            if(Input.GetKey("d")){
                Debug.Log("Pulsado el BOTON D en el AIRE");
                this.GetComponent<Rigidbody>().AddTorque(Vector3.down * 500);
            }else if(Input.GetKey("a")){
                Debug.Log("Pulsado el BOTON A en el AIRE");
                this.GetComponent<Rigidbody>().AddTorque(Vector3.up * 50);
            }else if(Input.GetKey("w")){
                Debug.Log("Pulsado el BOTON W en el AIRE");
                this.GetComponent<Rigidbody>().AddTorque(Vector3.right * 50);
            }else if(Input.GetKey("s")){
                Debug.Log("Pulsado el BOTON S en el AIRE");
                this.GetComponent<Rigidbody>().AddTorque(Vector3.left * 50);
            }
        }
    }
}
