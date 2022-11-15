using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    public bool soundYes = true;
    Transform ball;

    void Start()
    {
        ball = GameObject.FindWithTag("Ball").transform;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Ball" && !soundYes)
        {
            soundYes = true;
        }
    }
}
