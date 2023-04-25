using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    private readonly int mainMenu = 0;
    private readonly int levelSelect = 1;

    public void ChangeToLevelSelect()
    {
        SceneManager.LoadSceneAsync(levelSelect);
    }

    public void ChangeToMainMenu()
    {
        SceneManager.LoadSceneAsync(mainMenu);
    }

    public void ChangeToLevel(int level)
    {
        SceneManager.LoadSceneAsync(level + 1);
    }

}
