using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipperScript : MonoBehaviour
{
    public float velocity;
    public float force;
    public HingeJoint LeftFlipper;
    public HingeJoint RightFlipper;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            RightFlipper.motor = RotateFlipper(velocity, force);
        }

        if (Input.GetKeyUp(KeyCode.D))
        {
            RightFlipper.motor = RotateFlipper(-velocity, force);
        }

        if (Input.GetKey(KeyCode.A))
        {
            LeftFlipper.motor = RotateFlipper(-velocity, force);
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            LeftFlipper.motor = RotateFlipper(velocity, force);
        }

    }

    private JointMotor RotateFlipper(float velocity, float force)
    {
        JointMotor jointMotor = new JointMotor();
        jointMotor.force = force;
        jointMotor.targetVelocity = velocity;
        return jointMotor;
    }
}
