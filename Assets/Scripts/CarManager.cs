using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class CarManager : MonoBehaviour
{
    public float speed = 20;
    HingeJoint[] wheels;

    // Start is called before the first frame update
    void Start()
    {
        wheels = gameObject.GetComponents<HingeJoint>();
    }

    // Update is called once per frame
    void Update()
    {
        float forward;
        if (GameManager.levelFinished)
        {
            forward = 0;
        }
        else
        {
            forward = Input.GetAxis("Vertical");
        }
        //apply vertical axis to back wheels
        JointMotor wheelMotor = wheels[2].motor;
        wheelMotor.force = Mathf.Abs(speed * forward);
        if (forward > 0)
        {
            wheelMotor.targetVelocity = 800;
        }
        else if (forward < 0)
        {
            wheelMotor.targetVelocity = -800;
        }
        else
        {
            //slowly lose speed
            wheelMotor.targetVelocity *= 0.99f;
        }

        wheels[2].motor = wheelMotor;

        wheelMotor = wheels[3].motor;
        wheelMotor.force = Mathf.Abs(speed * forward);
        if (forward > 0)
        {
            wheelMotor.targetVelocity = -800;
        }
        else if (forward < 0)
        {
            wheelMotor.targetVelocity = 800;
        }
        else
        {
            //slowly lose speed
            wheelMotor.targetVelocity *= 0.99f;
        }

        wheels[3].motor = wheelMotor;

        /*
        //apply horizontal axis to chassis rotation
        Vector3 rot = Vector3.zero;
        //Quaternion euler.eulerAngles = 
        rot.y = Input.GetAxis("Horizontal") * 5;
        
        gameObject.transform.localEulerAngles += rot;
        */
        //turn wheel when button pressed
        float rot;
        if (GameManager.levelFinished)
        {
            rot = 0;
        }
        else
        {
            rot = Input.GetAxis("Horizontal");
        }

        Vector3 turn = wheels[0].axis;
        turn.z = -1 * rot;
        wheels[0].axis = turn;

        turn = wheels[1].axis;
        turn.z = 1 * rot;
        wheels[1].axis = turn;

        if (gameObject.transform.position.y <= -5)
        {
            Hitpoints.hp = 0;
            transform.position = GameManager.spawn.position;
            GetComponent<Rigidbody>().isKinematic = true;
        }
    }
}