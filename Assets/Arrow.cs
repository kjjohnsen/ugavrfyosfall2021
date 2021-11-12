using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public bool inFlight;
    public GameObject hitThing;
    public Vector3 offset;
    private bool everHit;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        if (inFlight)
        {
            Rigidbody rb = this.GetComponent<Rigidbody>();
            gameObject.transform.forward = rb.velocity;
        } else if (hitThing != null)
        {
            this.transform.position = hitThing.transform.position + offset;
        } else if (everHit == true && hitThing == null)
        {
            Destroy(this);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        inFlight = false;
        Rigidbody rb = this.GetComponent<Rigidbody>();
        rb.velocity = new Vector3();
        rb.isKinematic = true;

        hitThing = collision.gameObject;
        offset = this.transform.position - hitThing.transform.position;
        everHit = true;
    }
}
