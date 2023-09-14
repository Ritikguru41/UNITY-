using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCarController : MonoBehaviour
{
    [Header("Wheels Collider")]
    public WheelCollider frontLeftWheelCollider;
    public WheelCollider frontRightWheelCollider;
    public WheelCollider backLeftWheelCollider;
        public WheelCollider backRighttWheelCollider;

   [Header("Wheels Transform")]
    public Transform frontLeftWheelTransform;
    public Transform frontRightWheelTransform;
    public Transform backLeftWheelTransform;
    public Transform backRighttWheelTransform;
    
    [Header("Car Engine")]
    public float accelerationForce = 300f;
    public float breakingForce = 3000f;
    private float presentBreakForce = 0f;
    private float presentAcceleartion = 0f;
    
    [Header("Car Steering")]
    public float wheelsTorque = 35f;
    private float presentTurnAngle = 0f;

    private void Update()
    {
        MoveCar();
        CarSteering();
    }

    private void MoveCar()
    {
        frontLeftWheelCollider.motorTorque = presentAcceleartion;
        frontRightWheelCollider.motorTorque = presentAcceleartion;
        backLeftWheelCollider.motorTorque = presentAcceleartion;
        backRighttWheelCollider.motorTorque = presentAcceleartion;

        presentAcceleartion = accelerationForce * SimpleInput.GetAxis("Vertical");
    }

  private void CarSteering()
  {
    presentTurnAngle = wheelsTorque * SimpleInput.GetAxis("Horizontal");
    frontLeftWheelCollider.steerAngle = presentTurnAngle;
    frontRightWheelCollider.steerAngle = presentTurnAngle;

    SteeringWheels(frontLeftWheelCollider, frontLeftWheelTransform);
    SteeringWheels(frontRightWheelCollider, frontRightWheelTransform);
    SteeringWheels(backLeftWheelCollider,backLeftWheelTransform);
    SteeringWheels(backRighttWheelCollider,backRighttWheelTransform);
  }

 void SteeringWheels(WheelCollider WC, Transform WT)
  {
    Vector3 position;
    Quaternion rotation;

    WC.GetWorldPose(out position, out rotation);

    WT.position = position;
    WT.rotation = rotation;

  }

    public void ApplyBreaks()
   {
        StartCoroutine(carBreaks());
     }
     IEnumerator carBreaks()
     {
      presentBreakForce = breakingForce;
      frontLeftWheelCollider.brakeTorque = presentBreakForce;
     frontRightWheelCollider.brakeTorque = presentBreakForce;
     backLeftWheelCollider.brakeTorque = presentBreakForce;
     backRighttWheelCollider.brakeTorque = presentBreakForce;

     yield return new WaitForSeconds(2f);

     presentBreakForce = 0f;

     frontLeftWheelCollider.brakeTorque = presentBreakForce;
     frontRightWheelCollider.brakeTorque = presentBreakForce;
     backLeftWheelCollider.brakeTorque = presentBreakForce;
     backRighttWheelCollider.brakeTorque = presentBreakForce;
     }
}