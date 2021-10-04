using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public OVRInput.Controller leftHand;
    public OVRInput.Controller rightHand;
    public Transform head; //attached in the inspector
    public Transform body; //attached in the inspector
   
    // Start is called before the first frame update

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 leftJoystick = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick, leftHand); //left joystick goes from -1 to 1 in x and y
        Vector3 headDirection = head.forward;  //gives us the look direction
        Rigidbody rb = GetComponent<Rigidbody>(); //gets the rigidbody attached to the same gameobject as this script

        //rb.AddForce(headDirection * leftJoystick.y*10);

        Vector3 bodyVelocity = headDirection * leftJoystick.y;
        bodyVelocity.y = rb.velocity.y; //retain velocity due to gravity or whatever
        rb.velocity = bodyVelocity;
        //rb.velocity = headDirection * leftJoystick.y;
        //transform.Translate(headDirection*leftJoystick.y*Time.deltaTime); //moves by 1 unit per second in the forward direction
        
        Vector3 bodyToHead = head.transform.position - body.transform.position;
        float headHeight = bodyToHead.magnitude;
        body.transform.position = head.transform.position-Vector3.up*headHeight;
        body.transform.localScale = new Vector3(1, headHeight / 2.0f, 1);

    }
}
