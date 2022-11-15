using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WrongHole : MonoBehaviour
{
    public static bool entered = false;

    private void OnTriggerEnter(Collider other)
    {
        entered = true;
    }
}
