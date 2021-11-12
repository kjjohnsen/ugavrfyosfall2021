using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Remy : MonoBehaviour
{
    Animator animator;
    public Player player;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(player.head.position, player.head.forward, out hit))
        {
            if (hit.rigidbody != null)
            {
                if (hit.rigidbody.transform == this.transform)
                {
                    //hit me
                    animator.SetTrigger("dance");
                }
            }
        }
    }
}
