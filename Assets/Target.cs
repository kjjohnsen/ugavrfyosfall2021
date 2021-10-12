using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public int hits;
    public int maxhits;

    public int angle; //keeps track of where we are on a circle
    public int radius; //how big is our circle
    Vector3 initialPosition;
    // Start is called before the first frame update
    void Start()
    {
        hits = maxhits;
        initialPosition = transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = new Vector3(initialPosition.x + radius * Mathf.Cos(angle * Time.deltaTime), initialPosition.y + radius * Mathf.Sin(angle * Time.deltaTime), initialPosition.z);
        angle = angle + 1; //angle += 1;
    }

    private void OnCollisionEnter(Collision collision)
    {
        hits = hits - 1; //hits -= 1;
        if (hits == 0)
        {
            gameObject.SetActive(false);
        }
    }
}
