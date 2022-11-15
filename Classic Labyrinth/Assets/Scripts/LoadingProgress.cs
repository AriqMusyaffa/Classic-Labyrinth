using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class LoadingProgress : MonoBehaviour
{
    [SerializeField] Image image;
    [SerializeField] TMP_Text text;

    void Start()
    {
        text.text = "Loading... [0%]";
        StartCoroutine(Progress());
    }

    IEnumerator Progress()
    {
        image.fillAmount = 0;
        yield return new WaitForSeconds(1);

        var asyncOp = SceneManager.LoadSceneAsync(SceneLoader.SceneToLoad);

        while (!asyncOp.isDone)
        {
            image.fillAmount = asyncOp.progress;
            text.text = "Loading... [" + (int)(image.fillAmount * 100) + "%]";
            yield return null;
        }
    }
}
