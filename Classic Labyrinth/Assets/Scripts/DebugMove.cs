using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugMove : MonoBehaviour
{
    [SerializeField] Rigidbody rb;
    [SerializeField] float force;
    Vector3 moveDir;

    void Update()
    {
        moveDir = new Vector3
                      (
                          Input.GetAxisRaw("Horizontal"),
                          0,
                          Input.GetAxisRaw("Vertical")
                      );
    }

    void FixedUpdate()
    {
        if (moveDir != Vector3.zero)
        {
            rb.AddForce(moveDir * force, ForceMode.Force);
        }
    }
}
