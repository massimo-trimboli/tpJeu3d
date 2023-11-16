using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gravite : MonoBehaviour
{
    public float gravity;
    public GameObject planet = null;

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        if (planet == null)
        {
            if(transform.up != Vector3.up)
            {
                Quaternion pointUp = Quaternion.FromToRotation(transform.up, Vector3.up) * transform.rotation;
                transform.rotation = pointUp;
            }
        }
        else
        {
            Vector3 direction = (planet.transform.position - transform.position).normalized;
            Quaternion rotation = Quaternion.FromToRotation(transform.up, -direction) * transform.rotation;
            transform.rotation = rotation;

            GetComponent<Rigidbody>().AddForce(direction * gravity);
            //GetComponent<Rigidbody>().velocity = GetComponent<Rigidbody>().velocity + direction * gravity;
        }
    }
}
