using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bow : MonoBehaviour
{
    OVRGrabbable grabbable;
    public GameObject arrow;
    public GameObject arrowPrefab;
    public float flightSpeed;
    // Start is called before the first frame update
    void Start()
    {
        this.grabbable = GetComponent<OVRGrabbable>();
    }

    // Update is called once per frame
    void LateUpdate()
    {

        if (grabbable.isGrabbed)
        {

            if(arrow != null)
            {
                this.transform.LookAt(this.transform.position + arrow.transform.forward, grabbable.grabbedBy.transform.up);
                this.transform.position = grabbable.grabbedBy.transform.position;
            }

            
        }

    }

    public void updateArrow(Transform hand)
    {
        if(arrow == null)
        {
            arrow = GameObject.Instantiate<GameObject>(arrowPrefab);
        }
        arrow.transform.position = hand.position;
        arrow.transform.forward = (transform.position - hand.position).normalized;
    }
    public void shootArrow(Transform hand)
    {
        arrow.GetComponent<Rigidbody>().velocity = arrow.transform.forward * flightSpeed * (this.transform.position - hand.transform.position).magnitude;
        arrow.GetComponent<Arrow>().inFlight = true;
        arrow = null;
       
    }
}
