using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmbienceManager : MonoBehaviour
{
    public static AmbienceManager instance;
    public AudioSource EverAmbience;
    public AudioClip ingameAmbience;

    public void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }

        EverAmbience = GetComponent<AudioSource>();
        DontDestroyOnLoad(gameObject);
    }
}
