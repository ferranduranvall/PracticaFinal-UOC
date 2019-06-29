using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarEngine : MonoBehaviour
{

    public Transform path;
    public float maxSteerAngle = 45f;
    public WheelCollider wheelFL;
    public WheelCollider wheelFR;
    public WheelCollider wheelBL;
    public WheelCollider wheelBR;
    public float maxMotorTorque = 80f;
    public float maxBrakeTorque = 150f;
    public float currentSpeed;
    public float maxSpeed = 100f;
    public Vector3 centerOfMass;
    public bool isBraking = false;

    //[Header("Sensors")]
    //public float sensorLength = 3f;
    //public float frontSensorPosition = 0.5f;
    //public float frontSideSensorPosition = 0.2f;

    private List<Transform> nodes;
    private int currentNode = 0;


    // Start is called before the first frame update
    private void Start()
    {
        GetComponent<Rigidbody>().centerOfMass = centerOfMass;

        Transform[] pathTransforms = path.GetComponentsInChildren<Transform>();
        nodes = new List<Transform>();

        for (int i = 0; i < pathTransforms.Length; i++)
        {
            if (pathTransforms[i] != path.transform)
            {
                nodes.Add(pathTransforms[i]);
            }
        }
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        //Sensors();
        ApplySteer();
        Drive();
        CheckWaypointDistance();
    }

    //private void Sensors()
    //{
    //    RaycastHit hit;
    //    Vector3 sensorStartPos = transform.position;
    //    sensorStartPos.z += frontSensorPosition;


    //    // front center sensor
    //    if (Physics.Raycast(sensorStartPos, transform.forward, out hit, sensorLength))
    //    {

    //    }
    //    Debug.DrawLine(sensorStartPos, hit.point);


    //    // front right sensor
    //    sensorStartPos.x += frontSideSensorPosition;
    //    if (Physics.Raycast(sensorStartPos, transform.forward, out hit, sensorLength))
    //    {

    //    }
    //    Debug.DrawLine(sensorStartPos, hit.point);

    //    // front left sensor
    //    sensorStartPos.x -= 2 * frontSideSensorPosition;
    //    if (Physics.Raycast(sensorStartPos, transform.forward, out hit, sensorLength))
    //    {

    //    }
    //    Debug.DrawLine(sensorStartPos, hit.point);
    //}

    private void ApplySteer()
    {
        Vector3 relativeVector = transform.InverseTransformPoint(nodes[currentNode].position);
        float newSteer = (relativeVector.x / relativeVector.magnitude) * maxSteerAngle;
        wheelFL.steerAngle = newSteer;
        wheelFR.steerAngle = newSteer;
    }

    private void Drive()
    {
        // 30f
        currentSpeed = 2 * Mathf.PI * wheelFL.radius * wheelFL.rpm * 60 / 1000;

        if(currentSpeed < maxSpeed && !isBraking)
        {
            wheelFL.motorTorque = maxMotorTorque;
            wheelFR.motorTorque = maxMotorTorque;
        }
        else
        {
            wheelFL.motorTorque = 0;
            wheelFR.motorTorque = 0;
        }
    }

    private void CheckWaypointDistance()
    {
        if(Vector3.Distance(transform.position, nodes[currentNode].position) < 5f)
        {
            if(currentNode == nodes.Count - 1)
            {
                currentNode = 0; 
            }

            else
            {
                currentNode++;
            }
        }
    }

    private void Braking()
    {
        if (isBraking)
        {
            wheelBL.brakeTorque = maxBrakeTorque;
            wheelBR.brakeTorque = maxBrakeTorque;

        }
        else
        {
            wheelBL.brakeTorque = 0;
            wheelBR.brakeTorque = 0;
        }
    }
}
