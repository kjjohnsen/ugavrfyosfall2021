using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public bool locked;
    // Start is called before the first frame update
    void Start()
    {
        locked = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (locked)
        {
            this.GetComponent<Rigidbody>().isKinematic = true;
        }
        else
        {
            this.GetComponent<Rigidbody>().isKinematic = false;
        }
    }
}
