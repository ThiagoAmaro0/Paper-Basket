using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public void SelectLevel(int level)
    {
        GameManager.instance.level = level;
        SceneHandler.instance.LoadScene("BaseLevel");
    }
    public void LoadScene(string name)
    {
        SceneHandler.instance.LoadScene(name);
    }
}
