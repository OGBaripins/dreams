using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelController : MonoBehaviour
{

    [SerializeField] WheelCollider front_right;
    [SerializeField] WheelCollider front_left;
    [SerializeField] WheelCollider rear_right;
    [SerializeField] WheelCollider rear_left;

    [SerializeField] Transform front_right_mesh;
    [SerializeField] Transform front_left_mesh;
    [SerializeField] Transform rear_right_mesh;
    [SerializeField] Transform rear_left_mesh;

    public float acceleration = 500f;
    public float break_force = 300f;
    public float max_turn_angle = 20f;

    private float cur_turn_angle = 0f;
    private float cur_acceleration = 0f;
    private float cur_break_force = 0f;


    // // Start is called before the first frame update
    // void Start()
    // {

    // }

    // Update is called once per frame
    private void FixedUpdate()
    {

        cur_acceleration = acceleration * Input.GetAxis("Vertical");

        if (Input.GetKey(KeyCode.Space))
            cur_break_force = break_force;
        else
            cur_break_force = 0f;

        rear_right.motorTorque = cur_acceleration;
        rear_left.motorTorque = cur_acceleration;

        front_left.brakeTorque = cur_break_force;
        front_right.brakeTorque = cur_break_force;
        rear_left.brakeTorque = cur_break_force;
        rear_right.brakeTorque = cur_break_force;

        cur_turn_angle = max_turn_angle * Input.GetAxis("Horizontal");

        front_left.steerAngle = cur_turn_angle;
        front_right.steerAngle = cur_turn_angle;

        //Optimize!
        updateWheel(front_left, front_left_mesh);
        updateWheel(rear_left, rear_left_mesh);

        updateWheel(front_right, front_right_mesh);
        updateWheel(rear_right, rear_right_mesh);
    }

    void updateWheel(WheelCollider col, Transform trans)
    {
        Vector3 pos;
        Quaternion rot;
        col.GetWorldPose(out pos, out rot);

        trans.position = pos;
        trans.rotation = rot;
    }
}
