using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalScript : MonoBehaviour
{
    public GameObject LoadingPanel;
    public string sceneName;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            StartCoroutine(LoadNextScene());
        }
    }

    //load the next scene

    IEnumerator LoadNextScene()
    {
        LoadingPanel.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(sceneName);
    }

}
