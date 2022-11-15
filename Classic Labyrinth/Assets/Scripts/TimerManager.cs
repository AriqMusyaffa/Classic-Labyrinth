using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimerManager : MonoBehaviour
{
    public float timer;
    public TMP_Text timerTxt;
    public bool counting = true;

    void Update()
    {
        if (counting)
        {
            timer += Time.deltaTime;
            float minutes = Mathf.FloorToInt(timer / 60);
            float seconds = Mathf.FloorToInt(timer % 60);
            timerTxt.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
    }

    public void HideTimer()
    {
        timerTxt.gameObject.SetActive(false);
    }
}
