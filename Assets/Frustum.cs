using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frustum : MonoBehaviour
{
    public AudioClip bounceSound;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        AudioSource.PlayClipAtPoint(bounceSound, collision.contacts[0].point);
    }
}
