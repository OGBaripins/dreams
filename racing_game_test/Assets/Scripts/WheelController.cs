using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelController : MonoBehaviour
{

    public WheelCollider front_right;
    public WheelCollider front_left;
    public WheelCollider rear_right;
    public WheelCollider rear_left;

    public Transform front_right_mesh;
    public Transform front_left_mesh;
    public Transform rear_right_mesh;
    public Transform rear_left_mesh;

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
        updateWheel(front_right, front_right_mesh);
        updateWheel(rear_left, rear_left_mesh);
        updateWheel(rear_right, rear_right_mesh);
    }

    void updateWheel(WheelCollider col, Transform trans)
    {
        Vector3 pos;
        Quaternion rot;
        col.GetWorldPose(out pos, out rot);
        Debug.Log("DEBUG: " + "Rot: " + rot + " Pos: " + pos);

        trans.position = pos;
        trans.rotation = rot;
    }
}
