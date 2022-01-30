using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public GameObject LoadingPanel;
    public void LoadLevel(string sceneName)
    {
        StartCoroutine(LoadNextScene(sceneName));
    }

    IEnumerator LoadNextScene(string sceneName)
    {
        LoadingPanel.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(sceneName);
    }

}