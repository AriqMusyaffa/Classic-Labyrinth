using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    MusicManager MM;
    AmbienceManager AM;
    TimerManager TM;
    [SerializeField] GameObject gameOverPanel;
    [SerializeField] Hole hole;
    [SerializeField] GameObject doubleTapText;
    [SerializeField] Collider[] holeSealCollider;
    [SerializeField] TMP_Text winloseText;
    [SerializeField] GameObject replayObject;
    [SerializeField] GameObject nextStageObject;
    [SerializeField] GameObject mainMenuObject;
    [SerializeField] GameObject gopherImage;
    [SerializeField] AudioSource winAudio;
    [SerializeField] AudioClip winSFX;
    [SerializeField] AudioClip failSFX;

    bool gameWin = false;
    public bool GameWin => gameWin;

    bool gameLose = false;
    public bool GameLose => gameLose;

    [SerializeField] TMP_Text stageText;
    [SerializeField] AudioSource buttonSound;
    [SerializeField] AudioSource holeAudio;

    void Start()
    {
        gameOverPanel.SetActive(false);
        winloseText.gameObject.SetActive(false);

        var currentSceneName = SceneManager.GetActiveScene().name;
        var currentStage = int.Parse(currentSceneName.Split("Stage ")[1]);
        
        stageText.text = "Stage " + currentStage;

        buttonSound.volume = SaveLoad.soundVolume;
        buttonSound.Play();
        holeAudio.volume = SaveLoad.soundVolume;
        WrongHole.entered = false;

        TM = GetComponent<TimerManager>();
    }

    void Update()
    {
        if (!gameWin)
        {
            if (hole.Entered && !gameOverPanel.activeInHierarchy)
            {
                gameWin = true;
                TM.counting = false;
                StartCoroutine(StageWin());
            }
        }

        if (!gameLose)
        {
            if (WrongHole.entered && !gameOverPanel.activeInHierarchy)
            {
                gameLose = true;
                TM.counting = false;
                StartCoroutine(StageLose());
            }
        }

        if (Input.touchCount > 0 && !gameWin && !gameLose)
        {
            foreach (Touch touch in Input.touches)
            {
                if (touch.tapCount == 2)
                {
                    SceneLoader.Load("Main Menu");
                }
            }
        }

        //if (Input.GetKeyDown(KeyCode.Escape))
        //{
        //    BackToMainMenu();
        //}
    }

    IEnumerator StageWin()
    {
        foreach (Collider c in holeSealCollider)
        {
            c.enabled = true;
        }
        yield return new WaitForSeconds(2);
        winAudio.clip = winSFX;
        winAudio.Play();

        // Win Position
        winloseText.gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 400);
        replayObject.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 0);
        nextStageObject.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, -250);
        mainMenuObject.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, -500);

        gameOverPanel.SetActive(true);
        winloseText.text = "Stage Clear!";
        winloseText.gameObject.SetActive(true);
        doubleTapText.SetActive(false);
    }

    IEnumerator StageLose()
    {
        foreach (Collider c in holeSealCollider)
        {
            c.enabled = true;
        }
        yield return new WaitForSeconds(2);
        winAudio.clip = failSFX;
        winAudio.Play();

        // Lose Position
        winloseText.gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 500);
        replayObject.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, -250);
        mainMenuObject.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, -500);

        nextStageObject.SetActive(false);
        gopherImage.SetActive(true);
        gameOverPanel.SetActive(true);
        winloseText.text = "Oops!";
        winloseText.fontSize = 180;
        winloseText.gameObject.SetActive(true);
        doubleTapText.SetActive(false);
    }
    
    public void MarbleSFX()
    {
        holeAudio.Play();
    }

    public void BackToMainMenu()
    {
        SceneLoader.Load("Main Menu");
    }

    public void Replay()
    {
        SceneLoader.ReloadStage();
    }

    public void PlayNext()
    {
        if (SceneManager.GetActiveScene().name == "Stage 7")
        {
            SaveLoad.comingSoonOn = true;
            SceneLoader.Load("Main Menu");
        }
        else
        {
            SceneLoader.LoadNextStage();
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
}
