using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public int levelIndex;

    public void NextScene()
    {
        StartCoroutine("Timer");
    }

    public void ExitGame()
    {
        ExitGame();
    }
    IEnumerator Timer()
    {
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadSceneAsync(levelIndex);
    }
}
