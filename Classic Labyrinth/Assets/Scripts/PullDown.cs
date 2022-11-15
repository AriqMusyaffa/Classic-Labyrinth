using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PullDown : MonoBehaviour
{
    [SerializeField] Rigidbody rb;
    bool pull;

    void FixedUpdate()
    {
        if (pull && !WrongHole.entered)
        {
            rb.AddForce(-transform.up * 100, ForceMode.Impulse);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Ball")
        {
            pull = true;
        }
    }
}
