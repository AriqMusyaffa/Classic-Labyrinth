using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallLevel : MonoBehaviour
{
    [SerializeField] GameObject ball;

    void Update()
    {
        transform.position = new Vector3(ball.transform.position.x, 90, ball.transform.position.z);
    }
}
