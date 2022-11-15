using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowBall2 : MonoBehaviour
{
    [SerializeField] GameObject ballLevel;
    [SerializeField] float speed = 1;

    void Update()
    {
        if (transform.position == ballLevel.transform.position)
        {
            return;
        }

        transform.position = Vector3.Lerp(transform.position, ballLevel.transform.position, Time.deltaTime * speed);
    }
}
