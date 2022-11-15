using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class SceneLoader
{
    private static string sceneToLoad;
    public static string SceneToLoad { get => sceneToLoad; }

    // Load
    public static void Load(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    // Progress Load
    public static void ProgressLoad(string sceneName)
    {
        sceneToLoad = sceneName;
        SceneManager.LoadScene("Loading Progress");
    }

    // Reload Stage
    public static void ReloadStage()
    {
        var currentScene = SceneManager.GetActiveScene().name;
        ProgressLoad(currentScene);
    }

    // Load Next Stage
    public static void LoadNextStage()
    {
        var currentSceneName = SceneManager.GetActiveScene().name;
        var nextStage = int.Parse(currentSceneName.Split("Stage ")[1]) + 1;
        string nextScenename = "Stage " + nextStage;

        if (SceneUtility.GetBuildIndexByScenePath(nextScenename) == -1)
        {
            Debug.LogError(nextScenename + " does not exist");
            return;
        }

        ProgressLoad(nextScenename);
    }
}
