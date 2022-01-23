using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
	public GameObject LoadingScene;
	public Image LoadingBar;

	public void LoadLevel (int NumeroEscena)
	{
		StartCoroutine (LevelCoroutine (NumeroEscena));
	}

	IEnumerator LevelCoroutine (int NumeroEscena)
	{
		LoadingScene.SetActive (true);
        AsyncOperation async = SceneManager.LoadSceneAsync(NumeroEscena, LoadSceneMode.Single);

		while (!async.isDone)
        {
			LoadingBar.fillAmount = async.progress / 0.9f;
			yield return null;
		}
	}
}