using UnityEngine;
using UnityEngine.Assertions;

public class Flip : MonoBehaviour
{
    public float flipperSpeed = 1000f;
    public float reverseMod = 1f;

    [System.NonSerialized]
    public bool isPressed = false;

    private HingeJoint2D hinge;

    private void Awake()
    {
        hinge = GetComponent<HingeJoint2D>();
        Assert.IsNotNull(hinge, "Couldn't find the hinge component."); //This will only run in debug mode
    }

    private void FixedUpdate()
    {
        if (isPressed)
        {
            JointMotor2D _motor = hinge.motor;
            _motor.motorSpeed = reverseMod * flipperSpeed;
            hinge.motor = _motor;
        }
        else
        {
            JointMotor2D _motor = hinge.motor;
            _motor.motorSpeed = reverseMod * -flipperSpeed;
            hinge.motor = _motor;
        }

    }
}
