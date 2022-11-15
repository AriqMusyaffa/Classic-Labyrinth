using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogWall : MonoBehaviour
{
    Log logParent;
    [SerializeField] bool isRight;

    void Awake()
    {
        logParent = transform.parent.GetComponent<Log>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Log")
        {
            if (isRight)
            {
                logParent.isRight = false;
            }
            else
            {
                logParent.isRight = true;
            }
        }
    }
}
