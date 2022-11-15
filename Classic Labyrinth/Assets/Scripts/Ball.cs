using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    AudioSource ballAudio;
    [SerializeField] AudioClip wall_SFX;

    void Awake()
    {
        ballAudio = GetComponent<AudioSource>();
        ballAudio.volume = SaveLoad.soundVolume;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Wall" && collision.gameObject.GetComponent<Wall>().soundYes)
        {
            ballAudio.clip = wall_SFX;
            ballAudio.Play();
            collision.gameObject.GetComponent<Wall>().soundYes = false;
        }
    }
}
