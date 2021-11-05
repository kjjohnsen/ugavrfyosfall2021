using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Enemy : MonoBehaviour
{
    public NavMeshAgent agent;
    public Player player; //going to be null until it's assigned
    public bool stunned; //default to false
    private float agentSpeed = 1;
    private float stunTimer;
    public float stunTime; //seconds
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        stunned = true;
        stunTimer = 4;
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null) {
            agent.SetDestination(player.transform.position);
        }

        if (stunned)
        {
            agent.speed = 0;
            stunTimer -= Time.deltaTime;
            if(stunTimer < 0)
            {
                stunned = false;
            }
        }
        else
        {
            agent.speed = agentSpeed;
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        OVRGrabbable grabbable = collision.rigidbody?.GetComponent<OVRGrabbable>();
        if (grabbable != null)
        {
            stunned = true;
            stunTimer = stunTime;
        }
    }
}
