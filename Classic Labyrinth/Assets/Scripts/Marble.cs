using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Marble : MonoBehaviour
{
    GameManager GM;
    bool done = false;

    void Start()
    {
        GM = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
        done = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Ball" && !done)
        {
            GM.MarbleSFX();
            done = true;
        }
    }
}
