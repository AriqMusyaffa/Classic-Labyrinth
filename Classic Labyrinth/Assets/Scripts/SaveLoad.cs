using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveLoad : MonoBehaviour
{
    public static SaveLoad instance;
    public static bool StagePanelOn;
    public static bool comingSoonOn;
    public static float stageScrollValue;
    public static float soundVolume = 1;

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

        DontDestroyOnLoad(gameObject);
    }

    public static void SaveData()
    {
        PlayerPrefs.SetFloat("volume", soundVolume);
    }

    public static void LoadData()
    {
        soundVolume = PlayerPrefs.GetFloat("volume", 1);
    }
}
