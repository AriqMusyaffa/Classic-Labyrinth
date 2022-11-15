using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flag : MonoBehaviour
{
    [SerializeField] bool isRight;
    [SerializeField] AudioSource particleAudio;

    void Start()
    {
        particleAudio.volume = SaveLoad.soundVolume;
    }

    void Update()
    {
        if (isRight)
        {
            transform.rotation = Quaternion.Euler(0, Camera.main.transform.eulerAngles.y, 0);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, Camera.main.transform.eulerAngles.y + 180, 0);
        }
    }
}
