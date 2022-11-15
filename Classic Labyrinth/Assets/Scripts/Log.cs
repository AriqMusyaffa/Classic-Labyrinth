using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Log : MonoBehaviour
{
    GameObject cylinder;
    [SerializeField] float speed;
    public bool isRight = false;

    void Start()
    {
        cylinder = transform.GetChild(0).gameObject;
    }

    void Update()
    {
        if (isRight)
        {
            cylinder.transform.Translate(-Vector3.up * Time.deltaTime * speed);
        }
        else
        {
            cylinder.transform.Translate(Vector3.up * Time.deltaTime * speed);
        }
    }
}
