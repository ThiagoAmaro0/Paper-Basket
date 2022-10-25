using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHandler : MonoBehaviour
{
    public static SceneHandler instance;
    private void Awake()
    {
        if (instance)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    //Non Assync
    public void LoadScene(int index)
    {
        SceneManager.LoadScene(index);
    }
    public void LoadScene(string name)
    {
        SceneManager.LoadScene(name);
    }

    //Assync
    public void LoadAsync(string name, Action<AsyncOperation> onComplete = null)
    {
        AsyncOperation op = SceneManager.LoadSceneAsync(name, LoadSceneMode.Additive);
        op.completed += onComplete;
    }

    public void UnLoadScene(string scene)
    {
        SceneManager.UnloadSceneAsync(scene);
    }
    public void UnLoadScene(int scene)
    {
        SceneManager.UnloadSceneAsync(scene);
    }
    public bool SceneExist(string name)
    {
        print(name);
        return SceneUtility.GetBuildIndexByScenePath("Scenes/" + name) != -1;
    }
}
