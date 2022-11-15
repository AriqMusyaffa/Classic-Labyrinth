using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] GameObject mainMenuPanel, stageSelectPanel, settingsPanel, comingSoonPanel;
    AudioSource MM;
    [SerializeField] Slider volumeSlider;
    [SerializeField] AudioSource buttonSound;
    bool isQuit = false;
    float quitTime = 0f;
    float standbyTime = 0f;

    void Start()
    {
        if (SaveLoad.StagePanelOn)
        {
            StageSelect();
        }

        if (SaveLoad.comingSoonOn)
        {
            ComingSoon();
        }

        SaveLoad.LoadData();
        MM = GameObject.FindWithTag("MusicManager").GetComponent<AudioSource>();
        volumeSlider.value = SaveLoad.soundVolume;

        buttonSound.volume = SaveLoad.soundVolume;
        buttonSound.Play();
        Debug.Log("Load : " + SaveLoad.soundVolume);
    }

    void Update()
    {
        SaveLoad.soundVolume = volumeSlider.value;
        MM.volume = SaveLoad.soundVolume;

        if (isQuit)
        {
            if (quitTime < 0.5f)
            {
                quitTime += Time.deltaTime;
            }
            else
            {
                Application.Quit();
            }
        }

        if (standbyTime < 0.5f)
        {
            standbyTime += Time.deltaTime;
        }
    }

    public void TextHover(TMP_Text text)
    {
        text.color = Color.yellow;
    }

    public void TextUnhover(TMP_Text text)
    {
        text.color = Color.white;
    }

    public void MainMenu()
    {
        SaveLoad.StagePanelOn = false;
        SaveLoad.SaveData();
        Debug.Log("Save : " + SaveLoad.soundVolume);
        SceneLoader.Load("Main Menu");
    }

    public void StageSelect()
    {
        SaveLoad.StagePanelOn = true;
        stageSelectPanel.SetActive(true);
        mainMenuPanel.SetActive(false);
        buttonSound.Play();
    }

    public void Settings()
    {
        settingsPanel.SetActive(true);
        mainMenuPanel.SetActive(false);
        buttonSound.Play();
    }

    public void ComingSoon()
    {
        SaveLoad.StagePanelOn = true;
        SaveLoad.comingSoonOn = false;
        mainMenuPanel.SetActive(false);
        stageSelectPanel.SetActive(false);
        comingSoonPanel.SetActive(true);
        SaveLoad.stageScrollValue = 1;
        buttonSound.Play();
    }

    public void ReloadStageSelect()
    {
        SaveLoad.comingSoonOn = false;
        SaveLoad.StagePanelOn = true;
        SceneLoader.Load("Main Menu");
    }

    public void GoToStage(int num)
    {
        if (standbyTime >= 0.5f)
        {
            SceneLoader.ProgressLoad("Stage " + num);
        }
    }

    public void QuitGame()
    {
        buttonSound.Play();
        isQuit = true;
    }
}
