using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EscExit : MonoBehaviour
{
    [SerializeField] float timer = 0;
    TMP_Text exitText;
    bool done = false;

    void Start()
    {
        exitText = GetComponent<TMP_Text>();
    }

    void Update()
    {
        if (!done)
        {
            if (timer < 3)
            {
                timer += Time.deltaTime;
            }
            else
            {
                StartCoroutine(AlphaOut());
                done = true;
            }
        }
    }

    private YieldInstruction fadeInstruction = new YieldInstruction();

    IEnumerator AlphaOut()
    {
        float elapsedTime = 0.0f;
        Color c = exitText.color;
        while (elapsedTime < 1)
        {
            yield return fadeInstruction;
            elapsedTime += Time.deltaTime;
            c.a = 1.0f - Mathf.Clamp01(elapsedTime / 1);
            exitText.color = c;
        }
    }
}
